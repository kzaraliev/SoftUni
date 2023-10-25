import { useState } from "react";

export default function Timer(props) {
  const [time, setTime] = useState(props.startTime); //Pass initial state

  //useEffect - better than setTimeout
  setTimeout(() => {
    setTime(time + 1); //Update the value 0 and call again Timer function 
  }, 1000);

  return (
    <div>
      <h3>Timer</h3>
      <p>{time}</p>
    </div>
  );
}
