const analyzer = require('./src/esports-analyzer.js')

let task1 = analyzer.getChampionshipName();
console.log(task1);

let task2 = analyzer.getPlayerCount();
console.log(task2);

let task3 = analyzer.getGameNames();
console.log(task3);

let task4 = analyzer.getGameReleases();
console.log(task4);

let task5 = analyzer.getResultOf("Sarah", "Köhler", "Winter Masters 2026");
console.log(task5);

let task6 = analyzer.getAllRoles();
console.log(task6);

let task7 = analyzer.getPlayersByGame("Tetris");
console.log(task7);