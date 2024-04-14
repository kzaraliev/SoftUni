const API_URL: string = "https://jsonplaceholder.typicode.com/users";

type Address = {
  street: string;
  suite: string;
  city: string;
  zipcode: string;
  geo: Geo;
};

type Geo = {
  lat: string;
  lng: string;
};

type Company = {
  name: string;
  catchPhrase: string;
  bs: string;
};

type UserFetch = {
  id: number;
  name: string;
  username: string;
  email: string;
  address: Address;
  phone: string;
  website: string;
  company: Company;
};

const getUsers = (): void => {
  fetch(API_URL, { method: "GET" })
    .then((res) => {
      return res.json();
    })
    .then((users: UserFetch[]) => {
      users.forEach((user) => {
        console.log(`${user.id}. ${user.username} => ${user.company.name}`);
      });
    })
    .catch((err) => console.log(`Error: ${err}`));
};

getUsers();
