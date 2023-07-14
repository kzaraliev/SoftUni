function piccolo(parkingRecords) {
  let carsInParkingLot = {};

  for (let record of parkingRecords) {
    let [action, carNum] = record.split(", ");

    if (action === "IN") {
      carsInParkingLot[carNum] = "IN";
    } else if (action === "OUT") {
      delete carsInParkingLot[carNum];
    }
  }

  if (Object.keys(carsInParkingLot).length === 0) {
    console.log("Parking Lot is Empty");
  } else {
    Object.entries(carsInParkingLot)
      .sort((e1, e2) => e1[0].localeCompare(e2[0]))
      .forEach((e) => console.log(e[0]));
  }
}

piccoloFunctions([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);
