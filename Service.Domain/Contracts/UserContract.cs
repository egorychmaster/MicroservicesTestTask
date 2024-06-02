namespace Service.Domain.Contracts
{
    public record UserContract
    {
        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; init; }

        /// <summary> 
        /// Имя 
        /// </summary>
        public string Name { get; init; }

        /// <summary> 
        /// Отчество 
        /// </summary>
        public string? MiddleName { get; init; }

        /// <summary> 
        /// Фамилия 
        /// </summary>
        public string Surname { get; init; }

        public string Email { get; init; }
    }
}
