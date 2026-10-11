const {celsiusToFahrenheit, fahrenheitToCelsius, classifyTemperature, analyzeTemperatures} = require('./temperatur');


const q = function a(x) { return x + 1; };
const w = function (x) { return x + 1; };
const a = (x) => { return x + 1; };
const b = (x) => x+1;
const c = x => x+1;

a(10);


test("0.2 + 0.1 = 0.3", () => {
    expect(0.2 +0.1).toBeCloseTo(0.3);
})

function myTestFunc() {
    return "3bhif";
}

describe("Teil 1: Einstieg", () => {
    test("celsiusToFahrenheit(0) ergibt 32", () => {
        const result = celsiusToFahrenheit(0);
        expect(result).toBe(32);
    });

    test("celsiusToFahrenheit(100) ergibt 212", () => {
        const result = celsiusToFahrenheit(100);
        expect(result).toBe(212);
    });

    test("celsiusToFahrenheit(-40) ergibt -40", () => {
        const result = celsiusToFahrenheit(-40);
        expect(result).toBe(-40);
    });
});

describe("Teil 2: FließKomma", () => {
    test("fahrenheitToCelsius(32) ergibt 0", () => {
        const result = fahrenheitToCelsius(32);
        expect(result).toBe(0);
    });

    test("fahrenheitToCelsius(212) ergibt 100", () => {
        const result = fahrenheitToCelsius(212);
        expect(result).toBe(100);
    });

    test("fahrenheitToCelsius(98.6) ergibt ungefähr 37", () => {
        expect(fahrenheitToCelsius(98.6)).toBeCloseTo(37);
    });
});

describe("Teil 3: Strings testen mit toBe() und toMatch()", () => {
    describe("Normalfälle", () => {
        test("classifyTemperature(0<) ergibt eisig", () => {
            expect(classifyTemperature(-1)).toBe("eisig");
        });

        test("classifyTemperature(0-10) ergibt eisig", () => {
            expect(classifyTemperature(9)).toBe("kalt");
        });

        test("classifyTemperature(10-20) ergibt eisig", () => {
            expect(classifyTemperature(10)).toBe("mild");
        });

        test("classifyTemperature(20-30) ergibt eisig", () => {
            expect(classifyTemperature(24)).toBe("warm");
        });

        test("classifyTemperature(30>) ergibt eisig", () => {
            expect(classifyTemperature(32)).toBe("heiß");
        });
    });
    // ^ bedeutet, dass es mit einem a-z buchstabe beginnen soll
    // $ bedeutet, dass es mit denselben buchstaben enden soll - es geht aber nur,
    //      wenn es nur aus einem buchstaben besteht
    // + bedeutet, dass es mehrere zeichen dazwischen haben kann
    describe("Regex Cases", () => {
       test("-5 ergibt eisig in Kleinbuchstaben", () => {
           const result = myTestFunc();
           expect("bhif").toMatch(/^[a-z]+$/);
           expect("bhif").toMatch(/^[a-z]+$/);
           expect("b").toMatch(/^[a-z]+$/);


       })
    });
});


// achtung wir haben hier eine zweite lambda expression eingebaut GIB ACHT
// warum? - ka
test("throws ...", () => {
    expect(() => celsiusToFahrenheit("abc")).toThrow();
})



// ACHTUNG: toMatchObject
test("analyzeTemperatures ...", () => {
    const result = analyzeTemperatures([10, 20, 30]);
    expect(result).toMatchObject({min: 10, max: 30, average: 20, count: 3});
})