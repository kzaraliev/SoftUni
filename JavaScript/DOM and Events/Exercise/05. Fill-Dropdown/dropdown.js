function addItem() {
  const text = document.querySelector("#newItemText").value;
  const value = document.querySelector("#newItemValue").value;

 
  const drobMenu = document.querySelector("#menu");

  const newChild = document.createElement("option");
  newChild.textContent = text;
  newChild.value = value;
  drobMenu.appendChild(newChild);

  document.querySelector("#newItemText").value = null;
  document.querySelector("#newItemValue").value = null;
}
