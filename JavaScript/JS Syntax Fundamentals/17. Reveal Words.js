function wordReveal(words, sentence) {
  let wordsArr = words.split(", ");

  for (let index = 0; index < wordsArr.length; index++) {
    let wordInAsterix = "";
    let currentWord = wordsArr[index];
    for (let index2 = 0; index2 < currentWord.length; index2++) {
      wordInAsterix += "*";
    }
    sentence = sentence.replace(wordInAsterix, currentWord);
  }

  console.log(sentence);
}

wordReveal(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);
