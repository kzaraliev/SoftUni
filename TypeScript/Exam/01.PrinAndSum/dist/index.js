function solve(startNumber, endNumber) {
    if (endNumber < startNumber) {
        throw new Error("Invalid Input");
    }
    let numbers = [];
    for (let i = startNumber; i < endNumber + 1; i++) {
        numbers.push(i);
    }
    let sum = numbers.reduce((accumulator, current) => accumulator + current, 0);
    console.log(numbers.join(" "));
    console.log(`Sum: ${sum}`);
}
solve(50, 60);
