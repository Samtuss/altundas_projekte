// npmjs.com die modules suchen
// dann im terminal folgendes hineinschreiben:
//      npm init
// dann enter bis zum Ende
// dann können wir schreiben:
//      npm install lodash oder chalk oder so

const _ = require('lodash');

const summe = _.sum([1,2,3,4,5])

console.log(summe);

const result = _.reverse([1,2,3,4,5])

console.log(result);

// CALLENGE:
// 1. Installiere das 3rd Party modul "chalk"
// 2. Verwende chalk um "Guten Tag" in grün it grauem Hintergrund auszugeben

const chalk = require('chalk');


console.log(chalk.green(result))
