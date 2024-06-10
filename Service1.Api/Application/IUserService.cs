using Service1.Api.Application.DTOs;

namespace Service1.Api.Application
{
    public interface IUserService
    {
        /// <summary>
        /// Отправить в шину пользователя.
        /// </summary>
        Task SendToBusAsync(UserDTO user);
    }
}
