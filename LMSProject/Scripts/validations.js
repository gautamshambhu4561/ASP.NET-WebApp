function showError(message) {
    const error = document.getElementById("errorMessage");
    if (error) {
        error.innerText = message;
        error.classList.remove("d-none");
    }
}

function validateLogin() {
    const email = document.getElementById("txtEmail")?.value.trim();
    const password = document.getElementById("txtPassword")?.value;
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!email || !/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email)) {
        showError("Please enter a valid email address.");
        return false;
    }
    if (!password) {
        showError("Please enter your password.");
        return false;
    }
    return true;
}

function validateRegister() {
    const name = document.getElementById("txtName")?.value.trim();
    const email = document.getElementById("txtEmail")?.value.trim();
    const password = document.getElementById("txtPassword")?.value;
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!name) {
        showError("Please enter your name.");
        return false;
    }
    if (!email || !/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email)) {
        showError("Please enter a valid email address.");
        return false;
    }
    if (!password || password.length < 6) {
        showError("Password must be at least 6 characters long.");
        return false;
    }
    return true;
}

function validateCourse() {
    const title = document.getElementById("txtTitle")?.value.trim();
    const description = document.getElementById("txtDescription")?.value.trim();
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!title) {
        showError("Please enter a course title.");
        return false;
    }
    if (!description) {
        showError("Please enter a course description.");
        return false;
    }
    return true;
}

function validateMaterial() {
    const title = document.getElementById("txtTitle")?.value.trim();
    const file = document.getElementById("fuMaterial")?.files[0];
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!title) {
        showError("Please enter a material title.");
        return false;
    }
    if (!file) {
        showError("Please select a file to upload.");
        return false;
    }
    return true;
}

function validateSubmission() {
    const file = document.getElementById("fuSubmission")?.files[0];
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!file) {
        showError("Please select a file to submit.");
        return false;
    }
    return true;
}

function validateProfile() {
    const name = document.getElementById("txtName")?.value.trim();
    const email = document.getElementById("txtEmail")?.value.trim();
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!name) {
        showError("Please enter your name.");
        return false;
    }
    if (!email || !/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email)) {
        showError("Please enter a valid email address.");
        return false;
    }
    return true;
}

function validateAnnouncement() {
    const title = document.getElementById("txtTitle")?.value.trim();
    const content = document.getElementById("txtContent")?.value.trim();
    const error = document.getElementById("errorMessage");

    if (error) {
        error.classList.add("d-none");
        error.innerText = "";
    }

    if (!title) {
        showError("Please enter an announcement title.");
        return false;
    }
    if (!content) {
        showError("Please enter announcement content.");
        return false;
    }
    return true;
}