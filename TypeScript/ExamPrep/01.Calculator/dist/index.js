function Calc(num1, operator, num2) {
    let result = null;
    switch (operator) {
        case "+":
            result = (num1 + num2).toFixed(2);
            break;
        case "-":
            result = (num1 - num2).toFixed(2);
            break;
        case "/":
            result = (num1 / num2).toFixed(2);
            break;
        case "*":
            result = (num1 * num2).toFixed(2);
            break;
        default:
            result = "Non existing operator!";
            break;
    }
    return result;
}
const result = Calc(5, "-", 12);
console.log(result);
