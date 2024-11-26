namespace WebApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("student_courses")] // Bảng Student_courses trong cơ sở dữ liệu
    public class Student_CoursesManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] // Tên cột khớp với cơ sở dữ liệu
        public int id { get; set; }

        [ForeignKey("student")]
        [Column("student_id")] // Tên cột khớp với cơ sở dữ liệu
        public int student_id { get; set; }

        [ForeignKey("course")]
        [Column("course_id")] // Tên cột khớp với cơ sở dữ liệu
        public int course_id { get; set; }

        // Điều hướng tới bảng StudentManagement (khóa ngoại Student_id)
        public virtual StudentManagement student { get; set; }

        // Điều hướng tới bảng CourseManagement (khóa ngoại course_id)
        public virtual CourseManagement course { get; set; }
    }
}
