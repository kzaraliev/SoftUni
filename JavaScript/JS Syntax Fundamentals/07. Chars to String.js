function charsToString(...input) {
  let combinedString = input.map(function (char) {
    return char;
  });

  console.log(combinedString.join(""));
}

charsToString("a", "b", "c");
