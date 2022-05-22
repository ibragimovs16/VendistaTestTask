using System.Net;
using System.Net.Http.Json;
using VendistaTestTask.Domain.DTOs;
using VendistaTestTask.Domain.Models;
using VendistaTestTask.Domain.Response;
using VendistaTestTask.Services.Abstractions;

namespace VendistaTestTask.Services.Implementations;

public class TerminalsService : ITerminalsService
{
    private const string BaseUri = "http://178.57.218.210:198/terminals";
    private readonly HttpClient _httpClient = new();

    public async Task<BaseResponse<ResponseModel<TerminalItemModel>>> SendCommandAsync(TokenModel tokenModel,
        SendCommandDto sendCommandDto)
    {
        var sendCommand = new SendCommandModel
        {
            CommandId = sendCommandDto.CommandId,
            Parameter1 = sendCommandDto.Parameter1,
            Parameter2 = sendCommandDto.Parameter2,
            Parameter3 = sendCommandDto.Parameter3,
            Parameter4 = sendCommandDto.Parameter4,
            StrParameter1 = sendCommandDto.StrParameter1,
            StrParameter2 = sendCommandDto.StrParameter2
        };

        var builder = new UriBuilder(BaseUri + $"/{sendCommandDto.TerminalId}/commands")
        {
            Query = $"token={tokenModel.Token}"
        };

        var response = await _httpClient.PostAsJsonAsync(builder.Uri, sendCommand);
        if (response.StatusCode == HttpStatusCode.OK)
            return new BaseResponse<ResponseModel<TerminalItemModel>>
            {
                StatusCode = response.StatusCode,
                Description = "Успешно.",
                Data = await response.Content.ReadFromJsonAsync<ResponseModel<TerminalItemModel>>()
            };

        var responseJson = await response.Content.ReadFromJsonAsync<ErrorModel>();
        return new BaseResponse<ResponseModel<TerminalItemModel>>
        {
            StatusCode = response.StatusCode,
            Description = responseJson!.Error
        };
    }

    public async Task<BaseResponse<ResponseModel<TerminalItemResponse>>> GetCommandsHistoryAsync(TokenModel tokenModel,
        int terminalId)
    {
        var builder = new UriBuilder(BaseUri + $"/{terminalId}/commands")
        {
            Query = $"token={tokenModel.Token}&ItemsOnPage=1000"
        };

        var response = await _httpClient.GetAsync(builder.ToString());
        var xui = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.OK)
            return new BaseResponse<ResponseModel<TerminalItemResponse>>
            {
                StatusCode = response.StatusCode,
                Description = "Успешно.",
                Data = await response.Content.ReadFromJsonAsync<ResponseModel<TerminalItemResponse>>()
            };

        var responseJson = await response.Content.ReadFromJsonAsync<ErrorModel>();
        return new BaseResponse<ResponseModel<TerminalItemResponse>>
        {
            StatusCode = response.StatusCode,
            Description = responseJson!.Error
        };
    }
}