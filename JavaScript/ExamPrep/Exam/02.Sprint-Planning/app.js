window.addEventListener("load", solve);

function solve() {
  const tasks = {};

  const inputSelector = {
    title: document.querySelector("#title"),
    description: document.querySelector("#description"),
    label: document.querySelector("#label"),
    points: document.querySelector("#points"),
    assignee: document.querySelector("#assignee"),
  };

  const selectors = {
    hiddenTaskId: document.querySelector("#task-id"),
    createButton: document.querySelector("#create-task-btn"),
    deleteButton: document.querySelector("#delete-task-btn"),
    taskSection: document.querySelector("#tasks-section"),
    totalPoints: document.querySelector("#total-sprint-points"),
  };

  const icons = {
    Feature: "&#8865;",
    "Low Priority Bug": "&#9737;",
    "High Priority Bug": "&#9888;",
  };

  const labelClasses = {
    Feature: "feature",
    "Low Priority Bug": "low-priority",
    "High Priority Bug": "high-priority",
  };

  selectors.createButton.addEventListener("click", createTask);
  selectors.deleteButton.addEventListener("click", deleteTask);

  function createTask(e) {
    if (
      Object.values(inputSelector).some((selector) => selector.values === "")
    ) {
      return;
    }

    const task = {
      id: `task-${Object.values(tasks).length + 1}`,
      title: inputSelector.title.value,
      description: inputSelector.description.value,
      label: inputSelector.label.value,
      points: Number(inputSelector.points.value),
      assignee: inputSelector.assignee.value,
    };

    tasks[task.id] = task;

    const article = createElement("article", null, ["task-card"], task.id);
    createElement(
      "div",
      `${task.label} ${icons[task.label]}`,
      ["task-card-label", labelClasses[task.label]],
      null,
      article,
      true
    );
    createElement("h3", task.title, ["task-card-title"], null, article);
    createElement(
      "p",
      task.description,
      ["task-card-description"],
      null,
      article
    );
    createElement(
      "div",
      `Estimated at ${task.points} pts`,
      ["task-card-points"],
      null,
      article
    );
    createElement(
      "div",
      `Assigned to: ${task.assignee}`,
      ["task-card-assignee"],
      null,
      article
    );
    const taskActions = createElement(
      "div",
      null,
      ["task-card-actions"],
      null,
      article
    );
    const button = createElement("button", "Delete", [], null, taskActions);
    button.addEventListener("click", loadDeleteConfirm);
    selectors.taskSection.appendChild(article);

    calculateTotalPoints();
    Object.values(inputSelector).forEach((selector) => (selector.value = ""));
  }

  function deleteTask() {
    const taskId = selectors.hiddenTaskId.value;
    const taskElement = document.querySelector(`#${taskId}`);
    taskElement.remove();
    delete tasks[taskId];

    Object.values(inputSelector).forEach((selector) => {
      selector.value = "";
      selector.disabled = false;
    });

    selectors.createButton.disabled = false;
    selectors.deleteButton.disabled = true;

    calculateTotalPoints();
  }

  function createElement(type, textContent, classes, id, parent, useInnerHTML) {
    const element = document.createElement(type);

    if (useInnerHTML && textContent) {
      element.innerHTML = textContent;
    } else if (textContent) {
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

  function loadDeleteConfirm(e) {
    const taskId =
      e.currentTarget.parentElement.parentElement.getAttribute("id");

    Object.keys(inputSelector).forEach((key) => {
      const selector = inputSelector[key];
      selector.value = tasks[taskId][key];
      selector.disabled = true;
    });

    selectors.hiddenTaskId.value = taskId;
    selectors.createButton.disabled = true;
    selectors.deleteButton.disabled = false;
  }

  function calculateTotalPoints() {
    const totalPoints = Object.values(tasks).reduce(
      (acc, curr) => acc + curr.points,
      0
    );

    selectors.totalPoints.textContent = `Total Points ${totalPoints}pts`;
  }
}
