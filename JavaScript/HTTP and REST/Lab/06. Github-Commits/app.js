async function loadCommits() {
  const username = document.querySelector("#username").value;
  const repo = document.querySelector("#repo").value;

  if (!username || !repo) {
    console.log("Error!");
    return;
  }

  const list = document.querySelector("ul");
  list.innerHTML = "";

  //   fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
  //     .then((res) => res.json())
  //     .then((commits) => {
  //       commits.forEach(({commit}) => {
  //         const item = document.createElement("li");
  //         item.textContent = commit.message;

  //         list.appendChild(item);
  //       });
  //     });
  
  //need async to the function
  //   const respond = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);
  //   const body = await respond.json();

  //Best version?
  const respond = await (
    await fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
  ).json();

  respond.forEach(({ commit }) => {
    const item = document.createElement("li");
    item.textContent = commit.message;

    list.appendChild(item);
  });
}
