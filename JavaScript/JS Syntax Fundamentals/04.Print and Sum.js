function printAndSum(num1, num2) {
  const allNumbersBetween = [];

  for (let index = num1; index <= num2; index++) {
    allNumbersBetween.push(index);
  }

  let totalSum = 0;
  allNumbersBetween.forEach((element) => {
    totalSum += element;
  });

  console.log(allNumbersBetween.join(" "));
  console.log(`Sum: ${totalSum}`);
}

printAndSum(0, 26);
