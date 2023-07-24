function attachEvents() {
    const loadButton = document
      .querySelector("#btnLoad")
      .addEventListener("click", loadContacts);
  
    const createButton = document
      .querySelector("#btnCreate")
      .addEventListener("click", createContact);
  
    const baseURL = `http://localhost:3030/jsonstore/phonebook`;
  
    function loadContacts() {
      fetch(`http://localhost:3030/jsonstore/phonebook`)
        .then((res) => res.json())
        .then((contacts) => {
          const phoneBook = document.querySelector("#phonebook");
          Object.values(contacts).forEach((contact) => {
            const li = document.createElement("li");
            const deleteButton = document.createElement("button");
            deleteButton.textContent = "Delete";
            li.textContent = `${contact.person}: ${contact.phone}`;
            deleteButton.addEventListener("click", deleteContact);
            li.appendChild(deleteButton);
            phoneBook.appendChild(li);
  
            function deleteContact() {
              fetch(`${baseURL}/${contact._id}`, {
                method: "DELETE",
              }).catch((error) => {
                console.log(error.message);
              });
              li.remove();
            }
          });
        })
        .catch((error) => {
          console.error(error.message);
        });
    }
    function createContact() {
      let person = document.querySelector("#person").value;
      let phone = document.querySelector("#phone").value;
      const httpHeaders = {
        method: "Post",
        body: JSON.stringify({ person: person, phone: phone }),
      };
      person.value = "";
      phone.value = "";
  
      fetch(baseURL, httpHeaders)
        .then((res) => res.json())
        .catch((error) => {
          console.log(error.message);
        });
  
      console.log(httpHeaders.body);
    }
  }
  
  attachEvents();