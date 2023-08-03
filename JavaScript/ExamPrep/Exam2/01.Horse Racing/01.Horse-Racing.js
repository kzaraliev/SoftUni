function solve(input) {
  const horses = input.shift().split("|");

  let line = input.shift();

  while (line != "Finish") {
    const lineArr = line.split(" ");
    const command = lineArr[0];
    const firstHorse = lineArr[1];
    const secondHorse = lineArr[2];

    const horsePosition = horses.indexOf(firstHorse);
    const secondHorsePosition = horses.indexOf(secondHorse);

    switch (command) {
      case "Retake":
        if (horsePosition < secondHorsePosition) {
          horses[horsePosition] = secondHorse;
          horses[secondHorsePosition] = firstHorse;

          console.log(`${firstHorse} retakes ${secondHorse}.`);
        }

        break;
      case "Trouble":
        if (horsePosition > 0) {
          horses[horsePosition] = horses[horsePosition - 1];
          horses[horsePosition - 1] = firstHorse;

          console.log(`Trouble for ${firstHorse} - drops one position.`);
        }

        break;
      case "Rage":
        if (horsePosition === horses.length - 2) {
          horses[horses.length - 2] = horses[horses.length - 1];
          horses[horses.length - 1] = firstHorse;
        } else if (horsePosition < horses.length - 1) {
          horses[horsePosition] = horses[horsePosition + 1];
          horses[horsePosition + 1] = horses[horsePosition + 2];
          horses[horsePosition + 2] = firstHorse;
        }

        console.log(`${firstHorse} rages 2 positions ahead.`);
        break;
      case "Miracle":
        const lastHorse = horses.shift();
        horses.push(lastHorse);

        console.log(`What a miracle - ${lastHorse} becomes first.`);
        break;
    }

    line = input.shift();
  }

  console.log(horses.join("->"));
  console.log(`The winner is: ${horses.pop()}`);
}

solve([
  "Onyx|Domino|Sugar|Fiona",
  "Trouble Onyx",
  "Retake Onyx Sugar",
  "Rage Domino",
  "Miracle",
  "Finish",
]);
