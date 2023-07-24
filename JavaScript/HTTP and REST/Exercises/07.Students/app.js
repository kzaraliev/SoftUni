function attachEvents() {
  const table = document.querySelector("tbody");

  const firstName = document.querySelector('.inputs > input[name="firstName"]');
  const lastName = document.querySelector('.inputs > input[name="lastName"]');
  const facultyNumber = document.querySelector(
    '.inputs > input[name="facultyNumber"]'
  );
  const grade = document.querySelector('.inputs > input[name="grade"]');

  const notification = document.querySelector(".notification");
  const submitButton = document
    .querySelector("#submit")
    .addEventListener("click", submit);

  const baseURL = `http://localhost:3030/jsonstore/collections/students`;

  fetch(baseURL)
    .then((res) => res.json())
    .then((students) => {
      Object.values(students).forEach((student) => {
        createRow(
          student.firstName,
          student.lastName,
          student.facultyNumber,
          student.grade
        );
      });
    })
    .catch((error) => {
      console.error(error.message);
    });

  function submit() {
    if (
      firstName.value === "" ||
      lastName.value === "" ||
      facultyNumber.value === "" ||
      grade.value === ""
    ) {
      notification.textContent = "Error!";
    } else {
      const httpHeaders = {
        method: "Post",
        body: JSON.stringify({
          firstName: firstName.value,
          lastName: lastName.value,
          facultyNumber: facultyNumber.value,
          grade: grade.value,
        }),
      };
      fetch(baseURL, httpHeaders)
        .then((res) => res.json())
        .then(
          createRow(
            firstName.value,
            lastName.value,
            facultyNumber.value,
            grade.value
          )
        )
        .catch((error) => {
          console.error(error.message);
        });
    }
  }
  function createRow(firstName, lastName, facultyNumber, grade) {
    const row = document.createElement("tr");
    table.appendChild(row);

    const firstNameCell = document.createElement("td");
    const lastNameCell = document.createElement("td");
    const facultyNumberCell = document.createElement("td");
    const gradeCell = document.createElement("td");

    firstNameCell.textContent = firstName;
    lastNameCell.textContent = lastName;
    facultyNumberCell.textContent = facultyNumber;
    gradeCell.textContent = grade;

    row.appendChild(firstNameCell);
    row.appendChild(lastNameCell);
    row.appendChild(facultyNumberCell);
    row.appendChild(gradeCell);
  }
}

attachEvents();