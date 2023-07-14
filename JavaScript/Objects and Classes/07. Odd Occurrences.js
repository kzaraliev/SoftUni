function searchingForOddOCcurrences(input) {
  let words = input.toLowerCase().split(" ");
  const wordCountMap = {};

  for (const word of words) {
    if (wordCountMap[word]) {
      wordCountMap[word]++;
    } else {
      wordCountMap[word] = 1;
    }
  }

  const oddOccurrences = [];

  for (const word in wordCountMap) {
    if (wordCountMap[word] % 2 !== 0) {
      oddOccurrences.push(word);
    }
  }

  console.log(oddOccurrences.join(" "));
}

searchingForOddOCcurrences('Cake IS SWEET is Soft CAKE sweet Food');