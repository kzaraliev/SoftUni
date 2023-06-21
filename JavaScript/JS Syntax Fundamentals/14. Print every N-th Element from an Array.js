function printNthNumber(arr, num) {
  let arrToPrint = [];
  for (let index = 0; index < arr.length; index += num) {
    arrToPrint.push(arr[index]);
  }

  return arrToPrint;
}

printNthNumber(["5", "20", "31", "4", "20"], 2);
