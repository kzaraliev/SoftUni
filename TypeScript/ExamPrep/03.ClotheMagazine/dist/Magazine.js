"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Magazine = void 0;
class Magazine {
    type;
    capacity;
    clothes;
    constructor(type, capacity) {
        (this.type = type), (this.capacity = capacity), (this.clothes = []);
    }
    getSortedClothes() {
        return this.clothes.sort((a, b) => a.size - b.size);
    }
    addCloth(cloth) {
        if (this.clothes.length < this.capacity) {
            this.clothes.push(cloth);
        }
    }
    removeCloth(color) {
        const index = this.clothes.findIndex((c) => c.color === color);
        if (index !== -1) {
            this.clothes.splice(index, 1);
            return true;
        }
        return false;
    }
    getSmallestCloth() {
        if (!this.clothes.length) {
            return {};
        }
        if (this.clothes.length === 1) {
            return this.clothes[0];
        }
        return this.getSortedClothes()[0];
    }
    getCloth(color) {
        return this.clothes.find((c) => c.color === color);
    }
    getClothCount() {
        return this.clothes.length;
    }
    report() {
        const sortClothes = this.getSortedClothes();
        const clothesForReport = sortClothes
            .map((c) => c.toString())
            .join("\n");
        return `${this.type} magazine contains:\n${clothesForReport}`;
    }
}
exports.Magazine = Magazine;
