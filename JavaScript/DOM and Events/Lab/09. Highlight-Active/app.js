function focused() {
  const inputs = Array.from(document.querySelectorAll("input"));

  inputs.forEach((input) => {
    input.addEventListener("focus", (e) => {
      e.target.parentElement.classList.add("focused");
    });
  });

  inputs.forEach((input) => {
    input.addEventListener("blur", (e) => {
      e.target.parentElement.classList.remove("focused");
    });
  });
}
