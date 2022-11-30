namespace EcoDriver.API.Shared.Services.Communication;

public abstract class BaseResponse<T>
{
    public BaseResponse(string message)
    {
        Message = message;
        Success = false;
        Resource = default;
    }
    
    public BaseResponse(T resource)
    {
        Resource = resource;
        Success = true;
        Message = string.Empty;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
}