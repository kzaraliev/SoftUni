function deleteByEmail() {
  const email = document.querySelector('input[name="email"]').value;
  const emails = Array.from(document.querySelectorAll("td:nth-child(even)"));
  
  const userEmailBox = emails.find(box => box.textContent === email);
  const result = document.querySelector("#result")


  if (userEmailBox) {
    userEmailBox.parentElement.remove();
    result.textContent = "Deleted."
  }
  else{
    result.textContent = "Not found."
  }
}
