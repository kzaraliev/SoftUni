function solve() {
  const departButton = document.querySelector("#depart");
  const arriveButton = document.querySelector("#arrive");
  const infoSpan = document.querySelector(".info");

  let busStopInfo = {
    name: "",
    next: "depot"
  }

  function depart() {
    fetch(`http://localhost:3030/jsonstore/bus/schedule/${busStopInfo.next}`)
      .then((res) => res.json())
      .then((data) => {
        busStopInfo = data;
        departButton.disabled = true;
        arriveButton.disabled = false;

        infoSpan.textContent = `Next stop ${busStopInfo.name}`;
      });
  }

  async function arrive() {
    departButton.disabled = false;
    arriveButton.disabled = true;

    infoSpan.textContent = `Arriving at ${busStopInfo.name}`;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
