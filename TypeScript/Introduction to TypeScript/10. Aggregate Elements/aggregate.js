"use strict";
function AggregateElements(numbers) {
    // sum
    const sum = sumNumbers(numbers);
    //sum inversed
    const sumInversed = sumInversedNumbers(numbers);
    //concat
    const concat = concatNumbers(numbers);
    console.log(sum);
    console.log(sumInversed);
    console.log(concat);
}
const sumNumbers = (numbers) => {
    let sum = 0;
    numbers.forEach((num) => {
        sum += num;
    });
    return sum;
};
const sumInversedNumbers = (numbers) => {
    let sum = 0;
    numbers.forEach((num) => {
        sum += 1 / num;
    });
    return sum;
};
const concatNumbers = (numbers) => {
    return numbers.join("");
};
AggregateElements([1, 2, 3]);
