using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<StudentManagement> StudentManagement { get; set; } = default!;
        public DbSet<CourseManagement> CourseManagement { get; set; } = default!;
        public DbSet<TeacherManagement> TeacherManagement { get; set; } = default!;
        public DbSet<Student_CoursesManagement> Student_CoursesManagement { get; set; } = default!;
        public DbSet<Teacher_CoursesManagement> Teacher_CoursesManagement { get; set; } = default!;


        // Phương thức OnModelCreating để cấu hình mối quan hệ giữa các bảng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đảm bảo bảng Student_CoursesManagement có tên là 'student_courses'
            modelBuilder.Entity<Student_CoursesManagement>()
                .ToTable("student_courses");

            // Bạn cũng có thể cấu hình các mối quan hệ khóa ngoại tại đây nếu cần
            modelBuilder.Entity<Student_CoursesManagement>()
                .HasOne(sc => sc.student)
                .WithMany()
                .HasForeignKey(sc => sc.student_id);

            modelBuilder.Entity<Student_CoursesManagement>()
                .HasOne(sc => sc.course)
                .WithMany()
                .HasForeignKey(sc => sc.course_id);
        }
    }
}