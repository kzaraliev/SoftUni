function AggregateElements(numbers: number[]): void {
  // sum
  const sum: number = sumNumbers(numbers);

  //sum inversed
  const sumInversed = sumInversedNumbers(numbers);

  //concat
  const concat = concatNumbers(numbers);

  console.log(sum);
  console.log(sumInversed);
  console.log(concat);
}

const sumNumbers = (numbers: number[]): number => {
  let sum: number = 0;

  numbers.forEach((num) => {
    sum += num;
  });

  return sum;
};

const sumInversedNumbers = (numbers: number[]): number => {
  let sum: number = 0;

  numbers.forEach((num) => {
    sum += 1 / num;
  });

  return sum;
};

const concatNumbers = (numbers: number[]): string => {
  return numbers.join("");
};

AggregateElements([1, 2, 3]);
