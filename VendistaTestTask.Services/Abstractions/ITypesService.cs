using VendistaTestTask.Domain.Models;
using VendistaTestTask.Domain.Response;

namespace VendistaTestTask.Services.Abstractions;

public interface ITypesService
{
    Task<BaseResponse<ResponseModel<TypesItemModel>>> GetTypesAsync(TokenModel token);
    Task<BaseResponse<TypesItemModel>> GetTypesItemByIdAsync(TokenModel tokenModel, int id);
}