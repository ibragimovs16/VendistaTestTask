using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VendistaTestTask.Domain.DTOs;
using VendistaTestTask.Domain.Models;
using VendistaTestTask.Models;
using VendistaTestTask.Services.Abstractions;

namespace VendistaTestTask.Controllers;

public class HomeController : Controller
{
    private readonly IAuthService _authService;
    private readonly ITerminalsService _terminalsService;
    private readonly ITypesService _typesService;

    public HomeController(IAuthService authService, ITypesService typesService, ITerminalsService terminalsService)
    {
        _authService = authService;
        _typesService = typesService;
        _terminalsService = terminalsService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(SendCommandDto sendCommandModel)
    {
        var tokenModel = await GetToken();
        var types = await _typesService.GetTypesAsync(tokenModel);

        var viewModel = new IndexViewModel
        {
            Types = types.Data
        };

        if (sendCommandModel.TerminalId == 0)
            return View(viewModel);

        var sendCommandResponse = await _terminalsService.SendCommandAsync(await GetToken(), sendCommandModel);
        if (sendCommandResponse.StatusCode != HttpStatusCode.OK)
            viewModel.ErrorMessage = sendCommandResponse.Description;
        viewModel.History =
            (await _terminalsService.GetCommandsHistoryAsync(tokenModel, sendCommandModel.TerminalId)).Data;

        return View(viewModel);
    }

    public async Task<IActionResult> ShowParams(int id)
    {
        var tokenModel = await GetToken();
        var model = await _typesService.GetTypesItemByIdAsync(tokenModel, id);
        return PartialView("Partial/_ViewParamsPartial", model.Data);
    }

    public async Task<IActionResult> ShowHistoryTable(int terminalId)
    {
        var tokenModel = await GetToken();
        var types = await _typesService.GetTypesAsync(tokenModel);
        var history = await _terminalsService.GetCommandsHistoryAsync(tokenModel, terminalId);
        return PartialView("Partial/_ViewHistoryTablePartial", new IndexViewModel
        {
            Types = types.Data,
            History = history.Data
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private async Task<TokenModel> GetToken()
    {
        if (Request.Cookies.ContainsKey("TokenModel"))
            return JsonConvert.DeserializeObject<TokenModel>(Request.Cookies["TokenModel"]!)!;

        var tokenModel = (await _authService.GetTokenAsync(new UserDto
        {
            Login = "part",
            Password = "part"
        })).Data!;

        Response.Cookies.Append("TokenModel", JsonConvert.SerializeObject(tokenModel));
        return tokenModel;
    }
}