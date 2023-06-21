function sortingNames(input) {
  input.sort();

  for (let index = 0; index < input.length; index++) {
    console.log(`${index+1}.${input[index]}`);
  }
}

sortingNames(["John", "Bob", "Christina", "Ema"]);
