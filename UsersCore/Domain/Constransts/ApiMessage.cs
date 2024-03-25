namespace UserCore.Constransts
{
    public class ApiMessage
    {
        /// <summary>
        /// Get Ok
        /// </summary>
        public const string GetOk = "Get Ok";

        public const string Created = "Tạo thành công";

        public const string Updated = "Cập nhật thành công";

        public const string Added = "Thêm thành công";

        public const string Deleted = "Xóa thành công";

        public const string InvalidFileMsg = "Kiểu file không hợp lệ.";

        /// <summary>
        /// Kích thước file
        /// </summary>
        public const string FileSizeMsg = "Kích thước file nhỏ hơn {0} MB.";

        public const string NotExisted = "{0} không tồn tại hoặc không đúng.";

        /// <summary>
        /// Không thành công
        /// </summary>
        public const string CreatedError = "Tạo không thành công. Có lỗi xảy ra trong quá trình tạo";

        public const string UpdatedError = "Cập nhật không thành công. Có lỗi xảy ra trong quá trình cập nhật";

        public const string CannotDelete = "Không thể xóa {0} này. Bạn không có quyền hoặc {0} không tồn tại.";

        public const string DeletedError = "Xóa không thành công. Có lỗi xảy ra trong quá trình xóa";
    }
}
