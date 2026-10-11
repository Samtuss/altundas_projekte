const _ = require('lodash');
const fs = require('fs');
const path = require('path');

function readLabba() {
    console.log(__dirname)
    const filepath = path.join(__dirname, 'labba.json');
    const data = fs.readFileSync(filepath, 'utf8');
    return JSON.parse(data);
}

function getParliamentName() {
    const data = readLabba();
    return data.parliament.name;
}

function getMemberCount() {
    const data = readLabba();


    return data.members.length;
}

function getPartyNames() {
    const data = readLabba();
    const arr = [];

    _.forEach(data.parties, function (party) {
        arr.push(party.name);
    })
    return arr;
}

function getPartyFoundations() {
    const data = readLabba();
    const partyObject = {};

    _.forEach(data.parties, function (party) {
        if (partyObject[party.name] === undefined) {
            partyObject[party.name] = party.founded;
        }
    })

    return partyObject;
}

function getVoteOf(firstName, lastName, bill) {
    const data = readLabba();
    let helper;

    _.forEach(data.members, function (member) {
        if (member.firstName === firstName && member.lastName === lastName) {
            _.forEach(member.votes, function (wahl) {
                if (wahl.bill === bill) {
                    helper = wahl.vote;
                }
            })
        }
    })
    return helper;
}

function getMembersByParty(party) {
    const data = readLabba();

    const vollstandigeNamen = [];
    _.forEach(data.members, function (member) {
        if (member.party === party) {
            vollstandigeNamen.push(`${member.firstName} ${member.lastName}`)
        }
    })
    if (vollstandigeNamen.length > 0) {
        const sorted = _.sortBy(vollstandigeNamen, "lastName");
        return vollstandigeNamen;
    }
    else {
        return [];
    }
}

module.exports = {
    getParliamentName,
    getMemberCount,
    getPartyNames,
    getPartyFoundations,
    getVoteOf,
    getMembersByParty
}