//String
let str: string = "Hello";
str = `Hello, ${1234}`;
console.log(str);

// Number
let a: number = 5.5;
console.log(a);

//Boolean
let hasAuth: boolean = true;
console.log(hasAuth);

//Symbols
let symbol1: symbol = Symbol("test");
console.log(symbol1);

// Undefined
let user: object | undefined;
let person: object | null = null;

console.log({ user });
console.log({ person });

setTimeout(() => {
  user = { username: "user123" };
  person = { username: "Pesho" };
  console.log({ user });
  console.log({ person });
}, 3000);

if (true) {
  user = { username: "Pesho" };
}
console.log(user);

// Array
const arrayNumbers: number[] = [1, 2, 3];
const arrayStrings: string[] = ["Hello", "its", "me!"];

//Tuple
let tuple: [number, string] = [123, "Hi"];
console.log(tuple);

//Enum
enum DaysOfWorkWeek {
  M,
  T,
  W,
  Th,
  F,
}

console.log(DaysOfWorkWeek);

//Any
let unknownObject: unknown = ["Test"];
unknownObject = 5;
unknownObject = true;
console.log(unknownObject);

//Function
function myPrint(input: string): void {
  console.log(input);
}

function myPrintString(input: string): string {
  return "Bonjour";
}

myPrint("Hello");

//Optional params
//param2 is optional
function optionalParams(param1: number, param2?: string): void {
  console.log({ param1, param2 });
}

optionalParams(1, "Hi")
optionalParams(1)

//Return types in Functions
const getNum = (): number => 5; 
const getNum2 = (): number => {
    return 5
}
const getNum3 = function(): number {
    return 5;
}
const getNum4: () => number = () => {
    return 5
}