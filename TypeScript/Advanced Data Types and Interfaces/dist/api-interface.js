"use strict";
const API_URL = "https://jsonplaceholder.typicode.com/users";
const getUsers = () => {
    fetch(API_URL, { method: "GET" })
        .then((res) => {
        return res.json();
    })
        .then((users) => {
        users.forEach((user) => {
            console.log(`${user.id}. ${user.username} => ${user.company.name}`);
        });
    })
        .catch((err) => console.log(`Error: ${err}`));
};
getUsers();
