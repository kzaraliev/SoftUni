window.addEventListener("load", solve);

function solve() {
  const addBtn = document.querySelector("#add-btn");
  addBtn.addEventListener("click", addSongToCollection);

  function addSongToCollection(e) {
    e.preventDefault();
    const genre = document.querySelector("#genre");
    const name = document.querySelector("#name");
    const author = document.querySelector("#author");
    const date = document.querySelector("#date");

    const collectionContainer = document.querySelector(".all-hits-container");
    const savedContainer = document.querySelector(".saved-container");

    if (!genre.value || !name.value || !author.value || !date.value) {
      return;
    }

    const genreValue = genre.value;
    const nameValue = name.value;
    const authorValue = author.value;
    const dateValue = date.value;

    const songContainer = createElement(
      "div",
      null,
      ["hits-info"],
      null,
      collectionContainer
    );

    const image = createElement("img", null, null, null, songContainer);
    image.src = "./static/img/img.png";
    createElement("h2", `Genre: ${genreValue}`, null, null, songContainer);
    createElement("h2", `Name: ${nameValue}`, null, null, songContainer);
    createElement("h2", `Author: ${authorValue}`, null, null, songContainer);
    createElement("h3", `Date: ${dateValue}`, null, null, songContainer);

    const saveBtn = createElement(
      "button",
      "Save song",
      ["save-btn"],
      null,
      songContainer
    );

    const likeBtn = createElement(
      "button",
      "Like song",
      ["like-btn"],
      null,
      songContainer
    );

    const deleteBtn = createElement(
      "button",
      "Delete",
      ["delete-btn"],
      null,
      songContainer
    );

    genre.value = "";
    name.value = "";
    author.value = "";
    date.value = "";

    likeBtn.addEventListener("click", () => {
      let likes = parseInt(
        document.querySelector(".likes > p").innerText.split(":")[1].trim()
      );
      likes++;

      document.querySelector(".likes > p").innerText = "Total Likes: " + likes;

      likeBtn.disabled = true;
    });

    saveBtn.addEventListener("click", () => {
      songContainer.remove();

      const songContainerSaved = createElement(
        "div",
        null,
        ["hits-info"],
        null,
        savedContainer
      );

      const image = createElement("img", null, null, null, songContainerSaved);
      image.src = "./static/img/img.png";
      createElement(
        "h2",
        `Genre: ${genreValue}`,
        null,
        null,
        songContainerSaved
      );
      createElement("h2", `Name: ${nameValue}`, null, null, songContainerSaved);
      createElement(
        "h2",
        `Author: ${authorValue}`,
        null,
        null,
        songContainerSaved
      );
      createElement("h3", `Date: ${dateValue}`, null, null, songContainerSaved);
      const deleteBtnSaved = createElement(
        "button",
        "Delete",
        ["delete-btn"],
        null,
        songContainerSaved
      );

      deleteBtnSaved.addEventListener("click", () => {
        songContainerSaved.remove();
      });
    });

    deleteBtn.addEventListener("click", () => {
      songContainer.remove();
    });
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
}
