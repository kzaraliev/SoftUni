function sumTable() {
  const costColumn = Array.from(
    document.querySelectorAll("td:nth-child(even):not(#sum)")
  );

  let totalSum = 0;

  const allPrices = costColumn.forEach((p) => {
    totalSum += parseFloat(p.textContent);
  });

  document.querySelector("#sum").textContent = totalSum;
}
