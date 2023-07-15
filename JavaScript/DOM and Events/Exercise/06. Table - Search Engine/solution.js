function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const value = document.querySelector("#searchField").value;
    const rows = document.querySelectorAll("tbody > tr > td");

    rows.forEach((row) => {
      row.classList.remove("select");
      if (row.innerHTML.includes(value)) {
        row.className ="select";
      }
    });

    document.querySelector("#searchField").value = null;
  }
}
