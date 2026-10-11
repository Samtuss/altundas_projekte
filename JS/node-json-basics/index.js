console.log('LABBA NICHT');

const fs = require(`fs`);

const jsonData = fs.readFileSync("./data/books.json", "utf8").toString(); // KOMMT ZU 100 PROZENT

const data = JSON.parse(jsonData); // KOMMT AUCH

console.log("Erstes Buch: ", data.books[0]);

console.log("Titel:", data.books[0].title, " Autor:", data.books[0].author);

console.log(Object.keys(data.books[0]));

console.log();
console.log("\n--- Alle Buchtitel ---");
let helper = 0;
for (const book of data.books) {
    console.log(`${book.title} (${book.year})`);
    if (book.genre === "Fantasy") {
        helper++;
    }
}
console.log();
console.log("Alle Bücher, die nach 1950 erschienen sind:");
for (const book of data.books) {
    if (book.year > 1950) {
        console.log(`${book.title} (${book.year})`);
    }
}
console.log();
console.log(helper, "Bücher haben das Genre Fantasy");

const genreCount = {};
const autorCount = {};

for (const book of data.books) {
    const genre = book.genre;
    const autor = book.author;
    if (genreCount[genre]) {
        genreCount[genre]++;
    } else {
        genreCount[genre] = 1;
    }
    if (autorCount[autor]) {
        autorCount[autor]++;
    } else {
        autorCount[autor] = 1;
    }
}

console.log(`\n--- Anzahl Buecher pro Genre ---`);
console.log(genreCount);
console.log(`\n--- Anzahl Bücher pro Autor ---`);
console.log(autorCount);

console.log(`\n--- Genre-Statistik---`);
for (const genre in genreCount) {
    console.log(`${genre}: ${genreCount[genre]} Buch/Buecher`);
}
let helper2 = "";
let helper3 = 0;
console.log(`\n--- Autor-Statistik---`);
for (const autor in autorCount) {
    console.log(`${autor}: ${autorCount[autor]}`);
    if (autorCount[autor] > helper3) {
        helper3 = autorCount[autor];
        helper2 = autor;
    }
}

console.log('\n--- Autor mit den meisten Büchern ---');
console.log(`${helper2} mit ${helper3} Buch/Büchern`);

// 4a
let seiten = 0;
let count = 0;
let ratings = 0;
let meistenSeiten = 0;
for (const book of data.books) {
    seiten += book.pages;
    ratings += book.rating;
    count++;
    if (book.pages > meistenSeiten) {
        meistenSeiten = book.pages;
    }
}
console.log("Seitenanzahl aller Bücher:", seiten);
// 4b
console.log("Durchschnittliche Seitenanzahl:", seiten / count);
// 4c
console.log("Durchschnittliche Ratings:", Math.round((ratings / count)*10) /10);
// 4d
for (const book of data.books) {
    if (book.pages === meistenSeiten) {
        console.log(`Buch mit meisten Seiten: ${book.title} (${book.year})`);
    }
}
// 4e

const genrePages = {};
const genreBooks = {};

for (const book of data.books) {
    const genre = book.genre;
    const pages = book.pages;

    if (genrePages[genre]) {
        genrePages[genre] += pages;
        genreBooks[genre]++;
    } else {
        genrePages[genre] = pages;
        genreBooks[genre] = 1;
    }
}

const averagePagesPerGenre = {};

for (const genre in genrePages) {
    averagePagesPerGenre[genre] =
        Math.round((genrePages[genre] / genreBooks[genre]) * 10) / 10;
}

console.log('\n--- Durchschnittliche Seitenzahl pro Genre ---');
console.log(averagePagesPerGenre);

let count2 = 0;
let ratings2 = 0;
let maxSeiten = 0;
let seiten2 = 0;
for(const book of data.books) {
    seiten2 += book.pages;
    ratings2 += book.rating;
    count2++;
    if (book.pages > meistenSeiten) {
        meistenSeiten = book.pages;
    }
}
let avgSeiten = seiten2 / count2;

console.log(`Durchschnittliche Rating aller Bücher: ${Math.round((ratings2 / count2)*10) / 10}`);

console.log("Durchschnittliches Rating aller Bücher: ", Math.round((ratings2 / count2)*10) / 10);

for (const book of data.books) {
    if (meistenSeiten === book.pages) {
        console.log("Buch mit meisten Seiten: ", book.title);
    }
}

const avgSeitenGenre = {};

let genreCount2 = {};

let pagesCount2 = {};
for (const book of data.books) {
    let genre = book.genre;
    let pages = book.pages;
    if (pagesCount2[genre]) {
        pagesCount2[genre] += book.pages;
        genreCount2[genre]++;
    } else {
        pagesCount2[genre] = book.pages;
        genreCount2[genre] = 1;
    }
}


for (const genre in pagesCount2) {
    avgSeitenGenre[genre] = pagesCount2[genre] / genreCount2[genre];
}

console.log(genreCount2)
console.log(pagesCount2)
console.log("Avg Seitenanzahl pro Genre:")
console.log(avgSeitenGenre);