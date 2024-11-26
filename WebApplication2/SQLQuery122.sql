SELECT 
    s.student_id, 
    s.name,    -- Giả sử bảng student có trường student_name
    c.course_name
FROM 
    student s
LEFT JOIN 
    student_courses sc ON s.student_id = sc.student_id
LEFT JOIN 
    courses c ON sc.course_id = c.course_id
WHERE 
    s.student_id = 2;