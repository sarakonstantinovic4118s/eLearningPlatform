'use-strict';

const mainView = document.querySelectorAll('.table-scroll');
const navigation = document.querySelector('.sidebar-menu ul');
const schools = document.querySelector('.schools');
const courses = document.querySelector('.courses');
const users = document.querySelector('.table-scroll.users');
const insertFormsContainer = document.querySelector('.forms-container');
const title = document.querySelector('.dash-title');

const school = document.querySelector('.insert-form.school');
const course = document.querySelector('.insert-form.course');
const user = document.querySelector('.insert-form.user');


// Event listeners
navigation.addEventListener('click',displayContent);
insertFormsContainer.addEventListener('click',displayForm);


function displayForm(e){
    if(e.target.closest('a').dataset.insert === 'school'){
        hideForms();
        school.classList.toggle('hide');
    }
    if(e.target.closest('a').dataset.insert === 'course'){
        hideForms();
        course.classList.toggle('hide');
    }
    if(e.target.closest('a').dataset.insert === 'user'){
        hideForms();
        user.classList.toggle('hide');
    }
}

function displayContent(e){

    if(e.target.closest('li').dataset.item === 'schools'){
        title.innerHTML = "SCHOOLS";
        hideContent();
        schools.classList.toggle('hidden');
    }
    if(e.target.closest('li').dataset.item === 'courses'){
        title.innerHTML = "COURSES";
        hideContent();
        courses.classList.toggle('hidden');
    }
    if(e.target.closest('li').dataset.item === 'users'){
        title.innerHTML = "USERS";
        hideContent();
        users.classList.toggle('hidden');
    }
    if(e.target.closest('li').dataset.item === 'insert'){
        title.innerHTML = "INSERT FORMS";
        hideContent();
        insertFormsContainer.classList.toggle('hidden');
    }
}

function hideForms(){
    document.querySelectorAll('.insert-form').forEach(el => el.classList.add('hide'));
  
}

function hideContent(){
    insertFormsContainer.classList.add('hidden')
    mainView.forEach(el => el.classList.add('hidden'));
}