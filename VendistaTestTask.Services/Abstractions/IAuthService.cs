using VendistaTestTask.Domain.DTOs;
using VendistaTestTask.Domain.Models;
using VendistaTestTask.Domain.Response;

namespace VendistaTestTask.Services.Abstractions;

public interface IAuthService
{
    Task<BaseResponse<TokenModel>> GetTokenAsync(UserDto user);
}