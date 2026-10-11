const fs = require('fs');

console.log("Starting...");


// CHALLENGE:
// - convert "copyfile" into "mergefile" => 2x read => write result
// - mergeFiles(src1, src2, src3, dest)


function copyFile(input, output) {
    fs.readFile("./package.json", "utf8", (err, data) => { // immer err zuerst als parameter - Konvention
        if (err) {
            console.error("Something went wrong");
            console.error(err);
            return;
        }
        console.log("File read successfully.");
        console.log(data);

        // ACHTUNG: fs.writeFile darf NICHT auf derselben Ebene wie fs.readFile stehen
        // ALSO MÜSSEN WIR VERSCHACHTELN
        // WEIL SONST writeFile COMPILIERT WIRD, OBWOHL DER INPUT NOCH NICHT EINGELESEN WURDE
        fs.writeFile(output, data, (err, data) => {
            if (err) {
                return console.error(err);
            }
            console.log("File written successfully.")
        });
    });
}

// MERGEFILES
function mergeFiles(src1, src2, dest) {
    fs.readFile(src1, "utf8", (err, data1) => {
        if (err) {
            console.error("Error reading file 1");
            return console.error(err);
        }
        console.log("File 1 read successfully.");

        fs.readFile(src2, "utf8", (err, data2) => {
            if (err) {
                console.error("Error reading file 2");
                return console.error(err);
            }
            console.log("File 2 read successfully.");

            fs.writeFile(dest, data1 + data2, (err) => {
                if (err) {
                    return console.error(err);
                }
                console.log("Merged file written successfully.");
            });
        });
    });
}

function mergeFiles2(src1, src2, dest) {
    let file1Done = false;
    let file2Done = false;

    fs.readFile(src1, "utf8", (err, data1) => {
        if (err) {
            console.error("Error reading file 1");
            return console.error(err);
        }
        console.log("File 1 read successfully.");

        file1Done = true;
        if (file2Done) {
            fs.writeFile(dest, data1 + data2, (err) => {
                if (err) {
                    return console.error(err);
                }
                console.log("Merged file written successfully.");
            });
        }
    });
    fs.readFile(src2, "utf8", (err, data2) => {
        if (err) {
            console.error("Error reading file 2");
            return console.error(err);
        }
        console.log("File 2 read successfully.");

        file2Done = true;

        if (file1Done) {
            fs.writeFile(dest, data1 + data2, (err) => {
                if (err) {
                    return console.error(err);
                }
                console.log("Merged file written successfully.");
            });
        }
    });


//    while (!file2Done) {
//        fs.writeFile(dest, data1 + data2, (err) => {
//            if (err) {
//                return console.error(err);
//            }
//            console.log("Merged file written successfully.");
//        });
//    }
}

function mergeFiles3(src1, src2, dest) {
    let data1 = null; // ← move here
    let data2 = null; // ← move here

    fs.readFile(src1, "utf8", (err, result1) => {
        if (err) return console.error(err);
        data1 = result1; // ← save it
        if (data2) {     // ← no need for a separate flag anymore
            fs.writeFile(dest, data1 + data2, (err) => {
                if (err) return console.error(err);
                console.log("Merged file written successfully.");
            });
        }
    });

    fs.readFile(src2, "utf8", (err, result2) => {
        if (err) return console.error(err);
        data2 = result2; // ← save it
        if (data1) {     // ← same check
            fs.writeFile(dest, data1 + data2, (err) => {
                if (err) return console.error(err);
                console.log("Merged file written successfully.");
            });
        }
    });
}

// lies datei
// -- callback: ist die andere datei auch schon gelesen? ja => writeFile, nein => nix
// lies datei2
// -- callback: ist die andere datei auch schon gelesen? ja => writeFile, nein => nix

setTimeout(() => {
    console.log("Inside callback...")
}, 3000);

mergeFiles('./package.json', './callback-sample.js', './output.txt');


console.log("Ending...");