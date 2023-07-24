function attachEvents() {
    const BASE_POSTS_URL = "http://localhost:3030/jsonstore/blog/posts";
    const BASE_COMMENTS_URL = "http://localhost:3030/jsonstore/blog/comments/";
    document.querySelector("#btnLoadPosts").addEventListener("click", loadPosts);
    document.querySelector("#btnViewPost").addEventListener("click", viewPost);
    const selectButton = document.querySelector("#posts");
    let postBody = {};
  
    function loadPosts() {
      fetch(BASE_POSTS_URL)
        .then((response) => response.json())
        .then((data) => {
          for (const key in data) {
            const newOption = document.createElement("option");
            newOption.value = data[key].id;
            newOption.textContent = data[key].title;
            selectButton.appendChild(newOption);
            postBody[data[key].id] = data[key].body;
          }
        })
        .catch((error) => {
          console.error(error.message);
        });
    }
  
    function viewPost() {
      const optionId = selectButton.value;
      const optionsButton = Array.from(selectButton.options);
      let optionText = null;
      for (const option of optionsButton) {
        if (option.value === optionId) {
          optionText = option.textContent;
          break;
        }
      }
  
      fetch(BASE_COMMENTS_URL)
        .then((response) => response.json())
        .then((data) => {
          const heading = document.getElementById("post-title");
          heading.textContent = optionText;
          const ul = document.getElementById("post-comments");
          const p = document.getElementById("post-body");
          p.textContent = postBody[optionId];
  
          ul.textContent = "";
          for (const key in data) {
            if (data[key].postId === optionId) {
              let li = document.createElement("li");
              li.textContent = data[key].text;
              ul.appendChild(li);
            }
          }
        })
        .catch((error) => {
          console.error(error.message);
        });
    }
  }
  
  attachEvents();