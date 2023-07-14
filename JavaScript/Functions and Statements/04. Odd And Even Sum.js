function sumOfOddAndEven(number) {
  let evenSum = 0;
  let oddSum = 0;
  let digitArr = [];
  let sNumber = number.toString();

  for (var i = 0, len = sNumber.length; i < len; i += 1) {
    digitArr.push(+sNumber.charAt(i));
  }

  for (let index = 0; index < digitArr.length; index++) {
    let element = digitArr[index];
    if (element % 2 == 0) {
      evenSum += element;
    } else {
      oddSum += element;
    }
  }

  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

sumOfOddAndEven(3495892137259234);
