namespace WebApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("teacher_courses")] // Bảng teacher_courses trong cơ sở dữ liệu
    public class Teacher_CoursesManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] // Tên cột khớp với cơ sở dữ liệu
        public int id { get; set; }

        [ForeignKey("teacher")]
        [Column("teacher_id")] // Tên cột khớp với cơ sở dữ liệu
        public int teacher_id { get; set; }

        [ForeignKey("course")]
        [Column("course_id")] // Tên cột khớp với cơ sở dữ liệu
        public int course_id { get; set; }

        // Điều hướng tới bảng TeacherManagement (khóa ngoại teacher_id)
        public virtual TeacherManagement teacher { get; set; }

        // Điều hướng tới bảng CourseManagement (khóa ngoại course_id)
        public virtual CourseManagement course { get; set; }
    }
}
