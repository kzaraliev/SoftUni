function movieInfo(input) {
  const movies = [];

  function findMovie(movieName) {
    return movies.find((movie) => movie.name === movieName);
  }

  function printMovies() {
    const completeMovies = movies.filter(
      (movie) => movie.name && movie.director && movie.date
    ).forEach((movie) =>{
       console.log(JSON.stringify(movie)); 
    })

  }

  for (const line of input) {
    if (line.startsWith("addMovie")) {
      const movieName = line.substring(9);
      const movie = { name: movieName };
      movies.push(movie);
    } else if (line.includes("directedBy")) {
      const [movieName, director] = line.split(" directedBy ");
      const movie = findMovie(movieName);
      if (movie) {
        movie.director = director;
      }
    } else if (line.includes("onDate")) {
      const [movieName, date] = line.split(" onDate ");
      const movie = findMovie(movieName);
      if (movie) {
        movie.date = date;
      }
    }
  }

  printMovies();
}

movieInfo([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
