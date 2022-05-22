using VendistaTestTask.Domain.Models;

namespace VendistaTestTask.Models;

public class IndexViewModel
{
    public ResponseModel<TypesItemModel>? Types { get; set; }
    public ResponseModel<TerminalItemResponse>? History { get; set; }
    public string? ErrorMessage { get; set; }
}