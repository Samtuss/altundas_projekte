// 1 + 2 + 3 + 4 + 5
function add(a,b, callback) {
    setTimeout(() => {
        callback(a + b);
    }, 2000); // z.B.: 0 oder 2000

    return undefined;
}

const result = add(1,2);
console.log(result);