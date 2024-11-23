const studentBtn = document.getElementById('studentBtn');
const teacherBtn = document.getElementById('teacherBtn');
const adminBtn = document.getElementById('adminBtn');
const studentForm = document.getElementById('studentForm');
const teacherForm = document.getElementById('teacherForm');
const adminForm = document.getElementById('adminForm');

// Sửa lại đoạn code để bám sự kiện vào tất cả các nút Login
document.querySelectorAll('.login-btn').forEach(button => {
    button.addEventListener('click', (e) => {
        e.preventDefault();  // Ngừng hành động mặc định của nút (gửi form)

        console.log('Login button clicked');

        // Kiểm tra xem tab Admin đã được chọn chưa
        if (adminBtn.classList.contains('active')) {
            // Chuyển hướng tới trang AdminPage nếu tab Admin được chọn
            window.location.href = '/Admin/AdminPage';  // Đảm bảo đúng đường dẫn đến trang AdminPage
        } else {
            alert('Please select the Admin tab before logging in.');
        }
    });
});

studentBtn.addEventListener('click', () => {
    studentBtn.classList.add('active');
    teacherBtn.classList.remove('active');
    adminBtn.classList.remove('active');
    studentForm.classList.add('active');
    teacherForm.classList.remove('active');
    adminForm.classList.remove('active');
});

teacherBtn.addEventListener('click', () => {
    teacherBtn.classList.add('active');
    studentBtn.classList.remove('active');
    adminBtn.classList.remove('active');
    teacherForm.classList.add('active');
    studentForm.classList.remove('active');
    adminForm.classList.remove('active');
});

adminBtn.addEventListener('click', () => {
    adminBtn.classList.add('active');
    studentBtn.classList.remove('active');
    teacherBtn.classList.remove('active');
    adminForm.classList.add('active');
    studentForm.classList.remove('active');
    teacherForm.classList.remove('active');
});
