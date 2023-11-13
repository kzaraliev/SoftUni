import { useEffect, useState } from "react";
import CharacterListItem from "./CharacterListItem";
import styles from "./CharacterList.module.css";

const base_url = "https://swapi.dev/api";

export default function CharacterList() {
  const [characters, setCharacters] = useState([]);

  useEffect(() => {
    //Stop fetch request when page is being closed
    const abortController = new AbortController();

    fetch(`${base_url}/people`, { signal: abortController.signal })
      .then((res) => res.json())
      .then((data) => {
        setCharacters(data.results);
      });

    return () => {
      abortController.abort();
    };
  }, []);

  return (
    <div className={styles.characterList}>
      {characters.map((character, index) => (
        <CharacterListItem key={character.name} id={index + 1} {...character} />
      ))}
    </div>
  );
}
