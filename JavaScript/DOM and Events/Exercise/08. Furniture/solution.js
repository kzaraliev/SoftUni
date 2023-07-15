function solve() {
  const formatButton = document.querySelector("#exercise button");
  formatButton.addEventListener("click", parseFurnitureInput);

  const buyButton = document.querySelector("#exercise button:nth-of-type(2)");
  buyButton.addEventListener("click", buySelectedFurniture);

  Array.from(document.querySelectorAll('input[type="checkbox"]')).forEach(
    (checkbox) => checkbox.removeAttribute("disabled")
  );
}

function buySelectedFurniture() {
  const checkboxes = Array.from(
    document.querySelectorAll('input[type="checkbox"]:checked')
  );
  // Hardest thing in the whole task
  const cart = checkboxes.map(mapCheckboxToObject).reduce(
    (acc, curr) => {
      acc.names.push(curr.name);
      acc.price += curr.price;
      acc.averageDecorationFactor += curr.decFactor / checkboxes.length;

      return acc;
    },
    {
      names: [],
      price: 0,
      averageDecorationFactor: 0,
    }
  );

  const cartTextArea = document.querySelector(
    "#exercise textarea:nth-of-type(2)"
  );
  cartTextArea.value = `
    Bought furniture: ${cart.names.join(", ")}
    Total price: ${cart.price.toFixed(2)}
    Avg Dec Factor: ${cart.averageDecorationFactor.toFixed(2)}
  `;
}

function mapCheckboxToObject(checkbox) {
  const row = checkbox.parentElement.parentElement;
  const name = row.querySelector("td:nth-of-type(2)").innerText;
  const price = Number(row.querySelector("td:nth-of-type(3)").innerText);
  const decFactor = Number(row.querySelector("td:nth-of-type(4)").innerText);

  return { name, price, decFactor };
}

function parseFurnitureInput() {
  const input = JSON.parse(document.querySelector("#exercise textarea").value);
  const tableBody = document.querySelector("tbody");
  // TODO: naming
  const cellCreator = createCellCreator();

  input
    .map(cellCreator.createFurnitureRow)
    .forEach((row) => tableBody.appendChild(row));
}

function createCellCreator() {
  function createImageCell(src) {
    const imageCell = document.createElement("td");
    const image = document.createElement("img");
    image.src = src;
    imageCell.appendChild(image);

    return imageCell;
  }

  function createTextCell(text) {
    const cell = document.createElement("td");
    cell.textContent = text;

    return cell;
  }

  function createCheckboxCell() {
    const checkCell = document.createElement("td");
    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkCell.appendChild(checkbox);

    return checkCell;
  }

  return {
    createFurnitureRow(furniture) {
      const row = document.createElement("tr");

      row.appendChild(createImageCell(furniture.img));
      row.appendChild(createTextCell(furniture.name));
      row.appendChild(createTextCell(furniture.price));
      row.appendChild(createTextCell(furniture.decFactor));
      row.appendChild(createCheckboxCell());

      return row;
    },
  };
}