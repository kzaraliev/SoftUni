function createHeroRegister(input) {
  const heroes = [];

  for (const heroData of input) {
    const [heroName, heroLevel, itemsString] = heroData.split(" / ");
    const items = itemsString ? itemsString.split(", ") : [];

    const hero = {
      name: heroName.trim(),
      level: Number(heroLevel),
      items: items,
    };

    heroes.push(hero);
  }

  heroes.sort((a, b) => a.level - b.level);

  for (const hero of heroes) {
    console.log(`Hero: ${hero.name}`);
    console.log(`level => ${hero.level}`);
    console.log(`items => ${hero.items.join(", ")}`);
  }
}

createHeroRegister([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
