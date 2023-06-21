function multiplicationTable(number) {
  for (let index = 1; index < 11; index++) {
    console.log(`${number} X ${index} = ${number * index}`);
  }
}

multiplicationTable(5);