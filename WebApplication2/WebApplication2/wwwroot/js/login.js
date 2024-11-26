const studentBtn = document.getElementById('studentBtn');
const teacherBtn = document.getElementById('teacherBtn');
const adminBtn = document.getElementById('adminBtn');
const studentForm = document.getElementById('studentForm');
const teacherForm = document.getElementById('teacherForm');
const adminForm = document.getElementById('adminForm');

// Event listener for all login buttons
document.querySelectorAll('.login-btn').forEach(button => {
    button.addEventListener('click', (e) => {
        e.preventDefault();  // Ngừng hành động mặc định của nút (gửi form)

        console.log('Login button clicked');

        // Get the email and password inputs
        const emailInput = document.querySelector('#email');
        const passwordInput = document.querySelector('#password');

        // Check if both email and password fields are not empty
        if (!emailInput.value || !passwordInput.value) {
            alert('Please enter both email and password.');
            return;
        }

        // If Admin tab is selected, perform admin login check
        if (adminBtn.classList.contains('active')) {
            // Validate email and password (you can adjust this check to your needs, for example by calling an API)
            if (emailInput.value === '1' && passwordInput.value === '1') {
                // Redirect to Admin page if valid
                window.location.href = '/Admin/AdminPage';  // Update with the correct path for AdminPage
            } else {
                // If the credentials are wrong, show an error message
                alert('Incorrect email or password for Admin.');
            }
        } else {
            alert('Please select the Admin tab before logging in.');
        }
    });
});

// Switch between tabs and show appropriate forms
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
