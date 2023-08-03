const API_URL = `http://localhost:3030/jsonstore/tasks`;

const courseTypes = ["Long", "Medium", "Short"];

const loadButtonElement = document.querySelector("#load-course");
const list = document.querySelector("#list");
const addButtonElementGlobal = document.querySelector("#add-course");
const editButtonElementGlobal = document.querySelector("#edit-course");

const courseTitleElement = document.querySelector("#course-name");
const courseTypeElement = document.querySelector("#course-type");
const courseDescriptionElement = document.querySelector("#description");
const courseTeacherElement = document.querySelector("#teacher-name");

loadButtonElement.addEventListener("click", loadCourses);
addButtonElementGlobal.addEventListener("click", addCourse);
editButtonElementGlobal.addEventListener("click", editCourse);

let currentCourseId = "";

async function editCourse(e) {
  e.preventDefault();

  const title = courseTitleElement.value;
  const type = courseTypeElement.value;
  const description = courseDescriptionElement.value;
  const teacher = courseTeacherElement.value;

  if (!courseTypes.includes(type)) {
    return;
  }

  const course = {
    _id: currentCourseId,
    title,
    type,
    description,
    teacher,
  };

  await fetch(`${API_URL}/${currentCourseId}`, {
    method: "PUT",
    body: JSON.stringify(course),
  });

  clearForm();

  addButtonElementGlobal.disabled = false;
  editButtonElementGlobal.disabled = true;

  await loadCourses();
}

async function addCourse(e) {
  e.preventDefault();
  const title = courseTitleElement.value;
  const type = courseTypeElement.value;
  const description = courseDescriptionElement.value;
  const teacher = courseTeacherElement.value;

  if (!courseTypes.includes(type)) {
    return;
  }

  const course = {
    title,
    type,
    description,
    teacher,
  };

  await fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(course),
  });

  clearForm();

  await loadCourses();
}

async function loadCourses() {
  const response = await fetch(API_URL);
  const data = await response.json();

  list.innerHTML = "";

  const courses = Object.values(data);
  courses.forEach((course) => {
    const courseElement = renderCourse(course);
    courseElement.setAttribute("data-course-id", course._id);
  });
}

function renderCourse(course) {
  const container = createElement("div", null, ["container"], null, list);
  createElement("h2", course.title, null, null, container);
  createElement("h3", course.teacher, null, null, container);
  createElement("h3", course.type, null, null, container);
  createElement("h4", course.description, null, null, container);
  const editButtonElement = createElement(
    "button",
    "Edit Course",
    ["edit-btn"],
    null,
    container
  );

  editButtonElement.addEventListener("click", (e) => {
    courseTitleElement.value = course.title;
    courseTypeElement.value = course.type;
    courseDescriptionElement.value = course.description;
    courseTeacherElement.value = course.teacher;

    currentCourseId = container.getAttribute("data-course-id");
    container.remove();

    addButtonElementGlobal.disabled = true;
    editButtonElementGlobal.disabled = false;
  });
  const finishButtonElement = createElement(
    "button",
    "Finish Course",
    ["finish-btn"],
    null,
    container
  );

  finishButtonElement.addEventListener("click", async (e) => {
    await fetch(`${API_URL}/${course._id}`, {
      method: "DELETE",
    });

    await loadCourses();
  });

  return container;
}

function clearForm() {
  courseTypeElement.value = "";
  courseTitleElement.value = "";
  courseDescriptionElement.value = "";
  courseTeacherElement.value = "";
}

function createElement(type, textContent, classes, id, parent) {
  const element = document.createElement(type);

  if (textContent) {
    element.textContent = textContent;
  }

  if (classes && classes.length > 0) {
    element.classList.add(...classes);
  }

  if (id) {
    element.setAttribute("id", id);
  }

  if (parent) {
    parent.appendChild(element);
  }

  return element;
}
