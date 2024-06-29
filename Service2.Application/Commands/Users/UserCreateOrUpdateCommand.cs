using MediatR;

namespace Service2.Application.Commands.Users
{
    public class UserCreateOrUpdateCommand : IRequest<bool>
    {
        public UserCreateOrUpdateCommand(int id, string name, string middleName, string surname, string email)
        {
            Id = id;
            Name = name;
            MiddleName = middleName;
            Surname = surname;
            Email = email;
        }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id { get; init; }

        /// <summary> 
        /// Имя.
        /// </summary>
        public string Name { get; init; }

        /// <summary> 
        /// Отчество.
        /// </summary>
        public string? MiddleName { get; init; }

        /// <summary> 
        /// Фамилия.
        /// </summary>
        public string Surname { get; init; }

        public string Email { get; init; }
    }
}
