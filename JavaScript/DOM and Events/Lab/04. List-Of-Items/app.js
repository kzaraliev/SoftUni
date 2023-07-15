function addItem() {
  const value = document.querySelector("#newItemText").value;
  const item = document.createElement("li");
  item.textContent = value;
  document.querySelector("ul").appendChild(item);
}
