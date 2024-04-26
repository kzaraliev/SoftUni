import { Cloth } from "./Cloth";

export class Magazine {
  private type: string;
  private capacity: number;
  private clothes: Cloth[];

  constructor(type: string, capacity: number) {
    (this.type = type), (this.capacity = capacity), (this.clothes = []);
  }

  getSortedClothes(): Cloth[] {
    return this.clothes.sort((a, b) => a.size - b.size);
  }

  addCloth(cloth: Cloth): void {
    if (this.clothes.length < this.capacity) {
      this.clothes.push(cloth);
    }
  }

  removeCloth(color: string): boolean {
    const index = this.clothes.findIndex((c) => c.color === color);

    if (index !== -1) {
      this.clothes.splice(index, 1);
      return true;
    }

    return false;
  }

  getSmallestCloth(): Cloth {
    if (!this.clothes.length) {
      return {} as Cloth;
    }

    if (this.clothes.length === 1) {
      return this.clothes[0];
    }

    return this.getSortedClothes()[0];
  }

  getCloth(color: string): Cloth {
    return this.clothes.find((c) => c.color === color);
  }

  getClothCount(): number {
    return this.clothes.length;
  }

  report(): string {
    const sortClothes = this.getSortedClothes();
    const clothesForReport = sortClothes
      .map((c) => c.toString())
      .join("\n");

    return `${this.type} magazine contains:\n${clothesForReport}`;
  }
}
