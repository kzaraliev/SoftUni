function findWordOccurrences(input) {
  const [searchWords, ...words] = input;
  const wordOcc = searchWords.split(" ").reduce((acc, curr) => {
    acc[curr] = 0;
    return acc;
  }, {});
  words.forEach((word) => {
    if (wordOcc.hasOwnProperty(word)) wordOcc[word]++;
  });
  Object.entries(wordOcc)
    .sort(([, a], [, b]) => b - a)
    .forEach(([key, value]) => {
      console.log(`${key} - ${value}`);
    });
}

findWordOccurrences([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);
