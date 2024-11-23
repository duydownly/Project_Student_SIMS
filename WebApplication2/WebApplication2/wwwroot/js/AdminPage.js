function changeContent(menuItem) {
    const contentTitle = document.getElementById("content-title");
    const contentDescription = document.getElementById("content-description");

    contentTitle.textContent = menuItem;

    if (menuItem === "Home") {
        contentDescription.textContent = "Welcome to the Home page!";
    } else if (menuItem === "Student") {
        contentDescription.textContent = "Manage student information here.";
    } else if (menuItem === "Course") {
        contentDescription.textContent = "View and manage courses.";
    } else if (menuItem === "Teacher") {
        contentDescription.textContent = "Access teacher details.";
    } else if (menuItem === "Enroll") {
        contentDescription.textContent = "Handle enrollments here.";
    } else if (menuItem === "Logout") {
        contentDescription.textContent = "You have logged out.";
    }
}
