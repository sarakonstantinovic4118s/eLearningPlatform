'use-strict';

const mainView = document.querySelectorAll('.table-scroll');
const navigation = document.querySelector('.sidebar-menu ul');
const schools = document.querySelector('.schools');
const courses = document.querySelector('.courses');
const users = document.querySelector('.table-scroll.users');
const categories = document.querySelector('.table-scroll.category');
const insertFormsContainer = document.querySelector('.forms-container');
const title = document.querySelector('.dash-title');

const school = document.querySelector('.insert-form.school');
const course = document.querySelector('.insert-form.course');
const user = document.querySelector('.insert-form.user');
const category = document.querySelector('.insert-form.category');


// EDIT FORM CATEGORY
const editCategoryContainer = document.querySelector('.table-scroll.category');
const editFormCategory = document.querySelector('.edit-form.category');

// EDIT FORM SCHOOL
const editSChoolContainer = document.querySelector('.table-scroll.schools');
const editFormSchool = document.querySelector('.edit-form.school');

// EDIT FORM COURSE
const editCourseContainer = document.querySelector('.table-scroll.courses');
const editFormCourse = document.querySelector('.edit-form.course');

// EDIT FORM USERS
const editUserContainer = document.querySelector('.table-scroll.users');
const editFormUser = document.querySelector('.edit-form.user');

// OVERLAY
const overlay = document.querySelector('.edit-overlay');
const closeBtn = document.querySelectorAll('.closeBtn');


// Event listeners
navigation.addEventListener('click', displayContent);
insertFormsContainer.addEventListener('click', displayForm);

// EDIT FORM  SHOW
// CATEGORY
//editCategoryContainer.addEventListener('click', function (e) {
//    showEditForm(e, 'category', editFormCategory);
//});
// SCHOOL
//editSChoolContainer.addEventListener('click', function (e) {
//    showEditForm(e, 'school', editFormSchool);
//});
// COURSE
//editCourseContainer.addEventListener('click', function (e) {
//    showEditForm(e, 'course', editFormCourse);
//});
// USER
//editUserContainer.addEventListener('click', function (e) {
//    showEditForm(e, 'user', editFormUser);
//});

closeBtn.forEach(el => el.addEventListener('click', closeOverlay));

//function showEditForm(e, type, formContainer) {
//    if (e.target.closest(`.edit-btn.${type}`)) {
//        overlay.classList.toggle('hide');
//        formContainer.classList.toggle('hide');
//    }
//}

function helperCloseOverlay(formContainer) {
    if (!formContainer.classList.contains('hide')) {
        overlay.classList.add('hide');
        formContainer.classList.add('hide');
    }
}

// CLOSE OVERLAY
function closeOverlay(e) {
    helperCloseOverlay(editFormSchool);
    helperCloseOverlay(editFormCategory);
    helperCloseOverlay(editFormCourse);
    helperCloseOverlay(editFormUser);
}

// function helperDisplayForm(e,option){
//     console.log(e.target.closest('a'))
//     console.log(option)
//     if(e.target.closest('a').dataset.insert === `${'option'}`){
//         hideForms();
//         option.classList.toggle('hide');
//     }
// }

// INSERT FORMS DISPLAY
function displayForm(e) {
    // helperDisplayForm(e,category);
    if (e.target.closest('a').dataset.insert === 'category') {
        hideForms();
        category.classList.toggle('hide');
    }
    if (e.target.closest('a').dataset.insert === 'school') {
        hideForms();
        school.classList.toggle('hide');
    }
    if (e.target.closest('a').dataset.insert === 'course') {
        hideForms();
        course.classList.toggle('hide');
    }
    if (e.target.closest('a').dataset.insert === 'user') {
        hideForms();
        user.classList.toggle('hide');
    }
}
// MAIN CONTENT DISPLAY
function displayContent(e) {
    if (e.target.closest('li').dataset.item === 'category') {
        title.innerHTML = "CATEGORIES";
        hideContent();
        categories.classList.toggle('hidden');
    }
    if (e.target.closest('li').dataset.item === 'schools') {
        title.innerHTML = "SCHOOLS";
        hideContent();
        schools.classList.toggle('hidden');
    }
    if (e.target.closest('li').dataset.item === 'schools') {
        title.innerHTML = "SCHOOLS";
        hideContent();
        schools.classList.toggle('hidden');
    }
    if (e.target.closest('li').dataset.item === 'courses') {
        title.innerHTML = "COURSES";
        hideContent();
        courses.classList.toggle('hidden');
    }
    if (e.target.closest('li').dataset.item === 'users') {
        title.innerHTML = "USERS";
        hideContent();
        users.classList.toggle('hidden');
    }
    if (e.target.closest('li').dataset.item === 'insert') {
        title.innerHTML = "INSERT FORMS";
        hideContent();
        insertFormsContainer.classList.toggle('hidden');
    }
}

function hideForms() {
    document.querySelectorAll('.insert-form').forEach(el => el.classList.add('hide'));
}

function hideContent() {
    insertFormsContainer.classList.add('hidden')
    mainView.forEach(el => el.classList.add('hidden'));
}