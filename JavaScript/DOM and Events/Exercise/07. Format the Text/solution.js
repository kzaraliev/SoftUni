function solve() {
  let text = document.getElementById("input").value;
  let splited = text.split(".").filter((s) => s != 0);
  let result = document.getElementById("output");
  while (splited.length > 0) {
    let textForP = splited.splice(0, 3).join(". ") + ".";
    let p = document.createElement("p");
    p.textContent = textForP;
    result.appendChild(p);
  }
}