// z.B.: webstorm erkennt require und userInfo nicht
// ist auch in der testumgebung so, aber es funktioniert eh also chillax


// EIN REQUIRE LIEFERT IMMER DAS WAS AUF DER RECHTEN SEITE VON module.exports STEHT.
const os = require('os');
const fs = require('node:fs');


const userData = os.userInfo();

console.log(`userData: ${userData.username}`);
console.log(`userData: ${userData["username"]}`)

let x = "homedir";
console.log(userData.x); // geht ned
console.log(userData[x]); // geht weil ka

// CHALLENGE:
// 1. Inkludiere das Core-Module "File System"
// 2. Verwende die Funktion "writeFileSync", um unseren
//    "Hallo, ...!" Text in das File "hello.txt" zu schreiben

fs.writeFileSync("hello.txt", `Hallo, ${userData.username}`);

console.log();
const data = fs.readFileSync("myfile.txt", "utf8");
console.log(data);


