namespace Service1.Api.Models
{
    public class UserModel
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary> 
        /// Имя 
        /// </summary>
        public string Name { get; set; }

        /// <summary> 
        /// Отчество 
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary> 
        /// Фамилия 
        /// </summary>
        public string Surname { get; set; }

        public string Email { get; set; }
    }
}
