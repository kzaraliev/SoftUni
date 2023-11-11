import { useState } from "react";

export default function ControlledForm() {
  const [usernameValue, setUsernameValue] = useState("");
  const [passwordValue, setPasswordValue] = useState("");

  const usernameChangeHandler = (e) => {
    setUsernameValue(e.target.value);
  };

  const passwordChangeHandler = (e) => {
    setPasswordValue(e.target.value);
  };

  const resetFormHandler = () => {
    setUsernameValue("");
    setPasswordValue("");
  };

  const submitHandler = (e) => {
    e.preventDefault();
    console.log(usernameValue);
    console.log(passwordValue);
    resetFormHandler();
  };

  return (
    <>
      <h1>Controlled Form</h1>
      <form>
        <div>
          <label htmlFor="username">Username: </label>
          <input
            type="text"
            name="username"
            id="username"
            value={usernameValue}
            onChange={usernameChangeHandler}
          />
        </div>
        <div>
          <label htmlFor="password">Password: </label>
          <input
            type="password"
            name="password"
            id="password"
            value={passwordValue}
            onChange={passwordChangeHandler}
          />
        </div>
        <div>
          <button onClick={submitHandler}>Register</button>
          <button type="button" onClick={resetFormHandler}>
            Reset
          </button>
        </div>
      </form>
    </>
  );
}
