function add(a,b) {
    return a + b;
}

function sub(a,b) {
    return a - b;
}

module.exports = {
    add,
    // add: add - nur das zu schreiben geht auch

    sub: sub
}


// EIN REQUIRE LIEFERT IMMER DAS WAS AUF DER RECHTEN SEITE VON module.exports STEHT.