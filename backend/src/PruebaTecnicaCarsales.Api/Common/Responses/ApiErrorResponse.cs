namespace PruebaTecnicaCarsales.Api.Common.Responses;

public class ApiErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public string? Detail { get; set; }
}
