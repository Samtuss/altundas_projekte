const fs = require('fs');
const path = require('path');

const _ = require('lodash');

function readMovieData() {
    try {
        const filePath = path.join(__dirname, '..', 'data', 'movies.json');
        const data = fs.readFileSync(filePath, 'utf8');
        return JSON.parse(data);
    } catch (error) {
        console.error('Error reading movie data:', error);
        return {};
    }
}

function getAllGenres() {
    const data = readMovieData();
    const genres = [];

    _.forEach(data, (movie_details) => {
        genres.push(movie_details.genre);
    });

    const uniqueGenres = _.uniq(genres);
    const orderedGenres = _.sortBy(uniqueGenres, (genre) => genre.toLowerCase());

    return orderedGenres;
}

function getAverageRatingsByGenre(genre) {
    const data = readMovieData();

    let genreRatings = {};

    // Get all genres
    _.forEach(data, (movie_details) => {
        const currentGenre = movie_details.genre;

        if (genreRatings[currentGenre] === undefined) {
            genreRatings[currentGenre] = {
                count: 0,
                totalRating: 0
            }
        }
        genreRatings[currentGenre].count++;
        genreRatings[currentGenre].totalRating += movie_details.rating;
    })

    const result = {};

    // If genre is provided, calculate average rating for that genre only
    if (genre !== undefined) {
        // Check if the genre exists in the data
        if (genreRatings[genre] === undefined) {
            result[genre] = 0;
            return result;
        }
        result[genre] = _.round(genreRatings[genre].totalRating / genreRatings[genre].count, 1);
        return result;
    }

    // If no genre is provided, calculate average ratings for all genres
    _.forEach(genreRatings, (value, key) => {
        result[key] = _.round(value.totalRating / value.count, 1);
    });

    return result;
}

function getTopMovieByYear() {
    const data = readMovieData();
    const topMovies = {};

    _.forEach(data, (details, title) => {
        const {year, revenue} = details;

        if (topMovies[year] === undefined) {
            topMovies[year] = {
                title: title,
                revenue: revenue
            }
        } else {
            if (revenue > topMovies[year].revenue) {
                topMovies[year] = {
                    title: title,
                    revenue: revenue
                }
            }
        }
    })
    return topMovies;
}

function getTop5Movies() {
    const topMovies = [];

    // Get the top movie by year
    const moviesByYear = getTopMovieByYear();

    // Convert the object to an array of objects with title, year, and revenue
    _.forEach(moviesByYear, (details, year) => {
        topMovies.push({
            title: details.title,
            year: year,
            revenue: details.revenue
        });
    });

    // Sort the movies by revenue in descending order and get the top 5
    const sortedTopMovies = _.orderBy(topMovies, ['revenue'], ['desc']);
    return sortedTopMovies.slice(0, 5);
}

module.exports = {
    getAllGenres,
    getAverageRatingsByGenre,
    getTopMovieByYear,
    getTop5Movies
}
