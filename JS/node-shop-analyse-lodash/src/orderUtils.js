const _ = require('lodash');

function calcOrderTotal(order) {
    return _.sumBy(order.items, (item) => {
        const {price, quantity} = item;
        return price * quantity;
    });
}

module.exports = {
calcOrderTotal
}