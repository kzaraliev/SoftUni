function extractText() {
  const listItems = Array.from(document.querySelectorAll("li"));
  const text = listItems.map((item) => item.textContent).join("\n");
  
  document.querySelector("textarea").value = text;
}
