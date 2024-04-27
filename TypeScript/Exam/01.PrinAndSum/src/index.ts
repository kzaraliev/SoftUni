function solve(startNumber: number, endNumber: number): void {
  if (endNumber < startNumber) {
    throw new Error("Invalid Input");
  }

  let numbers: number[] = [];

  for (let i: number = startNumber; i < endNumber + 1; i++) {
    numbers.push(i);
  }

  let sum: number = numbers.reduce((accumulator, current) => accumulator + current, 0);

  console.log(numbers.join(" "));
  console.log(`Sum: ${sum}`);
}

solve(50, 60);
