using E_Learning.Core.DataTransferObjects;

namespace E_Learning.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UserDTOIdentity?> LoginAsync(LogInDto dto);
        public Task<UserDTOIdentity> RegisterAsync(RegisterDto dto);
    }
}
