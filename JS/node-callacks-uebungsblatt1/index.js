/*const extractData = require('./extractor');

extractData('./politicians.json', './result.json', (err) => {
    if (err) {
        console.error('Fehler:', err);
    }
});*/

const labba = require('./extractor');
labba('./politicians.json', './names.json', (err => {
    if (err) throw err;
}));