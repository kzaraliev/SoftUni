import { useEffect } from "react";

export default function Contacts() {
  useEffect(() => {
    console.log("Mount or update");
    return() => {
      console.log("On unmount");
    }
  }, [])

  return (
    <>
      <h2>Contact Page</h2>
      <label htmlFor="">Title</label>
      <br />
      <input type="text" /> <br />
      <label htmlFor="">Description</label>
      <br />
      <textarea name="" id="" cols="30" rows="10"></textarea> <br />
      <input type="submit" />
    </>
  );
}
