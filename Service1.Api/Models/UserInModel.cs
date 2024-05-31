namespace Service1.Api.Models
{
    public class UserInModel
    {
        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }

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
