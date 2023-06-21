function sortArray(numbers) {
  numbers.sort((a, b) => a - b);

  const result = [];

  let left = 0;
  let right = numbers.length - 1;

  while (left <= right) {
    if (left === right) {
      result.push(numbers[left]);
    } else {
      result.push(numbers[left]);
      result.push(numbers[right]);
    }

    left++;
    right--;
  }
}

const numbers = [1, 65, 3, 52, 48, 63, 31, -3, 18, 56];
const sortedArray = sortArray(numbers);
console.log(sortedArray);
