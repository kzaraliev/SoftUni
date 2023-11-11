import "./App.css";
import UncontrolledForm from "./components/UncontrolledForm";
import ControlledForm from "./components/ControlledForm";
import { useRef } from "react";

function App() {
  const formRef = useRef();

  return (
    <>
      <ControlledForm formRef={formRef} />
      <button type="button" onClick={() => formRef.current.requestSubmit()}>
        Submit
      </button>
    </>
  );
}

export default App;
