function vacationCalculator(countOfPeoples, groupType, day) {
  let priceForOnePerson = 0;

  switch (day) {
    case "Friday":
      if (groupType === "Students") {
        priceForOnePerson = 8.45;
      } else if (groupType === "Business") {
        priceForOnePerson = 10.9;
      } else if (groupType === "Regular") {
        priceForOnePerson = 15;
      }
      break;

    case "Saturday":
      if (groupType === "Students") {
        priceForOnePerson = 9.8;
      } else if (groupType === "Business") {
        priceForOnePerson = 15.6;
      } else if (groupType === "Regular") {
        priceForOnePerson = 20;
      }
      break;

    case "Sunday":
      if (groupType === "Students") {
        priceForOnePerson = 10.46;
      } else if (groupType === "Business") {
        priceForOnePerson = 16;
      } else if (groupType === "Regular") {
        priceForOnePerson = 22.5;
      }
      break;
  }

  let totalPrice = priceForOnePerson * countOfPeoples;

  if (groupType === "Students" && countOfPeoples >= 30) {
    totalPrice -= totalPrice * 0.15;
  } else if (groupType === "Business" && countOfPeoples >= 100) {
    totalPrice -= priceForOnePerson * 10;
  } else if (
    groupType === "Regular" &&
    countOfPeoples >= 10 &&
    countOfPeoples <= 20
  ) {
    totalPrice -= totalPrice * 0.05;
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacationCalculator(40, "Regular", "Saturday");
