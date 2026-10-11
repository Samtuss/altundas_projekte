drop database ltp_altundas;
create database ltp_altundas;
use ltp_altundas;

create table if not exists t_teile (
t_nr varchar(2) not null primary key,
t_name varchar(8) not null,
t_farbe varchar(5) not null,
t_preis decimal(4,2) not null,
t_stadt varchar(6) not null
);

create table if not exists p_projekte (
p_nr varchar(2) not null primary key,
p_name varchar(10) not null,
p_stadt varchar(6) not null
);

create table if not exists l_lieferanten (
l_nr varchar(2) not null primary key,
l_name varchar(6) not null,
l_rabatt decimal not null,
l_stadt varchar(6) not null
);

create table if not exists pl_projektlieferungen (
pl_l_nr varchar(2) not null,
pl_t_nr varchar(2) not null,
pl_p_nr varchar(2) not null,
pl_menge decimal not null,

foreign key (pl_l_nr)
	references l_lieferanten (l_nr)
    on delete no action on update cascade,
foreign key (pl_t_nr)
	references t_teile (t_nr)
    on delete no action on update cascade,
foreign key (pl_p_nr)
	references p_projekte (p_nr)
    on delete no action on update cascade,


primary key(pl_l_nr, pl_t_nr, pl_p_nr)
);

set foreign_key_checks = 0;
insert into t_teile values
('T1','Mutter','rot',12,'London'),
('T2','Bolzen','gelb',17,'Paris'),
('T3','Schraube','blau',17,'Rom'),
('T4','Schraube','rot',14,'London'),
('T5','Welle','blau',12,'Paris'),
('T6','Zahnrad','rot',19,'London');

insert into p_projekte values
('P1','Flugzeug','Paris'),
('P2','Schiff','Rom'),
('P3','Seilbahn','Athen'),
('P4','Schiff','Athen'),
('P5','Eisenbahn','London'),
('P6','Flugzeug','Oslo'),
('P7','Autobus','London'),
('P8','U-Bahn','Wien');

insert into l_lieferanten values
('L1','Schmid',20,'London'),
('L2','Jonas',10,'Paris'),
('L3','Berger',30,'Paris'),
('L4','Klein',20,'London'),
('L5','Adam',30,'Athen');

insert into pl_projektlieferungen values
('L1','T1','P1', 200),
('L1','T1','P4', 700),
('L2','T3','P1',400),
('L2','T3','P2',200),
('L2','T3','P3',200),
('L2','T3','P4',500),
 ('L2','T3','P5', 600),
('L2','T3','P6' ,400),
('L2','T3', 'P7',800),
 ('L2','T5','P2' ,100),
 ('L3','T3','P1', 200),
 ('L3','T4','P2',500),
('L4','T6','P3', 300),
 ('L4','T6','P7', 300),
('L5','T1','P4', 100),
 ('L5','T2','P2', 200),
('L5','T2','P4', 100),
 ('L5','T3','P4', 200),
 ('L5','T4','P4', 800),
 ('L5','T5','P4', 400),
 ('L5','T5','P5', 500),
 ('L5','T5','P7', 100),
('L5','T6','P2', 200),
 ('L5','T6','P4', 500);

set foreign_key_checks = 1;