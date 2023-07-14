function displayLoadingBar(num) {
  if (num === 100) {
    console.log("100% Complete!");
    console.log("[%%%%%%%%%%]");
    return;
  }

  let readyBars = num / 10;

  let arrBars = [];
  for (let index = 0; index < readyBars; index++) {
    arrBars.push("%");
  }

  for (let index = arrBars.length;  index < 10; index++) {
    arrBars.push(".");
  }
  console.log(`${num}% [${arrBars.join("")}]`);
  console.log("Still loading...");
}

displayLoadingBar(40)