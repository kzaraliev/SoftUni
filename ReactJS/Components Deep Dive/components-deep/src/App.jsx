import React, { useState, useEffect } from "react";
import StarWars from "./Starwars";
import styles from "./App.module.css";

function App() {
  const [numbers, setNumbers] = useState([1, 2, 3, 4, 5]);
  const [count, setCount] = useState(0);

  useEffect(() => {
    // console.log('Mount component');
  }, []);

  useEffect(() => {
    // console.log(`Update component - ${numbers.length}`)
  }, [count]);

  useEffect(() => {
    // setTimeout(() => setCount(s => s + 1), 1000);
  }, [count]);

  const onClick = () => {
    setNumbers((oldState) => oldState.slice(0, oldState.length - 1));
  };

  return (
    <div>
      <StarWars></StarWars>

      <h3>Count: {count}</h3>
      <ul>
        {numbers.map((number, index) => (
          <li data-key={index} key={index} className={styles.listItem}>
            {number * 2}
          </li>
        ))}
      </ul>

      <button onClick={onClick}>Remove</button>
      <button onClick={() => setCount((c) => c + 1)}>+</button>
    </div>
  );
}

export default App;
