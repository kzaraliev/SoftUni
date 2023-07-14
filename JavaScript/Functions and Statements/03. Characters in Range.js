function printCharactersBetween(char1, char2) {
  const start = Math.min(char1.charCodeAt(), char2.charCodeAt());
  const end = Math.max(char1.charCodeAt(), char2.charCodeAt());
  let arrofChars = new String();

  for (let i = start + 1; i < end; i++) {
    const character = String.fromCharCode(i);
    arrofChars += character;
    arrofChars += " ";
  }
  console.log(arrofChars);
}

printCharactersBetween("#", ":");
