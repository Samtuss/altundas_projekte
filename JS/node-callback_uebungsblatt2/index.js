const fs = require('fs');
const path = require('path');
const _ = require('lodash');

const files = [
    "Dracula.txt",
    "Oliver Twist.txt",
    "Paradise Lost.txt",
    "Peter Pan.txt",
    "The Adventures of Tom Sawyer.txt"
]

function readAndCountLines(filePath, callback) {
fs.readFile(filePath, (err, data) => {
    if (err) return callback(err);

    return data.split('\n').length;
})
}

function calculateTotalLines(filePaths, callback) {
    filePaths.forEach(filePath => {
        let counter = 0;
        let callbackCounter = 0;
        readAndCountLines(filePath, (err, data) => {
            if (err) return callback(err);

            callbackCounter++;
            counter += data;

            if (callbackCounter === filePaths.length) {
                callback(undefined, counter);
            }
        })
    })
}

function processFiles(filePaths, callback) {
    let result = [];
    let callbackCounter = 0;

    filePaths.forEach(filePath => {
    readAndCountLines(filePath, (err, data) => {
        if (err) {
            result.push({file: filePath, lines: -1});
            return;
        }
        callbackCounter++;
        result.push({file: filePath, lines: data});

        if (callbackCounter === filePaths.length) { // result.length
            callback(undefined, result);

        }

    })
})
}

function summarizeResults(results, callback) {

}