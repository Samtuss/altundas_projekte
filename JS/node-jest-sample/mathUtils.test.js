// FILENAME EINHALTEN
// --save-dev BEIM INSTALLIEREN NICHT VERGESSEN
// WENN DER TEST KEINE EXCEPTION WIRFT, IST SIE ERFOLGREICH
// UND WENN SIE EINE EXCEPTION WIRFT, IST SIE NICHT ERFOLGREICH


// test-methode bekommt zwei parameter
// 1. parameter: ist die beschreibung
// 2. parameter: ist eine funktion um das ganze zu testen

// UM ZU TESTEN IMMER NPM TEST INS TERMINAL SCHREIBEN
const { add, isEven, divide } = require("./mathUtils.js");
const test = require("node:test");

test('add(2,3) ergibt 5', function() {
    let result = add(2,3)
    if (result !== 5) {
        throw new Error(result);
    }
});

test('add(5,9) ergibt 14', function() {
    expect(add(5,9)).toBe(14)
});

test('isEven(4) ergibt true', () => {
    expect(isEven(4)).toBe(true)
});

// TRUTHY UND FALSY SIND SO TRUE-ISH CHECKST???

test('isEven(10) ergibt truthy', () => {
    expect(isEven(10)).toBeTruthy()
});

describe ('divide', function() {
    test('divide(6,3) ergibt 2', function() {
        expect(divide(6,3)).toBe(2)
    });

    test('divide(6, -3) ergibt -2', function() {
        expect(divide(6, -3)).toBe(-2)
    });

    test('divide(4, 40) ergibt 0.1', function() {
        expect(divide(4, 40)).toBe(0.1)
    });
    // ERROR GEHT NICHT KA WARUM
    test('divide(6, 0) ergibt error', function() {
        expect(divide(6, 0)).toThrow('Division by 0!');
    })
})
