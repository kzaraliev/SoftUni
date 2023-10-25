import MovieList from "./components/MovieList";
import Timer from "./components/Timer";
import Counter from "./components/Counter";
import movies from "./assets/movies";
import "./App.css";

function App() {
  return (
    <>
      <h1>My first dynamic react app</h1>
      <Counter />
      <Timer startTime={10} />
      <MovieList movies={movies} headingText="Movie List" />
    </>
  );
}

export default App;
