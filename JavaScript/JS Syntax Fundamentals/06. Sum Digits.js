function sumDigit(input) {
  const digits = input.toString().split("");
  let totalSum = 0;
  for (let index = 0; index < digits.length; index++) {
    totalSum += parseInt(digits[index]);
  }

  console.log(totalSum);
}

sumDigit(543);
