function getInfo() {
  const busStopID = document.querySelector("#stopId").value;
  const list = document.querySelector("ul");
  list.innerHTML = "";
  const stopName = document.querySelector("#stopName");

  fetch(`http://localhost:3030/jsonstore/bus/businfo/${busStopID}`)
    .then((res) => res.json())
    .then((busStop) => {
      stopName.textContent = busStop.name;

      Object.entries(busStop.buses).map(([busNumber, timeInMinutes]) => {
        const li = document.createElement("li");
        li.textContent = `Bus ${busNumber} arrives in ${timeInMinutes} minutes`;

        list.appendChild(li);
      });
    })
    .catch(() => {
      stopName.textContent = "Error";
    });
}
