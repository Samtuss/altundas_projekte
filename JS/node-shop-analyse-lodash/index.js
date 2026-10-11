const fs = require('fs');
const _ = require('lodash');
const labba = require('./src/orderUtils');

const rawData = fs.readFileSync('./data/orders.json', 'utf8');
const {orders} = JSON.parse(rawData);
console.log(rawData)
console.log(orders);

console.log('Anzahl Bestellungen:', orders.length);

console.log('Erste ␣ Bestellung :', _.first (orders).id);
console.log('Letzte ␣ Bestellung :', _.last(orders).id);

const bestellIDs = _.map(orders, order => order.id);
console.log(bestellIDs);

const uniqueCustomers = _ . uniqBy ( orders , 'customer . name ') ;
console.log(uniqueCustomers);
const customerNames = _ . map ( uniqueCustomers , ( order, ) => {
    const { name , city } = order.customer ;
    return `${ name } (${ city }) `;
}) ;
console . log ('Kunden :', customerNames ) ;

const ka = labba.calcOrderTotal(_.first(orders));
console.log(ka);
