const API_URL = `http://localhost:3030/jsonstore/grocery`;

const loadBtn = document.querySelector("#load-product");
const addButtonElementGlobal = document.querySelector("#add-product");
const updateButtonElementGlobal = document.querySelector("#update-product");

loadBtn.addEventListener("click", loadProducts);
addButtonElementGlobal.addEventListener("click", addProduct);
updateButtonElementGlobal.addEventListener("click", updateProduct);

const tBody = document.querySelector("#tbody");
const productNameElement = document.querySelector("#product");
const productCountElement = document.querySelector("#count");
const productPriceElement = document.querySelector("#price");

let currentProductId = "";

async function updateProduct(e) {
  e.preventDefault();

  const product = productNameElement.value;
  const count = productCountElement.value;
  const price = productPriceElement.value;

  const productSend = {
    _id: currentProductId,
    product,
    count,
    price,
  };

  await fetch(`${API_URL}/${currentProductId}`, {
    method: "PATCH",
    body: JSON.stringify(productSend),
  });

  clearForm();

  addButtonElementGlobal.disabled = false;
  updateButtonElementGlobal.disabled = true;

  await loadProducts(e);
}

async function addProduct(e) {
  e.preventDefault();
  const product = productNameElement.value;
  const count = productCountElement.value;
  const price = productPriceElement.value;

  if (
    !productNameElement.value ||
    !productCountElement.value ||
    !productPriceElement.value
  ) {
    return;
  }

  const productSend = {
    product,
    count,
    price,
  };

  await fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(productSend),
  });

  clearForm();

  await loadProducts(e);
}

async function loadProducts(e) {
  e.preventDefault();
  const response = await fetch(API_URL);
  const data = await response.json();

  tBody.innerHTML = "";

  const products = Object.values(data);
  products.forEach((product) => {
    const productElement = renderItems(product);
    productElement.setAttribute("data-product-id", product._id);
  });
}

function renderItems(product) {
  const container = createElement("tr", null, null, null, tBody);
  createElement("td", product.product, ["name"], null, container);
  createElement("td", product.count, ["count-product"], null, container);
  createElement("td", product.price, ["product-price"], null, container);
  const buttonsContainer = createElement("td", null, ["btn"], null, container);
  const updateBtn = createElement(
    "button",
    "Update",
    ["update"],
    null,
    buttonsContainer
  );
  const deleteBtn = createElement(
    "button",
    "Delete",
    ["delete"],
    null,
    buttonsContainer
  );

  updateBtn.addEventListener("click", (e) => {
    productNameElement.value = product.product;
    productCountElement.value = product.count;
    productPriceElement.value = product.price;

    currentProductId = container.getAttribute("data-product-id");
    container.remove();

    addButtonElementGlobal.disabled = true;
    updateButtonElementGlobal.disabled = false;
  });

  deleteBtn.addEventListener("click", async (e) => {
    await fetch(`${API_URL}/${product._id}`, {
      method: "DELETE",
    });

    await loadProducts(e);
  });

  return container;
}

function clearForm() {
  productNameElement.value = "";
  productCountElement.value = "";
  productPriceElement.value = "";
}

function createElement(type, textContent, classes, id, parent) {
  const element = document.createElement(type);

  if (textContent) {
    element.textContent = textContent;
  }

  if (classes && classes.length > 0) {
    element.classList.add(...classes);
  }

  if (id) {
    element.setAttribute("id", id);
  }

  if (parent) {
    parent.appendChild(element);
  }

  return element;
}
