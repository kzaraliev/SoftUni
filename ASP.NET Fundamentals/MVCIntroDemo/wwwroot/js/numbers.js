function setLimit() {
    const num = document.getElementById("limitInput").value || 50;

    window.location = "https://localhost:7076/numbers/limit?number=" + num;
}