function create(words) {
  let content = document.getElementById("content");

  for (let i = 0; i < words.length; i++) {
    let div = document.createElement("div");
    div.addEventListener("click", () => {
      p.style.display = "block";
    });
    let p = document.createElement("p");
    p.textContent = words[i];
    p.style.display = "none";
    div.appendChild(p);
    content.appendChild(div);
  }
}
