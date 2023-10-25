import { useState } from "react";

export default function Counter(props) {
  const [count, setCount] = useState(0);

  const onIncrementClick = () => {
    setCount((oldValue) => oldValue + 1);
  };

  const onDecreaseClick = () => {
    setCount((oldValue) => oldValue - 1); //better version
  };

  const onClearCounter = () => {
    setCount(0); //if we don't care about previous value
  };

  //   if (count < 0) {
  //     return <h1>Invalid count!</h1>;
  //   }

  let message = null;

  switch (count) {
    case 1:
      message = "First blood";
      break;
    case 2:
      message = "Double kill";
      break;
    case 3:
      message = "Triple kill";
      break;
    default:
      message = "Monster kill";
  }

  return (
    <div>
      <h2>Counter</h2>

      {count < 0 ? <p>Invalid count!</p> : <p>Valid count!</p>}

      {count == 0 && <p>Please start incrementing</p>}

      <h4>{message}</h4>

      <p>Count: {count}</p>

      <button onClick={onDecreaseClick}>-</button>
      <button onClick={onClearCounter}>clear</button>
      <button onClick={onIncrementClick}>+</button>
    </div>
  );
}
