namespace Service2.Api.Application.Models
{
    public class UserFilterResult
    {
        /// <summary>
        /// Элементы
        /// </summary>
        public IEnumerable<UserModel> Items { get; set; }

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
