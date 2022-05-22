using VendistaTestTask.Domain.DTOs;
using VendistaTestTask.Domain.Models;
using VendistaTestTask.Domain.Response;

namespace VendistaTestTask.Services.Abstractions;

public interface ITerminalsService
{
    Task<BaseResponse<ResponseModel<TerminalItemModel>>> SendCommandAsync(TokenModel tokenModel,
        SendCommandDto sendCommandDto);

    Task<BaseResponse<ResponseModel<TerminalItemResponse>>> GetCommandsHistoryAsync(TokenModel tokenModel,
        int terminalId);
}