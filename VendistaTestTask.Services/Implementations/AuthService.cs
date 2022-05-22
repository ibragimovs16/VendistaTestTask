using System.Net;
using System.Net.Http.Json;
using VendistaTestTask.Domain.DTOs;
using VendistaTestTask.Domain.Models;
using VendistaTestTask.Domain.Response;
using VendistaTestTask.Services.Abstractions;

namespace VendistaTestTask.Services.Implementations;

public class AuthService : IAuthService
{
    private const string BaseUri = "http://178.57.218.210:198/token";
    private readonly HttpClient _httpClient = new();

    public async Task<BaseResponse<TokenModel>> GetTokenAsync(UserDto user)
    {
        var builder = new UriBuilder(BaseUri)
        {
            Query = $"login={user.Login}&password={user.Password}"
        };
        var response = await _httpClient.GetAsync(builder.ToString());

        if (response.StatusCode == HttpStatusCode.OK)
            return new BaseResponse<TokenModel>
            {
                StatusCode = response.StatusCode,
                Description = "Успешно.",
                Data = await response.Content.ReadFromJsonAsync<TokenModel>()
            };

        switch (response.StatusCode)
        {
            case HttpStatusCode.BadRequest:
                return new BaseResponse<TokenModel>
                {
                    StatusCode = response.StatusCode,
                    Description = "Некорректный запрос."
                };
            case HttpStatusCode.Unauthorized:
                var responseJson = await response.Content.ReadFromJsonAsync<ErrorModel>();
                return new BaseResponse<TokenModel>
                {
                    StatusCode = response.StatusCode,
                    Description = responseJson!.Error
                };
            default:
                return new BaseResponse<TokenModel>
                {
                    StatusCode = response.StatusCode,
                    Description = "Что-то пошло не так..."
                };
        }
    }
}