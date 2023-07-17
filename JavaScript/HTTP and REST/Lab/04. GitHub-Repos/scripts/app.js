function loadRepos() {
  const bodyHtml = document.querySelector("body");
  const title = document.createElement("h1");
  title.textContent = "All names of repos";
  bodyHtml.appendChild(title);

  fetch("https://api.github.com/users/testnakov/repos")
    .then((res) => res.json())
    .then((body) => {
      body.forEach((repo) => {
        const name = document.createElement("h2");
        name.textContent = repo.name;

        bodyHtml.appendChild(name);
      });
    });
}
