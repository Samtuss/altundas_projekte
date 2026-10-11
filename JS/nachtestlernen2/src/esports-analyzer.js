const fs = require('fs');
const path = require('path');
const _ = require('lodash');

function readFile () {
    const filepath = path.join(__dirname, '..', 'data', 'championship.json');
    const data = fs.readFileSync(filepath, 'utf8');
    console.log(__dirname);
    return JSON.parse(data);

}

function getChampionshipName() {
    const data = readFile();
    //console.log(data);

    return data.championship.name;
}

function getPlayerCount() {
    const data = readFile();
    //console.log(data);

    return data.players.length;
}

function getGameNames() {
    const data = readFile();
    //console.log(data);
    const gameNames = [];

    _.forEach(data.games, function (game) {
        gameNames.push(game.name);
    })
    return gameNames;
}

function getGameReleases() {
    const data = readFile();
    //console.log(data);
    const gameReleases = {};

    _.forEach(data.games, function (game) {
        if (gameReleases[game.name] === undefined) {
            gameReleases[game.name] = game.founded
        }
    })
    return gameReleases;
}

function getResultOf(firstName1, lastName1, tournament1) {
    const data = readFile();
    //console.log(data);
    let helper = null;
    _.forEach(data.players, function (player) {
        if (player.firstName === firstName1 && player.lastName === lastName1) {
            _.forEach(player.tournaments, function (tournament) {
                if (tournament.name === tournament1) {
                    helper = tournament.result;
                }
            })
        }
    })
    return helper;
}

function getAllRoles() {
    const data = readFile();
    //console.log(data);

    const roles = [];
    _.forEach(data.players, function (player) {
        _.forEach(player.roles, function (role) {
            if (!roles.includes(role)) {
                roles.push(role);
            }
        })
    })
    return _.sortBy(roles);
}

function getPlayersByGame(game1) {
    const data = readFile();
    //console.log(data);

    const namesArr = [];
    _.forEach(data.players, function (player) {
        if (player.game === game1) {
            namesArr.push(`${player.firstName} ${player.lastName}`);
        }
    })

    if (namesArr.length < 1) {
        return [];
    }
    else {
        return _.sortBy(namesArr, "lastName");
    }
}

module.exports = {
    getChampionshipName,
    getPlayerCount,
    getGameNames,
    getGameReleases,
    getResultOf,
    getAllRoles,
    getPlayersByGame
}