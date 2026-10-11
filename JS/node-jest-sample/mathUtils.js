function add(a,b) {
    return a + b; //+ 1; // absichtlich fehler einbauen zum testen
}

function isEven(a) {
    return a % 2 === 0;
}

function divide(a, b) {
    if (b === 0) throw new Error('Division by 0!');
    return a / b;
}

module.exports = {
    add,
    isEven,
    divide
}