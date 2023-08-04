function solve(input) {
  let products = input.shift().split("!");

  let line = input.shift();
  while (line != "Go Shopping!") {
    const lineArr = line.split(" ");
    const command = lineArr[0];
    const firstItem = lineArr[1];

    switch (command) {
      case "Urgent":
        if (products.some((p) => p === firstItem)) {
          break;
        }
        products.unshift(firstItem);
        break;
      case "Unnecessary":
        const index = products.indexOf(firstItem);
        if (index !== -1) {
          products.splice(index, 1);
        }
        break;
      case "Correct":
        const secondItem = lineArr[2];
        const indexOfOldItem = products.indexOf(firstItem);
        if (indexOfOldItem !== -1) {
          products[indexOfOldItem] = secondItem;
        }
        break;
      case "Rearrange":
        const indexRearrange = products.indexOf(firstItem);
        if (indexRearrange !== -1) {
          const product = products.splice(indexRearrange, 1);
          products.push(product);
        }
        break;
    }

    line = input.shift();
  }

  console.log(products.join(", "));
}

solve([
  "Tomatoes!Potatoes!Bread",
  "Unnecessary Milk",
  "Urgent Tomatoes",
  "Go Shopping!",
]);
