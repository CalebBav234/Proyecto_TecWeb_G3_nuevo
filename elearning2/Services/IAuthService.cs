using elearning2.Models.DTOS;

namespace elearning2.Services
{
    public interface IAuthService
    {
        Task<(bool ok, LoginResponse? response)> LoginAsync(LoginDto dto);
        Task<string> RegisterAsync(RegisterDto dto);
        Task<(bool ok, LoginResponse? response)> RefreshAsync(RefreshRequestDto dto);
    }
}
