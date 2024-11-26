namespace WebApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("courses")] // Specify the table name as 'course' in the database
    public class CourseManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Primary key with auto-increment
        public int course_id { get; set; }

        [Required]
        [MaxLength(255)] // Limit the length of the course name
        public string course_name { get; set; }

        public string description { get; set; } // Course description

        [Required]
        public decimal course_fee { get; set; } // Course fee

        // You can add other relevant fields for course details if needed
    }
}
