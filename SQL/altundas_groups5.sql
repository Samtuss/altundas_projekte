# ALTUNDAS Samet

#1

select l_vorname, count(*) as anzahl_lehrer
from l_lehrer
group by l_vorname
order by anzahl_lehrer desc;

#2

select a.a_abtname, a.a_l_abtleiter, count(l.l_id) as anzahl_lehrer
from a_abteilungen a
left join l_lehrer l on l.l_a_abteilung = a.a_id
group by a.a_id, a.a_abtname, a.a_l_abtleiter;

#3

select a.a_abtname, k.k_id, count(s.s_nr) as anzahl_schueler
from k_klassen k
left join s_schueler s on s.s_k_klasse = k.k_id
left join a_abteilungen a on k.k_a_abteilung = a.a_id
group by a.a_abtname, k.k_id;

#4

select year(s_gebdat) as jahr, count(*) as anzahl_schueler
from s_schueler
where s_gebdat is not null
group by year(s_gebdat)
order by jahr;

#5

select max(l_gehalt) as max_gehalt
from l_lehrer;

#6

select a.a_abtname, a.a_l_abtleiter, g.gs_maennlichweiblich, avg(l.l_gehalt) as durchschnittsgehalt
from l_lehrer l
join a_abteilungen a on l.l_a_abteilung = a.a_id
join gs_geschlechter g on l.l_gs_geschlecht = g.gs_id
group by a.a_abtname, a.a_l_abtleiter, g.gs_maennlichweiblich;

#7

select l.l_id, l.l_name, avg(p.p_note) as durchschnittsnote
from p_pruefungen p
join l_lehrer l on p.p_l_pruefer = l.l_id
group by l.l_id, l.l_name;

select p_g_fach, l_id, l_name, l_vorname, avg(p_note) as durchschnittsnote
from l_lehrer inner join p_pruefungen on l_lehrer.l_id = p_pruefungen.p_l_pruefer
group by p_g_fach, l_id, l_name, l_vorname;

#8

select g.g_id, g.g_bez, avg(p.p_note) as durchschnittsnote
from p_pruefungen p
join g_gegenstaende g on p.p_g_fach = g.g_id
group by g.g_id, g.g_bez;

#9

select g.g_id, g.g_bez, avg(p.p_note) as durchschnittsnote
from p_pruefungen p
join g_gegenstaende g on p.p_g_fach = g.g_id
group by g.g_id, g.g_bez
having avg(p.p_note) < 3;

#10

select g.g_bez, count(distinct p.p_l_pruefer) as anzahl_lehrer
from p_pruefungen p
join g_gegenstaende g on p.p_g_fach = g.g_id
group by g.g_bez;

#11

select a.a_abtname, count(l.l_id) as anzahl_lehrer
from l_lehrer l
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
left join p_pruefungen p on l.l_id = p.p_l_pruefer
where p.p_l_pruefer is null
group by a.a_abtname;

#12

select a.a_abtname, a.a_l_abtleiter, count(k.k_l_klavst) as anzahl_klavst
from k_klassen k
join l_lehrer l on k.k_l_klavst = l.l_id
join a_abteilungen a on k.k_a_abteilung = a.a_id
join gs_geschlechter g on l.l_gs_geschlecht = g.gs_id
where g.gs_mw = 'w'
group by a.a_abtname, a.a_l_abtleiter
having count(k.k_l_klavst) > 2;

#13

select l.l_id, l.l_name, g.g_id, g.g_bez, avg(p.p_note) as durchschnittsnote
from p_pruefungen p
join l_lehrer l on p.p_l_pruefer = l.l_id
join g_gegenstaende g on p.p_g_fach = g.g_id
group by l.l_id, l.l_name, g.g_id, g.g_bez;

#14

select a.a_abtname, min(l.l_gehalt) as minimum_gehalt, max(l.l_gehalt) as maximum_gehalt
from l_lehrer l
join a_abteilungen a on l.l_a_abteilung = a.a_id
group by a.a_abtname;

#15

select s.s_k_klasse, s.s_ort, count(*) as anzahl_schueler
from s_schueler s
group by s.s_k_klasse, s.s_ort
order by s.s_k_klasse, anzahl_schueler desc;

#16

select a.a_abtname, count(distinct k.k_id) as anzahl_klassen
from k_klassen k
join a_abteilungen a on k.k_a_abteilung = a.a_id
left join s_schueler s on s.s_k_klasse = k.k_id
left join p_pruefungen p on s.s_nr = p.p_s_kandidat
where p.p_s_kandidat is null
group by a.a_abtname;

#17

select a.a_abtname, sum(l.l_gehalt) as summe_gehaelter
from l_lehrer l
join a_abteilungen a on l.l_a_abteilung = a.a_id
group by a.a_abtname;

#18

select a.a_l_abtleiter, a.a_abtname, count(l.l_id) as anzahl_lehrer
from l_lehrer l
join a_abteilungen a on l.l_a_abteilung = a.a_id
where l.l_gehalt < 300
and l.l_id not in (select k_l_klavst from k_klassen where k_l_klavst is not null)
group by a.a_l_abtleiter, a.a_abtname
having count(l.l_id) >= 2;

#19

select year(p.p_datum) as jahr, g.g_bez, max(p.p_note) as schlechteste_note, min(p.p_note) as beste_note
from p_pruefungen p
join g_gegenstaende g on p.p_g_fach = g.g_id
group by year(p.p_datum), g.g_bez
order by jahr;

#20

select s.s_k_klasse, count(*) as anzahl_maedchen
from s_schueler s
join gs_geschlechter g on s.s_gs_geschlecht = g.gs_id
where g.gs_mw = 'w'
group by s.s_k_klasse
having count(*) >= 3;