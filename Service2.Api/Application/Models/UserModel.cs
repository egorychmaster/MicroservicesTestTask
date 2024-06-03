namespace Service2.Api.Application.Models
{
    public class UserModel
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
