function solve(users) {
  users.forEach((employee) => {
    console.log(`Name: ${employee} -- Personal Number: ${employee.length}`);
  })
}

solve([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);
