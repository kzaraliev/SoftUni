function reversedCharsToString(...input) {
  let combinedString = input.map(function (char) {
    return char;
  });

  console.log(combinedString.reverse().join(" "));
}

reversedCharsToString("A", "B", "C");
