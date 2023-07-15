function colorize() {
  const evenRows = Array.from(document.querySelectorAll("tr:nth-child(even)"));

  evenRows.forEach((r) => {
    r.style.backgroundColor = "Teal";
  })
}
