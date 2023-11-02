import { useEffect, useState } from "react";

export default function StarWars(props) {
  const [characters, setCharacters] = useState([]);

  useEffect(() => {
    fetch(`https://swapi.dev/api/people`)
      .then((res) => res.json())
      .then((data) => {
        setCharacters(data.results);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <div>
      <h1>StarWars Characters</h1>

      <ul>
        {characters.map((character) => (
          <li key={character.url}>{character.name}</li>
        ))}
      </ul>
    </div>
  );
}
