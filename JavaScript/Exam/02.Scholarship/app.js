window.addEventListener("load", solve);

function solve() {
  const nextBtn = document.querySelector("#next-btn");
  nextBtn.addEventListener("click", nextEvent);

  function nextEvent() {
    const studentName = document.querySelector("#student");
    const university = document.querySelector("#university");
    const score = document.querySelector("#score");

    const previewList = document.querySelector("#preview-list");
    const candidatesList = document.querySelector("#candidates-list");

    const studentNameValue = studentName.value;
    const universityValue = university.value;
    const scoreValue = score.value;

    if (!studentName.value || !university.value || !score.value) {
      return;
    }

    const application = createElement(
      "li",
      null,
      ["application"],
      null,
      previewList
    );

    const article = createElement("article", null, null, null, application);
    createElement("h4", studentNameValue, null, null, article);
    createElement("p", `University: ${universityValue}`, null, null, article);
    createElement("p", `Score: ${scoreValue}`, null, null, article);

    const editBtn = createElement(
      "button",
      "edit",
      ["action-btn", "edit"],
      null,
      application
    );
    const applyBtn = createElement(
      "button",
      "apply",
      ["action-btn", "apply"],
      null,
      application
    );

    studentName.value = "";
    university.value = "";
    score.value = "";
    nextBtn.disabled = true;

    editBtn.addEventListener("click", editApply);
    applyBtn.addEventListener("click", applyApply)

    function editApply() {
      studentName.value = studentNameValue;
      university.value = universityValue;
      score.value = scoreValue;
      nextBtn.disabled = false;
      application.remove();
    }

    function applyApply() {
      application.remove();

      const applicationForApply = createElement(
        "li",
        null,
        ["application"],
        null,
        candidatesList
      );
  
      const article = createElement("article", null, null, null, applicationForApply);
      createElement("h4", studentNameValue, null, null, article);
      createElement("p", `University: ${universityValue}`, null, null, article);
      createElement("p", `Score: ${scoreValue}`, null, null, article);
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
