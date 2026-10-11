drop database projektdb_altundas;
create database projektdb_altundas;
use projektdb_altundas;

create table if not exists m_mitarbeiter (
m_mitarbeiternr int(5) not null primary key,
m_name varchar(45),
m_vorname varchar(45),
m_a_abteilung char(3)
);

create table if not exists a_abteilungen (
a_abteilungid char(3) not null primary key,
a_abteilungname varchar(50),
a_m_abteilungsleiter int(5) not null,

foreign key (a_m_abteilungsleiter)
	references m_mitarbeiter (m_mitarbeiternr)
    on delete no action on update cascade
);

create table if not exists p_projekte (
p_projektid char(5) not null,
p_projektname varchar(80),
p_m_projektleiter int(5) not null,
p_startdatum date,
p_enddatum date,
p_projektbudget decimal(12,2),
p_a_abteilung char(3) not null,

foreign key (p_m_projektleiter)
	references m_mitarbeiter (m_mitarbeiternr)
    on delete no action on update cascade,

foreign key (p_a_abteilung)
	references a_abteilungen (a_abteilungid)
    on delete no action on update cascade,

primary key(p_projektid, p_m_projektleiter)
);

create table if not exists pm_projektmitarbeiter (
pm_p_projektid char(5) not null,
pm_m_mitarbeiternr int(4) not null,
pm_stunden decimal(4,1),

foreign key (pm_p_projektid)
	references p_projekte (p_projektid)
    on delete no action on update cascade,
    
foreign key (pm_m_mitarbeiternr)
	references m_mitarbeiter (m_mitarbeiternr)
    on delete no action on update cascade,
    
primary key (pm_p_projektid, pm_m_mitarbeiternr)
);

alter table m_mitarbeiter add foreign key (m_a_abteilung)
	references a_abteilungen (a_abteilungid)
    on delete set null on update cascade;
    
set foreign_key_checks = 0;

insert into m_mitarbeiter (m_mitarbeiternr, m_name, m_vorname, m_a_abteilung)
values
(1269,'SCHMIDT','KLAUS', 'BHA'),
(3266,'HEILER','LUKAS', 'KMG'),
(1154,'BERNDT','MARIA', 'KMG'),
(1498,'SCHMIDT','MARIUS', 'VTR'),
(2082,'WALLA','HERBERT', 'BHA'),
(1529,'PETRI','WALTER', 'PER'),
(4312,'BARI','JOSEFA', 'PER'),
(1339,'SCHMOLL','TINA', 'BHA'),
(2076,'SCHLAGER','HANS', 'VTR');

insert into a_abteilungen (a_abteilungid, a_abteilungname, a_m_abteilungsleiter)
values
('BHA','Buchhaltung', 1339),
('KMG','Kundenmanagement', 1154),
('VTR','Vertrieb', 2076),
('PER','Personalmanagement', 4312);

insert into p_projekte (p_projektid, p_projektname, p_m_projektleiter, p_startdatum, p_a_abteilung, p_projektbudget, p_enddatum)
values
('PMO56', 'PM online Services',1529, '2012-11-20', 'PER', 22300, NULL),
('VER67', 'Verrechnung NEU',2082,'2013-5-2', 'BHA', 95000, NULL),
('CRM36', 'CRM System-Einführung', 3266,'2011-10-12', 'VTR', 185000, '2012-06-30'),
('BIL09', 'eBilling ', 2082, '2010-9-16', 'BHA', 33500, '2012-04-05'),
('MAG12', 'Mitarbeiter Gesundheitsvorsorge',1529, '2011-12-14', 'PER', 115000, '2013-09-08');

insert into pm_projektmitarbeiter (pm_p_projektid, pm_m_mitarbeiternr, pm_stunden)
values
('PMO56', 1529, 13),
('VER67', 2082, 72),
('CRM36', 2082, 96),
('VER67', 1269, 41),
('BIL09', 1269, 69),
('BIL09', 2082, 55),
('CRM36', 3266, 112),
('PMO56', 4312, 148),
('MAG12', 1529, 224);

set foreign_key_checks = 1;