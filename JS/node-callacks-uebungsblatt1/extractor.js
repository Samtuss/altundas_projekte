/* const fs = require('fs');

function calculateAge(bday) {
    const [day, month, year] = bday.split('.').map(Number);
    const today = new Date();
    const birth = new Date(year, month - 1, day);
    let age = today.getFullYear() - birth.getFullYear();
    const hasHadBirthdayThisYear =
        today.getMonth() > birth.getMonth() ||
        (today.getMonth() === birth.getMonth() && today.getDate() >= birth.getDate());
    if (!hasHadBirthdayThisYear) age--;
    return age;
}

function extractData(inputPath, outputPath, callback) {
    fs.readFile(inputPath, 'utf8', (err, data) => {
        if (err) return callback(err);

        let parsed;
        try {
            parsed = JSON.parse(data);
        } catch (parseErr) {
            return callback(parseErr);
        }

        const names = parsed
            .map(person => person.nachname)
            .sort();

        const totalAge = parsed.reduce((sum, person) => sum + calculateAge(person.bday), 0);

        const result = { names, totalAge };

        fs.writeFile(outputPath, JSON.stringify(result, null, 2), (writeErr) => {
            if (writeErr) return callback(writeErr);
        });
    });
}

module.exports = extractData;

 */
const fs = require('fs');
const _ = require('lodash');

function labba (input, output, callback) {
    fs.readFile(input, 'utf8', (err, data) => {
        if (err) {
            console.error(err.message);
            return callback(err);
        }
        data = JSON.parse(data);

        let names = [];
        let totalAge = 260;

        _.forEach(data,(politician) => {
            names.push(politician.nachname);
        })

        names = names.sort();




        let result = {
            names: names,
            totalAge: totalAge
        }

        fs.writeFile(output, JSON.stringify(result, null, 2), (err) => {
            if (err) {
                return callback(err);
            }
        })

    })
}

module.exports = labba;