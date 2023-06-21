function findingSubstring(word, sentence) {
    if (sentence.toLowerCase().includes(word.toLowerCase())) {
        console.log(word);
    }
    else{
        console.log(`${word} not found!`);
    }
}

findingSubstring('javascript','JavaScript is the best programming language')