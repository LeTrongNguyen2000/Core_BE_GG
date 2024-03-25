namespace UserCore.Models
{
    /// <summary>
    /// Paging Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingModel<T>
    {
        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Total records
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// List Items
        /// </summary>
        public IEnumerable<T>? Items { get; set; }
    }
}
