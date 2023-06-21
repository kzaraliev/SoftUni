function speedChecker(speed, area) {
  const motorwaySpeedLimit = 130;
  const interstateSpeedLimit = 90;
  const citySpeedLimit = 50;
  const residentialSpeedLimit = 20;

  const speedingUpTo20km = "speeding";
  const speedingUpTo40km = "excessive speeding";
  const speedingUpToElse = "reckless driving";

  switch (area) {
    case "motorway":
      if (speed <= motorwaySpeedLimit) {
        console.log(`Driving ${speed} km/h in a ${motorwaySpeedLimit} zone`);
      } else {
        let speedDiff = speed - motorwaySpeedLimit;
        ifSpeeding(
          speedDiff,
          motorwaySpeedLimit,
          speedingUpTo20km,
          speedingUpTo40km,
          speedingUpToElse
        );
      }
      break;
    case "interstate":
      if (speed <= interstateSpeedLimit) {
        console.log(`Driving ${speed} km/h in a ${interstateSpeedLimit} zone`);
      } else {
        let speedDiff = speed - interstateSpeedLimit;
        ifSpeeding(
          speedDiff,
          interstateSpeedLimit,
          speedingUpTo20km,
          speedingUpTo40km,
          speedingUpToElse
        );
      }
      break;
    case "city":
      if (speed <= citySpeedLimit) {
        console.log(`Driving ${speed} km/h in a ${citySpeedLimit} zone`);
      } else {
        let speedDiff = speed - citySpeedLimit;
        ifSpeeding(
          speedDiff,
          citySpeedLimit,
          speedingUpTo20km,
          speedingUpTo40km,
          speedingUpToElse
        );
      }
      break;
    case "residential":
      if (speed <= residentialSpeedLimit) {
        console.log(`Driving ${speed} km/h in a ${residentialSpeedLimit} zone`);
      } else {
        let speedDiff = speed - residentialSpeedLimit;
        ifSpeeding(
          speedDiff,
          residentialSpeedLimit,
          speedingUpTo20km,
          speedingUpTo40km,
          speedingUpToElse
        );
      }
      break;
  }

  function ifSpeeding(
    speedDiff,
    placeSpeedLimit,
    speedingUpTo20km,
    speedingUpTo40km,
    speedingUpToElse
  ) {
    if (speedDiff <= 20) {
      console.log(
        `The speed is ${speedDiff} km/h faster than the allowed speed of ${placeSpeedLimit} - ${speedingUpTo20km}`
      );
    } else if (speedDiff <= 40) {
      console.log(
        `The speed is ${speedDiff} km/h faster than the allowed speed of ${placeSpeedLimit} - ${speedingUpTo40km}`
      );
    } else {
      console.log(
        `The speed is ${speedDiff} km/h faster than the allowed speed of ${placeSpeedLimit} - ${speedingUpToElse}`
      );
    }
  }
}

speedChecker(40, "city");
