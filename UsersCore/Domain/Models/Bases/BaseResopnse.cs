namespace UserCore.Models
{
    /// <summary>
    /// BaseReponse Dto Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Result code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Response message
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Response result
        /// </summary>
        public T? Result { get; set; }
    }
}
