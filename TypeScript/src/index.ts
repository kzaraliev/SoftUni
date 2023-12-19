function calculateTax(income: number, taxYear = 2022): number {
  if (taxYear < 2022) {
    return income * 1.2;
  }

  return income * 1.3;
}

calculateTax(10_000);
// calculateTax(10_000, 2022); - override taxYear value in func

//Object
type Employee = {
  readonly id: number;
  name: string;
  retire: (date: Date) => void;
};

let employee: Employee = {
  id: 1,
  name: "Koce",
  retire: (date: Date) => {
    console.log(date);
  },
};

//Union type
function kgToLbs(weight: number | string): number {
  if (typeof weight === "number") {
    return weight * 2.2;
  } else {
    return parseInt(weight) * 2.2;
  }
}

kgToLbs(10);
kgToLbs("10kg");

//Literal
type Quantity = 50 | 100;
type Metric = "cm" | "inch";
let quantity: Quantity = 100;
