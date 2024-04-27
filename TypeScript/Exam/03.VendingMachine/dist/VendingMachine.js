"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VendingMachine = void 0;
class VendingMachine {
    buttonCapacity;
    drinks;
    constructor(buttonCapacity) {
        this.buttonCapacity = buttonCapacity;
        this.drinks = [];
    }
    addDrink(drink) {
        if (this.buttonCapacity > this.drinks.length) {
            this.drinks.push(drink);
        }
    }
    removeDrink(name) {
        const index = this.drinks.findIndex((drink) => drink.name === name);
        if (index !== -1) {
            this.drinks.splice(index, 1);
            return true;
        }
        return false;
    }
    getLongest() {
        if (this.drinks.length === 0)
            return "";
        return this.drinks
            .reduce((prev, current) => prev.volume > current.volume ? prev : current)
            .toString();
    }
    getCheapest() {
        if (this.drinks.length === 0)
            return "";
        return this.drinks
            .reduce((prev, current) => (prev.price < current.price ? prev : current))
            .toString();
    }
    buyDrink(name) {
        const drink = this.drinks.find((drink) => drink.name === name);
        if (!drink)
            return "Drink not found";
        return drink.toString();
    }
    getCount() {
        return this.drinks.length;
    }
    report() {
        const drinksForReport = this.drinks.map((c) => c.toString()).join("\n");
        return `Drinks available:\n${drinksForReport}`;
    }
}
exports.VendingMachine = VendingMachine;
