"use strict";
//String
let str = "Hello";
str = `Hello, ${1234}`;
console.log(str);
// Number
let a = 5.5;
console.log(a);
//Boolean
let hasAuth = true;
console.log(hasAuth);
//Symbols
let symbol1 = Symbol("test");
console.log(symbol1);
// Undefined
let user;
let person = null;
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
const arrayNumbers = [1, 2, 3];
const arrayStrings = ["Hello", "its", "me!"];
//Tuple
let tuple = [123, "Hi"];
console.log(tuple);
//Enum
var DaysOfWorkWeek;
(function (DaysOfWorkWeek) {
    DaysOfWorkWeek[DaysOfWorkWeek["M"] = 0] = "M";
    DaysOfWorkWeek[DaysOfWorkWeek["T"] = 1] = "T";
    DaysOfWorkWeek[DaysOfWorkWeek["W"] = 2] = "W";
    DaysOfWorkWeek[DaysOfWorkWeek["Th"] = 3] = "Th";
    DaysOfWorkWeek[DaysOfWorkWeek["F"] = 4] = "F";
})(DaysOfWorkWeek || (DaysOfWorkWeek = {}));
console.log(DaysOfWorkWeek);
//Any
let unknownObject = ["Test"];
unknownObject = 5;
unknownObject = true;
console.log(unknownObject);
//Function
function myPrint(input) {
    console.log(input);
}
function myPrintString(input) {
    return "Bonjour";
}
myPrint("Hello");
//Optional params
//param2 is optional
function optionalParams(param1, param2) {
    console.log({ param1, param2 });
}
optionalParams(1, "Hi");
optionalParams(1);
//Return types in Functions
const getNum = () => 5;
const getNum2 = () => {
    return 5;
};
const getNum3 = function () {
    return 5;
};
const getNum4 = () => {
    return 5;
};
