const math = require("./math");

console.log(math);

const result = math.add(3,5); // beide gehen
const result2 = math["add"](1,2) // beide gehen

console.log(result);
console.log(result2);

