function attachEvents() {
  document
    .querySelector("#submit")
    .addEventListener("click", getWeatherDataForLocation);
}

async function getWeatherDataForLocation() {
  const locationName = document.querySelector("#location").value;

  const locations = await (
    await fetch(`http://localhost:3030/jsonstore/forecaster/locations`)
  ).json();

  const location = locations.find(
    (l) => l.name.toLowerCase() === locationName.toLowerCase()
  );

  const currentWeather = await (
    await fetch(
      `http://localhost:3030/jsonstore/forecaster/today/${location.code}`
    )
  ).json();

  const threeDaysWeather = await (
    await fetch(
      `http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`
    )
  ).json();

  const forecastContainer = document.querySelector("#forecast");
  forecastContainer.style.display = "block";

  buildingCurrentConditionSection(currentWeather);

  buildingThreeDayConditionSection(threeDaysWeather);
}

function buildingThreeDayConditionSection(threeDaysWeather) {
  const threeDaysContainer = createElement("forecast-info", "div");

  for (let i = 0; i < 3; i++) {
    const upcoming = createElement("upcoming", "span");

    const symbol = createElement("symbol", "span");
    upcoming.appendChild(symbol);
    switch (threeDaysWeather.forecast[i].condition) {
      case "Sunny":
        symbol.innerHTML = `&#x2600`;
        break;

      case "Partly sunny":
        symbol.innerHTML = `&#x26C5`;
        break;

      case "Overcast":
        symbol.innerHTML = `&#x2601`;
        break;

      case "Rain":
        symbol.innerHTML = `&#x2614`;
        break;
    }

    const temperature = createElement("forecast-data", "span");
    temperature.innerHTML = `${threeDaysWeather.forecast[i].low}&#176/${threeDaysWeather.forecast[i].high}&#176`;
    upcoming.appendChild(temperature);

    const conditionOfTheWeather = createElement("forecast-data", "span");
    conditionOfTheWeather.innerHTML = threeDaysWeather.forecast[i].condition;
    upcoming.appendChild(conditionOfTheWeather);

    threeDaysContainer.appendChild(upcoming);
  }

  const threeDaysCondition = document.querySelector("#upcoming");
  threeDaysCondition.appendChild(threeDaysContainer);
}

function buildingCurrentConditionSection(currentWeather) {
  const conditionSymbol = document.createElement("span");
  conditionSymbol.classList.add("condition", "symbol");

  switch (currentWeather.forecast.condition) {
    case "Sunny":
      conditionSymbol.innerHTML = `&#x2600`;
      break;

    case "Partly sunny":
      conditionSymbol.innerHTML = `&#x26C5`;
      break;

    case "Overcast":
      conditionSymbol.innerHTML = `&#x2601`;
      break;

    case "Rain":
      conditionSymbol.innerHTML = `&#x2614`;
      break;
  }

  let condition = createElement("condition", "span");

  let cityName = createElement("forecast-data", "span");

  cityName.innerHTML = currentWeather.name;
  condition.appendChild(cityName);

  let temperature = createElement("forecast-data", "span");

  temperature.innerHTML = `${currentWeather.forecast.low}&#176/${currentWeather.forecast.high}&#176`;
  condition.appendChild(temperature);

  let conditionOfTheWeather = createElement("forecast-data", "span");

  conditionOfTheWeather.innerHTML = currentWeather.forecast.condition;
  condition.appendChild(conditionOfTheWeather);

  const currentConditionContainer = createElement("forecasts", "div");

  currentConditionContainer.appendChild(conditionSymbol);
  currentConditionContainer.appendChild(condition);

  const currentCondition = document.querySelector("#current");
  currentCondition.appendChild(currentConditionContainer);
}

function createElement(className, typeOfElement) {
  let element = document.createElement(typeOfElement);
  element.className = className;

  return element;
}

attachEvents();
