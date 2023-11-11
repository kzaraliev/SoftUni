import { useEffect, useRef, useState } from "react";
import styles from "./ControlledForm.module.css";

const FORM_KEYS = {
  username: "username",
  password: "password",
  gender: "gender",
  hobbies: "hobbies",
};

const formInitialState = {
  username: "",
  password: "",
  gender: "female",
  swimming: false,
  shopping: false,
  running: false,
};

export default function ControlledForm({ formRef }) {
  const usernameInputRef = useRef();
  const [formValues, setFormValues] = useState(formInitialState);
  const [errors, setErrors] = useState({});

  //Focus username input on load
  useEffect(() => {
    usernameInputRef.current.focus();
  }, []);

  const changeHandler = (e) => {
    setFormValues((state) => ({
      ...state,
      [e.target.name]: e.target.value,
    }));
  };

  const onCheckboxChange = (e) => {
    setFormValues((state) => ({
      ...state,
      [e.target.name]: e.target.checked,
    }));
  };

  const resetFormHandler = () => {
    setFormValues(formInitialState);
    setErrors({});
  };

  const submitHandler = (e) => {
    e.preventDefault();
    console.log(formValues);
    resetFormHandler();
  };

  const nameValidator = () => {
    console.log(formValues.username.length);
    if (formValues.username.length < 2) {
      setErrors((state) => ({ ...state, username: "Name is too short" }));
    } else {
      if (errors.username) {
        setErrors((state) => ({ ...state, username: "" }));
      }
    }
  };

  return (
    <>
      <h1>Controlled Form</h1>
      <form ref={formRef} onSubmit={submitHandler}>
        <div>
          <label htmlFor={FORM_KEYS.username}>Username: </label>
          <input
            ref={usernameInputRef}
            type="text"
            name={FORM_KEYS.username}
            id={FORM_KEYS.username}
            value={formValues.username}
            onChange={changeHandler}
            onBlur={nameValidator}
            className={errors.username && styles.inputError}
          />
          {errors.username && (
            <p className={styles.errorMessage}>{errors.username}</p>
          )}
        </div>
        <div>
          <label htmlFor={FORM_KEYS.password}>Password: </label>
          <input
            type="password"
            name={FORM_KEYS.password}
            id={FORM_KEYS.password}
            value={formValues.password}
            onChange={changeHandler}
          />
        </div>
        <div>
          <label htmlFor={FORM_KEYS.gender}>Gender: </label>
          <select
            name={FORM_KEYS.gender}
            id={FORM_KEYS.gender}
            onChange={changeHandler}
            value={formValues.gender}
          >
            <option value="male">Male</option>
            <option value="female">Female</option>
          </select>
        </div>

        <div>
          <h3>Hobbies</h3>
          <label htmlFor="swimming">Swimming</label>
          <input
            type="checkbox"
            name="swimming"
            id="swimming"
            checked={formValues.swimming}
            onChange={onCheckboxChange}
          />
          <label htmlFor="shopping">Shopping</label>
          <input
            type="checkbox"
            name="shopping"
            id="shopping"
            checked={formValues.shopping}
            onChange={onCheckboxChange}
          />
          <label htmlFor="running">Running</label>
          <input
            type="checkbox"
            name="running"
            id="running"
            checked={formValues.running}
            onChange={onCheckboxChange}
          />
        </div>

        <div>
          <button type="submit" disabled={Object.values(errors).some((x) => x)}>
            Register
          </button>
          <button type="button" onClick={resetFormHandler}>
            Reset
          </button>
        </div>
      </form>
    </>
  );
}
