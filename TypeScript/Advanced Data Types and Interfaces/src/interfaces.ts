interface User {
  githubToken: string;
}

interface Admin extends User {
  specialRights: boolean;
}

interface PersonDetails {
    firstName: string;
    address: string;
    age: number
}

class Person implements PersonDetails{
    firstName = "";
    address = "";
    age = -1;

}