const API_URL = `http://localhost:3030/jsonstore/tasks`;

const loadBtn = document.querySelector("#load-history");
const addButtonElementGlobal = document.querySelector("#add-weather");
const editButtonElementGlobal = document.querySelector("#edit-weather");

const list = document.querySelector("#list");
const itemLocationElement = document.querySelector("#location");
const itemTemperatureElement = document.querySelector("#temperature");
const itemDateElement = document.querySelector("#date");

loadBtn.addEventListener("click", loadItems);
addButtonElementGlobal.addEventListener("click", addItem);
editButtonElementGlobal.addEventListener("click", changeItem);

let currentWeatherId = "";

async function changeItem(e) {
  e.preventDefault();

  const location = itemLocationElement.value;
  const temperature = itemTemperatureElement.value;
  const date = itemDateElement.value;

  const weatherSend = {
    _id: currentWeatherId,
    location,
    temperature,
    date,
  };

  await fetch(`${API_URL}/${currentWeatherId}`, {
    method: "PUT",
    body: JSON.stringify(weatherSend),
  });

  clearForm();

  addButtonElementGlobal.disabled = false;
  editButtonElementGlobal.disabled = true;

  await loadItems(e);
}

async function addItem(e) {
  e.preventDefault();
  const location = itemLocationElement.value;
  const temperature = itemTemperatureElement.value;
  const date = itemDateElement.value;

  if (
    !itemLocationElement.value ||
    !itemTemperatureElement.value ||
    !itemDateElement.value
  ) {
    return;
  }

  const itemSend = {
    location,
    temperature,
    date,
  };

  await fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(itemSend),
  });

  clearForm();

  await loadItems(e);
}

async function loadItems(e) {
  e.preventDefault();
  const response = await fetch(API_URL);
  const data = await response.json();

  list.innerHTML = "";

  const items = Object.values(data);
  items.forEach((item) => {
    const itemElement = renderItems(item);
    itemElement.setAttribute("data-item-id", item._id);
  });
}

function renderItems(item) {
  const container = createElement("div", null, ["container"], null, list);
  createElement("h2", item.location, null, null, container);
  createElement("h3", item.date, null, null, container);
  createElement("h3", item.temperature, null, "celsius", container);
  const buttonsContainer = createElement(
    "div",
    null,
    ["buttons-container"],
    null,
    container
  );
  const changeBtn = createElement(
    "button",
    "Change",
    ["change-btn"],
    null,
    buttonsContainer
  );
  const deleteBtn = createElement(
    "button",
    "Delete",
    ["delete-btn"],
    null,
    buttonsContainer
  );

  changeBtn.addEventListener("click", (e) => {
    itemLocationElement.value = item.location;
    itemTemperatureElement.value = item.temperature;
    itemDateElement.value = item.date;

    currentWeatherId = container.getAttribute("data-item-id");
    container.remove();

    addButtonElementGlobal.disabled = true;
    editButtonElementGlobal.disabled = false;
  });

  deleteBtn.addEventListener("click", async (e) => {
    await fetch(`${API_URL}/${item._id}`, {
      method: "DELETE",
    });

    await loadItems(e);
  });

  return container;
}

function clearForm() {
  itemLocationElement.value = "";
  itemTemperatureElement.value = "";
  itemDateElement.value = "";
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
