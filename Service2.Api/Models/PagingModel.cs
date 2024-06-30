namespace Service2.Api.Models
{
    public class PagingModel
    {
        /// <summary>
        /// Пропустить элементов.
        /// </summary>
        public int Skip { get; set; } = 0;

        /// <summary>
        /// Запросить элементов.
        /// </summary>
        public int Take { get; set; } = 5;
    }
}
