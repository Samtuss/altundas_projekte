// just in time compiler
// jedes js file ist ein modul
//      drei arten von modulen
//          1. lokale module
//          2. core module
//          3. third party module
// 4 datentypen: number, string, array, object
//      os.release() damit man auf ein Modul von jode.js
//      zugreifen kann muss man die fkt require(modul name);
//  const os = require('node:os');



console.log("hello world");
console.log("sup dawg")


let x = 5;
x = "zayum";
console.log(typeof(x));

x = [1,2,3,4,5,6];
x = {
  name: "skibidi",
  age: 5
};
// x.name
// x["name"]

console.log("x: " + x.name)
console.log(`x: ${x.name}`);

console.log("x: " + x)
console.log(`x: ${x}`); // template string - es gibt auch concatenated strings
console.log("x:", x);
