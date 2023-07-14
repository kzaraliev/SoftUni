function checkPalindromes(numbers) {
  for (let number of numbers) {
    const str = number.toString();
    const reversedStr = str.split("").reverse().join("");

    if (str === reversedStr) {
      console.log("true");
    } else {
      console.log("false");
    }
  }
}
checkPalindromes([123, 323, 421, 121]);
