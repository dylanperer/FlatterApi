namespace Application.Dtos;

public struct AuthenticationDto 
{
    public int UserId;
    public string Email;
    public string Token;
    public string RefreshToken;
}