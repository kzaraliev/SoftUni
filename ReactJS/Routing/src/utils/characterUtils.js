export const normalizeName = (name) => {
  return name.replace(/ /g, "-").toLowerCase();
};
