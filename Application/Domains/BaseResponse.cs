namespace Application.Domains;

/// <summary>
/// Базовая сущность
/// </summary>
public class BaseResponse
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
}