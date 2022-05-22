namespace VendistaTestTask.Domain.DTOs;

public class SendCommandDto
{
    public int CommandId { get; set; }
    public int Parameter1 { get; set; }
    public int Parameter2 { get; set; }
    public int Parameter3 { get; set; }
    public int Parameter4 { get; set; }
    public string? StrParameter1 { get; set; }
    public string? StrParameter2 { get; set; }
    public int TerminalId { get; set; }
}