function solve(input) {
  const numberOfRiders = input.shift();
  let riders = [];

  for (let i = 0; i < numberOfRiders; i++) {
    const lineArr = input[i].split("|");

    const rider = {
      name: lineArr[0],
      fuelCapacity: Number(lineArr[1]),
      position: Number(lineArr[2]),
    };

    if (rider.fuelCapacity > 100) {
      rider.fuelCapacity = 100
    }

    riders.push(rider);
  }

  for (let i = numberOfRiders; i < input.length; i++) {
    const lineArr = input[i].split(" - ");
    const command = lineArr[0];
    const firstRiderName = lineArr[1];
    if (command == "Finish") {
      break;
    }

    switch (command) {
      case "StopForFuel":
        const minimumFuel = Number(lineArr[2]);
        const newPosition = Number(lineArr[3]);

        const riderForFuel = riders.find((r) => r.name === firstRiderName);

        if (riderForFuel.fuelCapacity < minimumFuel) {
          riderForFuel.position = newPosition;
          console.log(
            `${riderForFuel.name} stopped to refuel but lost his position, now he is ${riderForFuel.position}.`
          );
        } else {
          console.log(`${riderForFuel.name} does not need to stop for fuel!`);
        }
        break;
      case "Overtaking":
        const firstRider = riders.find((r) => r.name === firstRiderName);
        const secondRider = riders.find((r) => r.name === lineArr[2]);

        const firstRiderIndex = riders.indexOf(firstRider);
        const secondRiderIndex = riders.indexOf(secondRider);

        if (firstRiderIndex < secondRiderIndex) {
          const positionOfSecond = secondRider.position;
          secondRider.position = firstRider.position;
          firstRider.position = positionOfSecond;

          console.log(`${firstRider.name} overtook ${secondRider.name}!`);
        }
        break;
      case "EngineFail":
        const lapsLeft = Number(lineArr[2]);
        const riderFail = riders.find((r) => r.name === firstRiderName);
        riders.splice(riders.indexOf(riderFail), 1);
        console.log(
          `${riderFail.name} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
        );
        break;
    }
  }

  for (let i = 0; i < riders.length; i++) {
    const rider = riders[i];
    console.log(`${rider.name}`);
    console.log(`  Final position: ${rider.position}`);
  }
}

solve([
  "4",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|3",
  "Jorge Lorenzo|80|4",
  "Johann Zarco|80|2",
  "StopForFuel - Johann Zarco - 90 - 5",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);
