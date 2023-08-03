window.addEventListener("load", solve);

function solve() {
  const publishBtn = document.querySelector("#publish-btn");
  publishBtn.addEventListener("click", publishTask);

  function publishTask() {
    const title = document.querySelector("#task-title");
    const category = document.querySelector("#task-category");
    const content = document.querySelector("#task-content");
    const reviewList = document.querySelector("#review-list");
    const publishedList = document.querySelector("#published-list");

    const titleValue = title.value;
    const categoryValue = category.value;
    const contentValue = content.value;

    if (!title.value || !category.value || !content.value) {
      return;
    }

    const li = createElement("li", null, ["rpost"], null, reviewList);
    const article = createElement("article", null, null, null, li);
    createElement("h4", titleValue, null, null, article);
    createElement("p", `Category: ${categoryValue}`, null, null, article);
    createElement("p", `Content: ${contentValue}`, null, null, article);
    const editBtn = createElement(
      "button",
      "Edit",
      ["action-btn", "edit"],
      null,
      li
    );
    const postBtn = createElement(
      "button",
      "Post",
      ["action-btn", "post"],
      null,
      li
    );

    title.value = "";
    category.value = "";
    content.value = "";
    editBtn.addEventListener("click", editPost);
    postBtn.addEventListener("click", postArticle);

    function editPost() {
      title.value = titleValue;
      category.value = categoryValue;
      content.value = contentValue;

      li.remove();
    }

    function postArticle() {
      li.remove();

      const liPosted = createElement(
        "li",
        null,
        ["rpost"],
        null,
        publishedList
      );
      const articleForPublished = createElement("article", null, null, null, liPosted);
      createElement("h4", titleValue, null, null, articleForPublished);
      createElement("p", `Category: ${categoryValue}`, null, null, articleForPublished);
      createElement("p", `Content: ${contentValue}`, null, null, articleForPublished);
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
}
