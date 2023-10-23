import "../node_modules/react/umd/react.production.min.js";
import "../node_modules/react-dom/umd/react-dom.production.min.js";

var rootDomElement = document.getElementById("root");

var root = ReactDOM.createRoot(rootDomElement);

var Footer = function Footer() {
  return React.createElement(
    "div",
    { className: "site-footer" },
    React.createElement(
      "p",
      null,
      "All rights reserved \xA9"
    )
  );
};

var headerJSX = React.createElement(
  "div",
  null,
  React.createElement(
    "header",
    { className: "site-header" },
    React.createElement(
      "h1",
      null,
      "Hello from JSX"
    ),
    React.createElement(
      "h2",
      null,
      "The best!"
    ),
    React.createElement(
      "p",
      null,
      "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Obcaecati est dignissimos totam vel rem repellat excepturi accusantium temporibus adipisci ea. Numquam ea qui hic id, labore harum suscipit facilis tempora?"
    )
  ),
  React.createElement(Footer, null)
);

root.render(headerJSX);