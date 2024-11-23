const searchBtn = document.getElementById('searchBtn');
const addBtn = document.getElementById('addBtn');
const editBtn = document.getElementById('editBtn');
const searchForm = document.getElementById('searchForm');
const addForm = document.getElementById('addForm');
const editForm = document.getElementById('editForm');

// Event handler for the buttons
document.querySelectorAll('.form-switch button').forEach(button => {
    button.addEventListener('click', () => {
        document.querySelectorAll('.form-switch button').forEach(b => b.classList.remove('active'));
        button.classList.add('active');

        // Show corresponding form
        if (button.id === 'searchBtn') {
            searchForm.classList.add('active');
            addForm.classList.remove('active');
            editForm.classList.remove('active');
        } else if (button.id === 'addBtn') {
            addForm.classList.add('active');
            searchForm.classList.remove('active');
            editForm.classList.remove('active');
        } else if (button.id === 'editBtn') {
            editForm.classList.add('active');
            searchForm.classList.remove('active');
            addForm.classList.remove('active');
        }
    });
});
