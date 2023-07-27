const API_URL = `http://localhost:3030/jsonstore/tasks`;

const loadAllBtn = document.querySelector("#load-button");
const addBtn = document.querySelector("#add-button");
const todoList = document.querySelector("#todo-list");

function attachEvents() {
  loadAllBtn.addEventListener("click", loadItems);
  addBtn.addEventListener("click", addItem);
}

function loadItems(event) {
  if (event) {
    event.preventDefault();
  }
  todoList.innerHTML = "";

  fetch(API_URL)
    .then((res) => res.json())
    .then((list) => {
      Object.values(list).forEach(({ name, _id }) => {
        const li = createElement("li", null, null, null, todoList);
        createElement("span", name, null, null, li);
        const removeBtn = createElement("button", "Remove", null, _id, li);
        const editBtn = createElement("button", "Edit", null, _id, li);

        removeBtn.addEventListener("click", removeElementList);
        editBtn.addEventListener("click", createEditInput);
      });
    });
}

function removeElementList(e) {
  const id = e.target.id;
  const headers = {
    method: "DELETE",
  };

  fetch(API_URL + `/${id}`, headers).then(() => loadItems());
}

function removeTaskHandler(e) {
  const id = e.target.id;
  const headers = {
    method: "DELETE",
  };

  fetch(API_URL + `/${id}`, headers).then(() => loadItems());
}

function editTaskHandler(e) {
  const inputVal = e.target.parentElement.querySelector("input").value;
  const headers = {
    method: "PATCH",
    body: JSON.stringify({ name: inputVal }),
  };

  fetch(API_URL + `/${e.target.id}`, headers).then(() => loadItems(e));
}

function createEditInput(e) {
  const parentElement = e.target.parentElement;
  e.target.parentElement.innerHTML = `
    <input value='${e.target.parentElement.querySelector("span").textContent}'/>
      <button id=${e.target.id} class="remove-button">Remove</button>
      <button id=${e.target.id} class="submit-button">Submit</button>`;
  parentElement
    .querySelector(".remove-button")
    .addEventListener("click", removeTaskHandler);
  parentElement
    .querySelector(".submit-button")
    .addEventListener("click", editTaskHandler);
}

function addItem(event) {
  event.preventDefault();
  const title = document.querySelector("#title");
  const headers = {
    method: "POST",
    body: JSON.stringify({ name: title.value }),
  };

  if (typeof title.value !== "string" || title.value.length <= 3) {
    return;
  }

  fetch(API_URL, headers).then(() => loadItems(event));
  title.value = "";
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

attachEvents();
