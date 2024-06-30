namespace Service2.Application.Queries.Users.GetUsersFilter
{
    public class UserDTO
    {
        public int Id { get; set; }

        /// <summary> 
        /// Имя 
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary> 
        /// Отчество 
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary> 
        /// Фамилия 
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
