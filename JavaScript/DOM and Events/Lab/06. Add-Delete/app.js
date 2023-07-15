function addItem() {
  const value = document.querySelector("#newItemText").value;

  const item = document.createElement("li");
  item.textContent = value;

  item.appendChild(createDeleteButton());

  document.querySelector("ul").appendChild(item);
  document.querySelector("#newItemText").value = "";
}

function createDeleteButton() {
  const deleteButton = document.createElement("a");
  deleteButton.href = "#";
  deleteButton.textContent = "[Delete]";
  deleteButton.addEventListener("click", (e) => {
    e.target.parentElement.remove();
  });

  return deleteButton;
}
