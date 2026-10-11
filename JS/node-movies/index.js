

const analyzer = require("./.src/movie-analyzer");

let task1 = analyzer.getAllGenres();
console.log(task1);

let task2 = analyzer.getAverageRatingsByGenre();
console.log(task2);

let task3 = analyzer.getTopMovieByYear();
console.log(task3);

let task4 = analyzer.getTop5Movies();
console.log(task4)
