drop database klinikdb_altundas;
create database klinikdb_altundas;
use klinikdb_altundas;

create table if not exists p_patienten(
p_patientid char(6) not null primary key,
p_name varchar(20) not null,
p_vorname varchar(20),
p_gebdatum date not null,
p_svnr char(10),
p_geschlecht char(1)
);

create table if not exists a_arzte(
a_arztnr integer(4) not null primary key,
a_name varchar(20) not null,
a_vorname varchar(20),
a_gehalt decimal(7.2) check(a_gehalt > 0),
a_gebdatum date,
a_s_station char(4) not null
);

create table if not exists s_stationen(
s_stationsid char(4) not null primary key,
s_stationsbezeichnung varchar(30),
s_a_leitenderarzt integer(4) not null,

foreign key (s_a_leitenderarzt)
	references a_arzte (a_arztnr)
    on delete cascade on update cascade
    # ON DELETE CASCADE (oder vielleicht NO ACTION?????) WEIL s_a_leitenderarzt NICHT NULL SEIN DARF
);

create table if not exists b_behandlungen(
b_s_stationsid char(4) not null,
b_a_arztnr integer(4) not null,
b_p_patientid char(6) not null,
b_datumvon date,
b_diagnose varchar(25),

foreign key (b_s_stationsid)
	references s_stationen (s_stationsid)
    on delete cascade on update cascade,
foreign key (b_a_arztnr)
	references a_arzte (a_arztnr)
    on delete cascade on update cascade,
foreign key (b_p_patientid)
	references p_patienten (p_patientid)
    on delete cascade on update cascade,
    
primary key(b_s_stationsid, b_a_arztnr, b_p_patientid, b_datumvon)
);

alter table a_arzte add foreign key (a_s_station)
	references s_stationen (s_stationsid);

set foreign_key_checks = 0;

INSERT INTO s_stationen (s_stationsid, s_stationsbezeichnung, s_a_leitenderarzt) VALUES
('HNO1', 'Hals-Nasen-Ohren-Abteilung', 1378),
('UCH3', 'Unfallchirurgie', 1176),
('PHY2', 'Physikalische Medizin', 1678),
('INT4', 'Innere Medizin', 4365);

INSERT INTO a_arzte (a_arztnr, a_name, a_vorname, a_gebdatum, a_gehalt, a_s_station) VALUES
(1273, 'SCHMIDT', 'KLAUS',   '1988-12-17', 4600, 'INT4'),
(2575, 'GEIER',   'PAUL',    '1963-04-18', 3200, 'HNO1'),
(3275, 'HEILIT',  'LUKAS',   '1980-08-06', 2000, 'UCH3'),
(1176, 'BERNDT',  'MARIA',   '1971-05-23', 2300, 'UCH3'),
(2077, 'WALLA',   'HERBERT', '1978-03-29', 3100, 'HNO1'),
(3177, 'KOLLER',  'CLAUDIA', '1973-07-31', 4800, 'PHY2'),
(1568, 'PETRI',   'WALTER',  '1987-06-18', 3900, 'INT4'),
(4365, 'BARI',    'JOSEFA',  '1976-02-24', 4000, 'INT4'),
(4368, 'SCHMOLZ', 'TINA',    '1962-09-17', 3950, 'HNO1'),
(1678, 'BERGER',  'PETER',   '1981-10-07', 4100, 'PHY2'),
(2078, 'SCHLAGER','HANS',    '1970-11-23', 3600, 'PHY2');

INSERT INTO p_patienten (p_patientid, p_name, p_vorname, p_gebdatum, p_svnr, p_geschlecht) VALUES
('P10203', 'Schubert',   'Karl',     '1985-12-22', '8431221285', 'm'),
('P23952', 'Meierhuber','Chiara',   '1998-05-06', '5623060596', 'w'),
('P13410', 'Suller',     'Katharina','1969-08-15', '2536150869',  'w'),
('P33440', 'Halbarth',   'Marius',   '1980-01-09', '1263901989', 'm'),
('P24101', 'Kollovic',   'Monika',   '1953-11-04', '3657041153','w'),
('P15311', 'Bartl',      'Theodor',  '1989-06-23', '8536230689', 'm');

INSERT INTO b_behandlungen (b_s_stationsid, b_a_arztnr, b_p_patientid, b_datumvon, b_diagnose) VALUES
('INT4', 4365, 'P24101', '2011-12-14', 'Herzinfarkt'),
('PHY2', 3275, 'P15311', '2011-11-12', 'Bandscheibenvorfall'),
('HNO1', 2077, 'P13410', '2011-12-09', 'Gehörsturz'),
('INT4', 1568, 'P10203', '2011-12-18', 'Nierensteine'),
('INT4', 1568, 'P10203', '2011-11-20', 'Blinddarmentzuendung'),
('UCH3', 3275, 'P23952', '2011-11-20', 'Kreuzbandriss'),
('PHY2', 1678, 'P13410', '2011-10-12', 'Bandscheibenvorfall'),
('HNO1', 2077, 'P33440', '2011-10-25', 'Naspolyppen');

set foreign_key_checks = 1;
