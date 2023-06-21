function arrRotation(arr, number) {
    for (let index = 0; index < number; index++) {
        let movingNum = arr.shift();
        arr.push(movingNum);
    }

    console.log(arr.join(" "));
}

arrRotation([51, 47, 32, 61, 21], 2);