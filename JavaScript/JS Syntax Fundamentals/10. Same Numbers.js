function numbersChecker(number) {
  let firstNumber = 0;
  const digits = number.toString().split("");
  let flag = true;
  let totalSum = 0;

  for (let index = 0; index < digits.length; index++) {
    if (index === 0) {
      firstNumber = parseInt(digits[index]);
    } else {
      if (firstNumber !== parseInt(digits[index])) {
        flag = false;
      }
    }

    totalSum += parseInt(digits[index]);
  }

  console.log(flag);
  console.log(totalSum);
}

numbersChecker(1234);
