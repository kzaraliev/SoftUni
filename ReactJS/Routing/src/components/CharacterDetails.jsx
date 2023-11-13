import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

export default function CharacterDetails({}) {
  const { id } = useParams();
  const [character, setCharacters] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    fetch(`https://swapi.dev/api/people/${id}`)
      .then((res) => {
        if (!res.ok) {
          throw new Error("Not found");
        }
        return res.json();
      })
      .then(setCharacters)
      .catch((err) => {
        navigate("/characters");
      });
  }, [id]);
  return (
    <>
      <h1>{character.name}</h1>
      <p>
        Lorem ipsum dolor sit amet consectetur, adipisicing elit. Quam
        doloremque placeat ea quae tempore, delectus voluptates dolorum
        recusandae. Nisi dignissimos est incidunt sint provident magni
        distinctio consequuntur aliquid illo ducimus?
      </p>
    </>
  );
}
