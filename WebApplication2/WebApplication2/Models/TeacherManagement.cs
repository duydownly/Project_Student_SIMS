namespace WebApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("teacher")] // Tên bảng viết thường
    public class TeacherManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Khóa chính tự tăng
        public int teacher_id { get; set; }

        [Required]
        [EmailAddress] // Kiểm tra định dạng email
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)] // Giới hạn độ dài mật khẩu
        public string password { get; set; }

        [Required]
        [MaxLength(200)] // Giới hạn độ dài tên
        public string name { get; set; }

        [Phone] // Kiểm tra định dạng số điện thoại
        [MaxLength(15)]
        public string phone { get; set; }
    }
}
