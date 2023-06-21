function findSpecialWords(inputString) {
  const words = inputString.split(" ");

  const specialWords = words.filter((word) => {
    if (word.startsWith("#")) {
      // Remove the '#' label
      const cleanedWord = word.slice(1);
      if (/^[a-zA-Z]+$/.test(cleanedWord)) {
        return true;
      }
    }
    return false;
  });

  specialWords.forEach((element) => {
    console.log(element.slice(1));
  });
}

findSpecialWords(
  "Nowadays everyone uses # to tag a #special word in #socialMedia"
);
