function printMatrix(n) {
  for (let row = 0; row < n; row++) {
    let rowString = "";
    for (let col = 0; col < n; col++) {
      rowString += n + " ";
    }
    console.log(rowString);
  }
}

printMatrix(4);
