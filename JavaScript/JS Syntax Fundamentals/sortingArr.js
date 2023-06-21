function findHighestNumber(...input) {
  if (input.length < 1) {
    console.log("Error!");
    return;
  }

  const sortedInput = input.sort(function (a, b) {
    return b - a; //if we change `a` and `b`, we change the arr to asc arr
  });

  const highestNumber = sortedInput[0];

  console.log(highestNumber);
}

findHighestNumber(1, 23, 4, 5, 1234, 1235, 28, 84, 1, 24, 535, 1224);
