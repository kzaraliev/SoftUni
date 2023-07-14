function findSmallestNumber(num1, num2, num3) {
  let numArr = [num1, num2, num3];
  numArr.sort(function (a, b) {
    return a - b;
  });
  console.log(numArr[0]);

  //console.log(Math.min(num1, num2, num3));
}

findSmallestNumber(2, 5, 3);
