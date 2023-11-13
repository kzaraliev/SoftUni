import Navigation from "./components/navigation";
import { Routes, Route } from "react-router-dom";
import Home from "./components/Home";
import About from "./components/About";
import Contacts from "./components/Contacts";
import CharacterList from "./components/CharacterList";
import CharacterDetails from "./components/CharacterDetails";
import NotFount from "./components/NotFount";

function App() {
  return (
    <>
      <Navigation />

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about/*" element={<About />} />
        <Route path="/contacts" element={<Contacts />} />
        <Route path="/characters" element={<CharacterList />} />
        <Route path="/characters/:id" element={<CharacterDetails />} />
        <Route path="*" element={<NotFount />} />
      </Routes>

      <footer>All rights reserved</footer>
    </>
  );
}

export default App;
