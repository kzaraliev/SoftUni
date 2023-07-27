window.addEventListener("load", solve);

function solve() {
  const publishBttn = document.querySelector("#form-btn");
  publishBttn.addEventListener("click", onPublish);

  function onPublish() {
    const firstName = document.querySelector("#first-name");
    const lastName = document.querySelector("#last-name");
    const age = document.querySelector("#age");
    const title = document.querySelector("#story-title");
    const genre = document.querySelector("#genre");
    const story = document.querySelector("#story");

    const firstNameValue = firstName.value;
    const lastNameValue = lastName.value;
    const ageValue = age.value;
    const titleValue = title.value;
    const genreValue = genre.value;
    const storyValue = story.value;

    if (!validInputFields([firstName, lastName, age, title, genre, story])) {
      return;
    }

    publishBttn.disabled = true;

    const storyOnList = createElement(
      "li",
      null,
      ["story-info"],
      null,
      document.querySelector("#preview-list")
    );

    //article elements
    const article = createElement("article", null, null, null, storyOnList);
    createElement(
      "h4",
      `Name: ${firstNameValue} ${lastNameValue}`,
      null,
      null,
      article
    );
    createElement("p", `Age: ${ageValue}`, null, null, article);
    createElement("p", `Title: ${titleValue}`, null, null, article);
    createElement("p", `Genre: ${genreValue}`, null, null, article);
    createElement("p", storyValue, null, null, article);

    //buttons
    const saveBtn = createElement(
      "button",
      "Save Story",
      ["save-btn"],
      null,
      storyOnList
    );
    const editBtn = createElement(
      "button",
      "Edit Story",
      ["edit-btn"],
      null,
      storyOnList
    );
    const deleteBtn = createElement(
      "button",
      "Delete Story",
      ["delete-btn"],
      null,
      storyOnList
    );

    saveBtn.addEventListener("click", saveStory);
    editBtn.addEventListener("click", editStory);
    deleteBtn.addEventListener("click", deleteStory);

    firstName.value = "";
    lastName.value = "";
    age.value = "";
    title.value = "";
    genre.value = "";
    story.value = "";

    function saveStory() {
      const main = document.querySelector("#main");
      main.innerHTML = "";
      createElement("h1", "Your scary story is saved!", null, null, main);
    }

    function editStory() {
      publishBttn.disabled = false;
      saveBtn.disabled = true;
      editBtn.disabled = true;
      deleteBtn.disabled = true;

      firstName.value = firstNameValue;
      lastName.value = lastNameValue;
      age.value = ageValue;
      title.value = titleValue;
      genre.value = genreValue;
      story.value = storyValue;

      storyOnList.remove();
    }

    function deleteStory() {
      storyOnList.remove();
      publishBttn.disabled = false;
    }
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

  function validInputFields(elements) {
    for (let i = 0; i < elements.length; i++) {
      if (elements[i].value == "") {
        return false;
      }
    }
    return true;
  }
}
