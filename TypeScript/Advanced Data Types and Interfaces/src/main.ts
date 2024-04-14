type User1 = {
  username: string;
  email: string;
  age?: number;
};

const user: User1 = { username: "kosebose", email: "kose@gmail.com" };

type Animal = {
  furColor: string;
  legsNumber: number;
  type: string;
};

type AnimalUserType = Animal & User1;

const animalUser: AnimalUserType = {
  furColor: "red",
  legsNumber: 3,
  type: "fish",
  username: "fishmen123",
  email: "fish@gmail.com",
};
