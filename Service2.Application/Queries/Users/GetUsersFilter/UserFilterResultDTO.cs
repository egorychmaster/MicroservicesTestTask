namespace Service2.Application.Queries.Users.GetUsersFilter
{
    public class UserFilterResultDTO
    {
        /// <summary>
        /// Элементы
        /// </summary>
        public IEnumerable<UserDTO> Items { get; set; }

        /// <summary>
        /// Пропущено элементов
        /// </summary>
        public int Skipped { get; set; }

        /// <summary>
        /// Запрошено элементов
        /// </summary>
        public int Taken { get; set; }

        /// <summary>
        /// Всего элементов
        /// </summary>
        public int TotalCount { get; set; }
    }
}
