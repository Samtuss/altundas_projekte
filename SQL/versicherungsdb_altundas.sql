drop database versicherungsdb_altundas;
create database versicherungsdb_altundas;
use versicherungsdb_altundas;

create table if not exists h_hersteller (
h_herstnr int(11) primary key not null auto_increment,
h_name varchar(30) not null,
h_land varchar(30)
);

create table if not exists ft_fahrzeugtypen (
ft_typnr int (11) primary key not null auto_increment,
ft_bezeichnung varchar(30),
ft_h_herstnr int(11),

foreign key (ft_h_herstnr)
	references h_hersteller (h_herstnr)
    on delete set null on update cascade
);

create table if not exists m_mitarbeiter (
m_nr int(11) primary key not null,
m_name varchar(30) not null,
m_vorname varchar(30),
m_gebdatum date,
m_wohnort varchar(30),
m_plz char(5),
m_strasse_hnr varchar(35),
m_telefon varchar(30),
m_mobil varchar(30),
m_email varchar(50),
m_a_abtnr int(11)
);

create table if not exists a_abteilungen (
a_abtnr int(11) primary key not null,
a_kuerzel varchar(10),
a_bezeichnung varchar(30),
a_ort varchar(30),
a_m_ableiter int(11),

foreign key (a_m_ableiter)
	references m_mitarbeiter (m_nr)
    on delete set null on update cascade
);

alter table m_mitarbeiter add foreign key (m_a_abtnr)
	references a_abteilungen (a_abtnr)
    on delete set null on update cascade;

create table if not exists v_versicherungsvertraege (
v_vertragid char(15) primary key not null,
v_abschlussdatum date,
v_art char(2),
v_fuehrerschein date,
v_m_nr int(11),
v_dw_nr int(11),

foreign key (v_m_nr)
	references m_mitarbeiter (m_nr)
    on delete set null on update cascade
);

create table if not exists dw_dienstwagen (
dw_nr int(11) primary key not null,
dw_kennzeichen varchar(10) not null,
dw_farbe varchar(30),
dw_ft_typnr int(11),
dw_m_nr int(11),

foreign key (dw_m_nr)
	references m_mitarbeiter (m_nr),
    
foreign key (dw_ft_typnr)
	references ft_fahrzeugtypen (ft_typnr)
);

alter table v_versicherungsvertraege add foreign key (v_dw_nr)
	references dw_dienstwagen (dw_nr)
    on delete set null on update cascade;

create table if not exists u_unfaelle (
u_fallnr int(11) not null primary key auto_increment,
u_datum date not null,
u_unfallort varchar(200),
u_beschreibung varchar(1000),
u_schadensumme decimal(10,2),
u_verletzte char(1),
u_m_nr int(11),

foreign key (u_m_nr)
	references m_mitarbeiter (m_nr)
    on delete set null on update cascade
);

create table if not exists ds_dienstwagen_schaden (
ds_dw_nr int(11) not null,
ds_u_fallnr int(11) not null,
ds_schadenshoehe decimal(10,2),

foreign key (ds_dw_nr)
	references dw_dienstwagen (dw_nr)
    on delete no action on update cascade,
    
foreign key (ds_u_fallnr)
	references u_unfaelle (u_fallnr)
    on delete no action on update cascade,
    
primary key(ds_dw_nr, ds_u_fallnr)
);

set foreign_key_checks = 0;

insert into m_mitarbeiter 
(m_nr, m_name, m_vorname, m_gebdatum, m_wohnort, m_plz, m_strasse_hnr, m_telefon, m_mobil, m_email, m_a_abtnr) values
(10001,'Müller','Kurt','1977-01-05','Dorsten',46282,'Gahlener Str. 40','0231/5554987',NULL,'kurt.mueller@unserefirma.de',1),
(10002,'Schneider','Daniela','1980-02-16','Gelsenkirchen',45892,'Coesfelder Str. 23','0231/5554988',NULL,'daniela.schneider@unserefirma.de',1),
(20001,'Meyer','Walter','1963-07-02','Castrop-Rauxel',44577,'Kiefernweg 9','0231/5553967',NULL,'walter.meyer@unserefirma.de',2),
(20002,'Schmitz','Michael','1959-08-25','Herne',44625,'Haberstr. 13','0231/5556187',NULL,'michael.schmitz@unserefirma.de',2),
(30001,'Wagner','Gaby','1970-01-18','Bochum',44809,'Steinbankstr. 15','0231/5554787',NULL,'gaby.wagner@unserefirma.de',3),
(30002,'Feyerabend','Werner','1982-04-01','Oer-Erkenschwick',45739,'Ackerstr. 34','0231/5554997',NULL,'werner.feyerabend@unserefirma.de',3),
(40001,'Langmann','Matthias','1976-03-28','Hattingen',45525,'Raabestr. 21','0231/5551927',NULL,'matthias.langmann@unserefirma.de',4),
(40002,'Peters','Michael','1973-11-15','Recklinghausen',45665,'Idastr. 24','0231/5554237',NULL,'michael.peters@unserefirma.de',4),
(50001,'Pohl','Helmut','1980-10-27','Herten',45699,'Gablonzer Weg 27','0201/4014186','0171 4123456','helmut.pohl@unserefirma.de',5),
(50002,'Braun','Christian','1966-09-05','Datteln',45711,'Halterner Allee 30','0201/4014726','0170 8351647','christian.braun@unserefirma.de',5),
(50003,'Polovic','Frantisek','1961-11-26','Haltern',45721,'Am Freibad 32','0201/4014727','0161 5124793','frantisek.polovic@unserefirma.de',5),
(50004,'Kalman','Aydin','1976-12-17','Waltrop',45731,'Goethestr. 33','0201/4014728','0161 4486319','aydin.kalman@unserefirma.de',5),
(60001,'Aagenau','Karolin','1950-01-02','Oer-Erkenschwick',45739,'Ackerstr. 34','0234/66006001',NULL,'Karolin.Aagenau@unserefirma.de',6),
(60002,'Pinkart','Petra','1953-03-04','Marl',45772,'Bachackerweg 35','0234/66006002',NULL,'Petra.Pinkart@unserefirma.de',6),
(50005,'Olschewski','Pjotr','1956-05-06','Gelsenkirchen',45888,'Cheruskerstr. 36','0234/66007001',NULL,'Pjotr.Olschewski@unserefirma.de',5),
(60003,'Nordmann','Jörg','1959-07-08','Gladbeck',45966,'Dechenstr. 37','0234/66007002',NULL,'Joerg.Nordmann@unserefirma.de',6),
(80001,'Schindler','Christina','1962-09-10','Oberhausen',46147,'Ebereschenweg 38','0201/4012151','0173  7513901','Christina.Schindler@unserefirma.de',8),
(80002,'Aliman','Zafer','1965-11-12','Bottrop',46244,'Falkenweg 39','0201/4012161','0171 9416755','Zafer.Aliman@unserefirma.de',8),
(80003,'Langer','Norbert','1968-01-13','Borken',46325,'Heimser Weg 1','0201/4012171','0162 1357902','Norbert.Langer@unserefirma.de',8),
(80004,'Kolic','Ivana','1971-02-14','Velen',46342,'Inselstr. 4','0201/4012181','0172  4680135','Ivana.Kolic@unserefirma.de',8),
(90001,'Janssen','Bernhard','1974-03-15','Raesfeld',46348,'Juister Str. 7','0201/4013111',NULL,'Bernhard.Janssen@unserefirma.de',9),
(90002,'Hinkel','Martina','1977-04-16','Köln',50173,'Gartenfelder Str. 23','0201/4013110',NULL,'Martina.Hinkel@unserefirma.de',9),
(100001,'Grosser','Horst','1980-05-17','Hamburg',20444,'Harvestehuder Weg 23 a','0201/4013344',NULL,'Horst.Grosser@unserefirma.de',10),
(100002,'Friedrichsen','Angelina','1983-06-20','Velen',46342,'Am Kai 26','0201/4013345',NULL,'Angelina.Friedrichsen@unserefirma.de',10),
(110001,'Eggert','Louis','1986-07-23','Marl',45772,'Wiesengasse  54','02323/381456',NULL,'Louis.Eggert@unserefirma.de',11),
(110002,'Deiters','Gisela','1989-08-26','Recklinghausen',45665,'Hermanngasse. 66','02323/381457',NULL,'Gisela.Deiters@unserefirma.de',11),
(120001,'Carlsen','Zacharias','1965-09-29','Gelsenkirchen',45892,'Kirchgasse 112','0234/66012001',NULL,'Zacharias.Carlsen@unserefirma.de',12),
(120002,'Baber','Yvonne','1957-10-02','Datteln',45711,'Hauptstr. 150','0234/66012002',NULL,'Yvonne.Baber@unserefirma.de',12);

insert into a_abteilungen
(a_abtnr, a_kuerzel, a_bezeichnung, a_ort, a_m_ableiter) values
(1,'Fibu','Finanzbuchhaltung','Dortmund',10001),
(2,'Albu','Anlagenbuchhaltung','Dortmund',20001),
(3,'Kore','Kostenrechnung','Dortmund',30001),
(4,'Kopl','Kostenplanung','Dortmund',40001),
(5,'Vert','Vertrieb','Essen',50001),
(6,'Lagh','Lagerhaltung','Bochum',60001),
(7,'Prod','Produktion','Bochum',NULL),
(8,'ScAb','Schadensabwicklung','Essen',80001),
(9,'Pers','Personalverwaltung','Essen',90001),
(10,'Soz','Sozialverwaltung','Essen',100001),
(11,'Ausb','Ausbildung','Herne',110001),
(12,'Fue','Forschung und Entwicklung','Bochum',120001);

insert into h_hersteller
(h_name, h_land) values
('Volkswagen', 'Deutschland'),
('Opel', 'Deutschland'),
('Ford', 'Deutschland'),
('BMW', 'Deutschland'),
('Audi', 'Deutschland'),
('Mercedes-Benz', 'Deutschland'),
('Sachsenring', 'Deutschland'),
('Saab', 'Schweden'),
('Volvo', NULL),
('Renault', 'Frankreich'),
('Seat',NULL);

insert into ft_fahrzeugtypen
(ft_bezeichnung, ft_h_herstnr) values
('Polo', 1),
('Golf', 1),
('Passat', 1),
('Kadett', 2),
('Corsa', 2),
('Focus', 3),
('Trabant', 7),
('Fiesta', 3),
('325', 4),
('525', 4),
('Z3', 4),
('A3', 5),
('A4', 5),
('A160', 6),
('W204 (C-Klasse)', 6),
('W211 (E-Klasse)', 6),
('Saab 9-3', 8),
('S40', 9),
('C30', 9),
('Clio', 10),
('Twingo', 10),
('Ibiza', 11),
('Leon', 11);

insert into dw_dienstwagen
(dw_nr, dw_kennzeichen, dw_farbe, dw_ft_typnr, dw_m_nr) values
(1,'DO-WB 421','elfenbein',14,10001),
(2,'DO-WB 422','elfenbein',14,20001),
(3,'DO-WB 423','elfenbein',14,30001),
(4,'DO-WB 424','elfenbein',14,40001),
(5,'DO-WB 425','elfenbein',14,50001),
(6,'DO-WB 426','elfenbein',14,60001),
(7,'DO-WB 427','elfenbein',20,50005),
(8,'DO-WB 428','elfenbein',14,80001),
(9,'DO-WB 429','elfenbein',14,90001),
(10,'DO-WB 4210','elfenbein',14,100001),
(11,'DO-WB 4211','elfenbein',14,110001),
(12,'DO-WB 4212','elfenbein',14,120001),
(16,'DO-WB 111','elfenbein',16,NULL),
(17,'DO-WB 352','gelb',2,50002),
(18,'DO-WB 353','gelb',3,50003),
(19,'DO-WB 354','gelb',4,50004),
(20,'DO-WB 382','gelb',2,80002),
(21,'DO-WB 383','gelb',3,80003),
(22,'DO-WB 384','gelb',4,80004),
(23,'BO-GH 102','rot',19,NULL),
(24,'RE-YZ 369','rot',10,NULL),
(25,'RE-ST 890','rot',13,NULL),
(26,'HH-MM 783','schwarz',7,NULL);

insert into u_unfaelle
(u_fallnr, u_datum, u_unfallort, u_beschreibung, u_schadensumme, u_verletzte, u_m_nr) values
(1, '2007-02-03', 'Recklinghausen, Bergknappenstr. 144', 'Gartenzaun gestreift', 1234.5, 'N', 80003),
(2, '2007-07-11', 'Haltern, Hauptstr. 46', 'beim Ausparken hat DO-WB 425 die Vorfahrt von DO-WB 427 missachtet', 2066, 'N', 50005),
(3, '2007-12-19', 'Marl, Rathausstr./Halterner Allee', 'beim Abbiegen nach links hat ein fremder Wagen die Vorfahrt missachtet', 3715.6, 'J', 60002),
(4, '2008-05-27', 'Recklinghausen, Südgrabenstr. 23', 'Fremdes parkendes Auto gestreift', 1438.75, 'N', 50003),
(5, '2008-10-05', 'Dorsten, Oberhausener Str. 18', 'beim Ausparken hat ein fremder Wagen die Vorfahrt missachtet', 1983, 'N', 60002),
(6, '2009-03-13', 'Marl, Rathausstr./Halterner Allee', 'beim Abbiegen nach links hat ein fremder Wagen die Vorfahrt missachtet', 4092.15, 'J', 50005),
(7, '2009-08-21', 'Recklinghausen, Bergknappenstr. 144', 'Laternenpfahl umgefahren', 865, 'N', 60002),
(8, '2009-08-01', 'L318 Hamm-Flaesheim', 'Wildunfall mit Reh 10% Wertverlust', 2471.5, 'N', 80002),
(9, '2010-03-11', 'Dorsten, Hauptstraße 55', 'Handbremse nicht angezogen beim Parken am Hang', 1550.0, 'J', 40001),
(10, '2010-06-25', 'Bochum, Hauptplatz', 'Bei roter Ampel nachfahrendes Auto aufgefahren', 985.0, 'J', 90001),
(11, '2008-08-06', 'Landstraße L318, Km. 98 ', 'Wegen Reifen-Platten in den Graben gefahren', NULL, 'N', 50003),
(12, '2008-11-03', 'Dortmund, Hauptplatz', 'Fußgänger am Parkplatz angefahren', 1390.0, 'J', 90001),
(13, '2010-08-12', 'Bochum, Hauptplatz', 'Wegen Notbremsung ins Schleudern geraten, Beifahrer erlitt am Kopf Platzwunden', 1100.0, 'J', 80003);

insert into v_versicherungsvertraege
(v_vertragid, v_abschlussdatum, v_art, v_fuehrerschein, v_m_nr, v_dw_nr) values
('DG-01','1974-05-03','TK','1998-05-29',50001,1),
('XH-02','1982-06-20','VK','1998-05-29',50001,8),
('HR-02','1984-08-23','HP','1998-05-29',50001,9),
('KH-02','1986-10-26','HP','1998-05-29',50001,10),
('RD-02','1988-01-29','HP','1998-05-29',50001,11),
('RM-03','1996-01-13','HP','1998-05-29',50001,15),
('HG-03','2000-05-17','HP','1998-05-29',50001,17),
('RR-05','1990-06-29','TK','1998-05-29',50001,23),
('KNH-234','2007-03-16','TK','1998-05-29',50001,24),
('DG-03','1974-05-03','TK','1988-06-11',50002,3),
('XC-01','1974-08-07','HP','1988-06-11',50002,4),
('RH-01','1976-12-11','VK','1988-06-11',50002,5),
('KB-01','1978-02-14','TK','1988-06-11',50002,6),
('DH-02','1990-02-01','HP','1988-06-11',50002,12),
('XW-03','1992-06-05','VK','1988-06-11',50002,13),
('KV-04','1988-03-27','HP','1988-06-11',50002,22),
('RVV-845','2003-08-08','HP','1988-06-11',50002,25),
('DG-02','1974-05-03','TK','1982-11-25',50003,2),
('XO-04','2002-07-19','VK','1982-11-25',50003,18),
('HB-04','2004-09-21','HP','1982-11-25',50003,19),
('RD-04','2006-11-23','HP','1982-11-25',50003,20),
('DB-04','2008-01-25','HP','1982-11-25',50003,21),
('DO-03','1994-10-09','HP','1994-08-20',50004,14),
('KG-03','1998-03-15','HP','1994-08-20',50004,16),
('HE-01','1980-04-26','HP','1994-08-20',50004,7);

insert into ds_dienstwagen_schaden
(ds_dw_nr, ds_u_fallnr, ds_schadenshoehe) values
(1, 2, 1234.5),
(2, 7, 852),
(2, 5, 1214),
(3, 4, 1438.75),
(3, 24, 2276.85),
(4, 1, 1234.5),
(4, 5, 1983),
(5, 2, 1251.5),
(5, 25, 731.5),
(6, 3, 2653.4),
(6, 7, 1438.75),
(7, 6, 865),
(8, 7, NULL),
(9, 4, 650),
(10, 9, 600),
(11, 18, NULL);

set foreign_key_checks = 1;