import { Drink } from "./Drink";

export class VendingMachine {
  private buttonCapacity: number;
  private drinks: Drink[];

  constructor(buttonCapacity: number) {
    this.buttonCapacity = buttonCapacity;
    this.drinks = [];
  }

  addDrink(drink: Drink): void {
    if (this.buttonCapacity > this.drinks.length) {
      this.drinks.push(drink);
    }
  }

  removeDrink(name: string): boolean {
    const index = this.drinks.findIndex((drink) => drink.name === name);
    if (index !== -1) {
      this.drinks.splice(index, 1);
      return true;
    }
    return false;
  }

  getLongest(): string {
    if (this.drinks.length === 0) return "";
    return this.drinks
      .reduce((prev, current) =>
        prev.volume > current.volume ? prev : current
      )
      .toString();
  }

  getCheapest(): string {
    if (this.drinks.length === 0) return "";
    return this.drinks
      .reduce((prev, current) => (prev.price < current.price ? prev : current))
      .toString();
  }

  buyDrink(name: string): string {
    const drink = this.drinks.find((drink) => drink.name === name);
    if (!drink) return "Drink not found";
    return drink.toString();
  }

  getCount(): number {
    return this.drinks.length;
  }

  report(): string {
    const drinksForReport = this.drinks.map((c) => c.toString()).join("\n");

    return `Drinks available:\n${drinksForReport}`;
  }
}
