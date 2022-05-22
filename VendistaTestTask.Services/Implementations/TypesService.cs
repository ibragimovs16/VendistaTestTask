using System.Net;
using System.Net.Http.Json;
using VendistaTestTask.Domain.Models;
using VendistaTestTask.Domain.Response;
using VendistaTestTask.Services.Abstractions;

namespace VendistaTestTask.Services.Implementations;

public class TypesService : ITypesService
{
    private const string BaseUri = "http://178.57.218.210:198/commands/types";
    private readonly HttpClient _httpClient = new();

    public async Task<BaseResponse<ResponseModel<TypesItemModel>>> GetTypesAsync(TokenModel tokenModel)
    {
        var builder = new UriBuilder(BaseUri)
        {
            Query = $"token={tokenModel.Token}"
        };
        var response = await _httpClient.GetAsync(builder.ToString());
        if (response.StatusCode == HttpStatusCode.OK)
            return new BaseResponse<ResponseModel<TypesItemModel>>
            {
                StatusCode = response.StatusCode,
                Description = "Успешно.",
                Data = await response.Content.ReadFromJsonAsync<ResponseModel<TypesItemModel>>()
            };

        var responseJson = await response.Content.ReadFromJsonAsync<ErrorModel>();
        return new BaseResponse<ResponseModel<TypesItemModel>>
        {
            StatusCode = response.StatusCode,
            Description = responseJson!.Error
        };
    }

    public async Task<BaseResponse<TypesItemModel>> GetTypesItemByIdAsync(TokenModel tokenModel, int id)
    {
        var builder = new UriBuilder(BaseUri)
        {
            Query = $"token={tokenModel.Token}"
        };
        var response = await _httpClient.GetAsync(builder.ToString());
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var responseJson = await response.Content.ReadFromJsonAsync<ResponseModel<TypesItemModel>>();
            var currentItem = responseJson?.Items?
                .Where(item => item.Id == id);
            return new BaseResponse<TypesItemModel>
            {
                StatusCode = response.StatusCode,
                Description = "Успешно.",
                Data = currentItem?.First()
            };
        }

        return new BaseResponse<TypesItemModel>
        {
            StatusCode = response.StatusCode,
            Description = (await response.Content.ReadFromJsonAsync<ErrorModel>())!.Error
        };
    }
}