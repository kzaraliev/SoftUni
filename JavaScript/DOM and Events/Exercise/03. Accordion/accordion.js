function toggle() {
    let button = document.querySelector(".button");

    if (button.textContent === "More") {
        button.textContent = "Less";
        document.querySelector("#extra").style.display = "block";
    }
    else{
        button.textContent = "More"
        document.querySelector("#extra").style.display = "none";
    }
}