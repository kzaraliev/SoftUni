function calculateFactorialAndDivide(num1, num2) {
  const factorial1 = calculateFactorial(num1);
  const factorial2 = calculateFactorial(num2);
  const division = factorial1 / factorial2;

  const formattedResult = division.toFixed(2);
  console.log(formattedResult);
  
  function calculateFactorial(num) {
    if (num === 0 || num === 1) {
      return 1;
    }
  
    let factorial = 1;
    for (let i = 2; i <= num; i++) {
      factorial *= i;
    }
  
    return factorial;
  }
}


calculateFactorialAndDivide(6, 2);
