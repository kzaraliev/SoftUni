function splitPascalCaseString(pascalCaseString) {
  var words = pascalCaseString
    .replace(/([A-Z])/g, " $1")
    .trim()
    .split(/\s+/);

  var result = words.join(", ");

  console.log(result);
}

splitPascalCaseString("SplitMeIfYouCanHaHaYouCantOrYouCan");
