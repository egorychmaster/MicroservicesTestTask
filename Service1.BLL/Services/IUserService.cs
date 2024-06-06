using Service1.BLL.DTO;

namespace Service1.BLL.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Отправить в шину пользователя.
        /// </summary>
        Task SendToBusAsync(UserDTO user);
    }
}
