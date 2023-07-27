function solve(input) {
  const n = input.shift();
  let pieces = [];

  //Adding pieces to array
  for (let i = 0; i < n; i++) {
    const element = input[i].split("|");
    const piece = {
      name: element[0],
      composer: element[1],
      key: element[2],
    };

    pieces.push(piece);
  }

  //Taking all commands
  for (let i = n; i < input.length; i++) {
    const element = input[i].split("|");
    let command = {
      operator: element[0],
      pieceOfAct: element[1],
    };

    switch (command.operator) {
      case "Add":
        if (pieces.some((p) => p.name === command.pieceOfAct)) {
          console.log(`${command.pieceOfAct} is already in the collection!`);
        } else {
          const piece = {
            name: element[1],
            composer: element[2],
            key: element[3],
          };
          pieces.push(piece);

          console.log(
            `${piece.name} by ${piece.composer} in ${piece.key} added to the collection!`
          );
        }
        break;
      case "Remove":
        if (pieces.some((p) => p.name === command.pieceOfAct)) {
          pieces = pieces.filter(function (piece) {
            return piece.name !== command.pieceOfAct;
          });

          console.log(`Successfully removed ${command.pieceOfAct}!`);
        } else {
          console.log(
            `Invalid operation! ${command.pieceOfAct} does not exist in the collection.`
          );
        }
        break;
      case "ChangeKey":
        if (pieces.some((p) => p.name === command.pieceOfAct)) {
          pieces.find((p) => p.name === command.pieceOfAct).key = element[2];
          console.log(
            `Changed the key of ${command.pieceOfAct} to ${element[2]}!`
          );
        } else {
          console.log(
            `Invalid operation! ${command.pieceOfAct} does not exist in the collection.`
          );
        }
        break;
      case "Stop":
        continue;
    }
  }

  pieces.forEach((piece) => {
    console.log(
      `${piece.name} -> Composer: ${piece.composer}, Key: ${piece.key}`
    );
  });
}

solve([
  "3",
  "Fur Elise|Beethoven|A Minor",
  "Moonlight Sonata|Beethoven|C# Minor",
  "Clair de Lune|Debussy|C# Minor",
  "Add|Sonata No.2|Chopin|B Minor",
  "Add|Hungarian Rhapsody No.2|Liszt|C# Minor",
  "Add|Fur Elise|Beethoven|C# Minor",
  "Remove|Clair de Lune",
  "ChangeKey|Moonlight Sonata|C# Major",
  "Stop",
]);
