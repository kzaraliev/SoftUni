const API_URL = `http://localhost:3030/jsonstore/tasks`;
const list = document.querySelector("#list");

const loadVacations = document.querySelector("#load-vacations");
const addButtonElementGlobal = document.querySelector("#add-vacation");
const editVacationElementGlobal = document.querySelector("#edit-vacation");

loadVacations.addEventListener("click", loadItems);
addButtonElementGlobal.addEventListener("click", addVacation);
editVacationElementGlobal.addEventListener("click", editVacation);

const vacationNameElement = document.querySelector("#name");
const vacationDaysElement = document.querySelector("#num-days");
const vacationDateElement = document.querySelector("#from-date");

let currentVacationId = "";

async function editVacation(e) {
  e.preventDefault();

  const name = vacationNameElement.value;
  const days = vacationDaysElement.value;
  const date = vacationDateElement.value;

  const vacationSend = {
    _id: currentVacationId,
    name,
    days,
    date,
  };

  await fetch(`${API_URL}/${currentVacationId}`, {
    method: "PUT",
    body: JSON.stringify(vacationSend),
  });

  clearForm();

  addButtonElementGlobal.disabled = false;
  editVacationElementGlobal.disabled = true;

  await loadItems();
}

async function addVacation(e) {
  e.preventDefault();
  const name = vacationNameElement.value;
  const days = vacationDaysElement.value;
  const date = vacationDateElement.value;

  if (
    !vacationNameElement.value ||
    !vacationDaysElement.value ||
    !vacationDateElement.value
  ) {
    return;
  }

  const vacation = {
    name,
    days,
    date,
  };

  await fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(vacation),
  });

  clearForm();

  await loadItems();
}

async function loadItems() {
  const response = await fetch(API_URL);
  const data = await response.json();

  list.innerHTML = "";

  const vacations = Object.values(data);
  vacations.forEach((vacation) => {
    const vacationElement = renderCourse(vacation);
    vacationElement.setAttribute("data-vacation-id", vacation._id);
  });
}

function renderCourse(vacation) {
  const container = createElement("div", null, ["container"], null, list);
  createElement("h2", vacation.name, null, null, container);
  createElement("h3", vacation.date, null, null, container);
  createElement("h3", vacation.days, null, null, container);

  const changeButtonElement = createElement(
    "button",
    "Change",
    ["change-btn"],
    null,
    container
  );

  const doneButtonElement = createElement(
    "button",
    "Done",
    ["done-btn"],
    null,
    container
  );

  changeButtonElement.addEventListener("click", (e) => {
    vacationNameElement.value = vacation.name;
    vacationDaysElement.value = vacation.days;
    vacationDateElement.value = vacation.date;

    currentVacationId = container.getAttribute("data-vacation-id");
    container.remove();

    addButtonElementGlobal.disabled = true;
    editVacationElementGlobal.disabled = false;
  });

  doneButtonElement.addEventListener("click", async (e) => {
    await fetch(`${API_URL}/${vacation._id}`, {
      method: "DELETE",
    });

    await loadItems(e);
  });

  return container;
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

function clearForm() {
  vacationNameElement.value = "";
  vacationDaysElement.value = "";
  vacationDateElement.value = "";
}
