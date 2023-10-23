import "../node_modules/react/umd/react.production.min.js";
import "../node_modules/react-dom/umd/react-dom.production.min.js";

const rootDomElement = document.getElementById("root");

const root = ReactDOM.createRoot(rootDomElement);

const Footer = () => (
  <div className="site-footer">
    <p>All rights reserved &copy;</p>
  </div>
);

const headerJSX = (
  <div>
    <header className="site-header">
      <h1>Hello from JSX</h1>
      <h2>The best!</h2>
      <p>
        Lorem ipsum dolor sit, amet consectetur adipisicing elit. Obcaecati est
        dignissimos totam vel rem repellat excepturi accusantium temporibus
        adipisci ea. Numquam ea qui hic id, labore harum suscipit facilis
        tempora?
      </p>
    </header>
    <Footer />
  </div>
);

root.render(headerJSX);
