const fs = require('node:fs');
const path= require('node:path');
const _ = require('lodash');


// WORKING DIRECTORY / ARBEITSVERZEICHNIS
const fullpath = path.join(__dirname, 'school.json');
const rawData = fs.readFileSync(fullpath, 'utf8');
const data = JSON.parse(rawData);

// 1.1 Name der Schule
// alle 4 von denen funktionieren labba nicht
console.log(data.school.name);
console.log(data["school"]["name"]);
console.log(data.school["name"]);
console.log(data["school"].name);

// 1.2 Das Gründungsjahr der Schule
console.log(data.school.founded);

// 1.3
console.log(data.school.website);

// 2.1 Straße der Schule
console.log(data.school.address.street);

// 2.2 PLZ und Stadt in einem Satz
console.log(`Die Schule befindet sich in ${data.school.address.zip} ${data.school.address.city}`);

// 2.3 Breitengrad der Schule (latitude)
console.log("latitude: " + data.school.address.coordinates.latitude)

// 2.4 Name des Klassenvorstands der ersten Klasse (classes[0])
console.log(data.school.classes[0].classTeacher)

// 3.1
console.log(data.school.departments[1])

// 3.2
console.log(data.school.departments.length)

// 3.3
console.log(data.school.classes[0].students[0].firstName)

// 3.4
console.log(data.school.classes[0].students[1].hobbies[0])

// 4.1
console.log(data.school.classes[0].students[2].grades["WMC"])

// 4.2
console.log(data.school.classes[1].students[1].grades["POS"])

// 4.3
console.log(data.school.events[1].location)

// 4.4
console.log(`${data.school.classes[0].students[1].firstName} ${data.school.classes[0].students[1].lastName} ist ${data.school.classes[0].students[1].age} Jahre alt und besucht die ${data.school.classes[0].name}`)

// 5.1
const deps = data.school.departments;
for (const dep of deps) {
    console.log(dep);
}
console.log();

// 5.2 Name aller Events mit Datum
const events1 = data.school.events;

for (const event of events1) {
    console.log(`${event.name} ${event.date}`);
}
console.log();
_.forEach(events1, function(value, key, collection) {
    console.log(`${value.name} ${value.date}`);
})
console.log();

// 5.3
console.log();
const ahifschueler = data.school.classes[0].students;
for (const schuler of ahifschueler) {
    console.log(`${schuler.firstName} ${schuler.lastName}`);
}
console.log();

// 5.4
const helper = 0;
for (const classes of data.school.classes) {
    for (const schuler of classes.students) {
        console.log(`${classes.name}: ${schuler.firstName} ${schuler.lastName}`)
    }
}
console.log();

// 6.1
const nachnamen = [];
_.forEach(data.school.classes, function(klasse) {
    _.forEach(klasse.students, function(student) {
        nachnamen.push(student.lastName);
    })
})
console.log(nachnamen);

// 6.2
const hobbies1 = [];
_.forEach(data.school.classes, function(klasse) {
    _.forEach(klasse.students, function(student) {
        _.forEach(student.hobbies, function(hobby) {
            if (!hobbies1.includes(hobby)) {
                hobbies1.push(hobby);
            }
        })
    })
})
console.log(hobbies1)

// 6.3
// HIER WICHTIG - KLASSE.NAME ALS KEY NEHMEN!!!!!!!!!!
const anzSchulerProKlasse = {};
_.forEach(data.school.classes, function(klasse, key) {
    _.forEach(klasse.students, function(student, key) {
        if (anzSchulerProKlasse[klasse.name] === undefined) {
            anzSchulerProKlasse[klasse.name] = 1;
        } else {
            anzSchulerProKlasse[klasse.name]++;
        }
    })
})
console.log(anzSchulerProKlasse);

// 6.4
const avgNotenProStudent = {};
let helper2 = 0;
_.forEach(data.school.classes, function(klasse, key) {
    _.forEach(klasse.students, function(student, key) {
        _.forEach(student.grades, function(grade, key) {
            helper2 += grade;
        })
        avgNotenProStudent[student.firstName + " " + student.lastName] = helper2 / Object.keys(student.grades).length;
        helper2 = 0;
    })
})

console.log(avgNotenProStudent);


// BONUSAUFGABE - AI Lösung
const alleStudenten = _.flatMap(data.school.classes, 'students');
const bester = _.minBy(alleStudenten, function(student) {
    return _.mean(_.values(student.grades));
});
const avg = _.mean(_.values(bester.grades));
console.log(`Beste/r Schüler/in: ${bester.firstName} ${bester.lastName} (Durchschnitt: ${avg})`);


// -------------------------------------------------------------------------------------------------------
let result = {};
_.forEach(data.school.classes, function(value, key, collection) {
    _.forEach(value.students, function(student, key, collection) {
        result[student.firstName + " " + student.lastName] = 0;
    })
})
//console.log(result);



