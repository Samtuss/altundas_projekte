# Übung mit joins

#1
select concat(l_name, ' ', l_vorname) as Lehrer, a_abtname, a_kurzel
from a_abteilungen inner join l_lehrer
on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
where l_name = 'Kovar';

#2
select s_k_klasse, k_id, k_bez, concat(s_name, ' ', s_vorname) as Schüler, s_PLZ
from s_schueler inner join k_klassen
on s_schueler.s_k_klasse = k_klassen.k_id
where s_plz in (1210, 1220)
# where s_plz = 1210 or s_plz = 1220
;

#3
select k_id, a_abtname, a_id
from a_abteilungen inner join k_klassen
on k_klassen.k_a_abteilung = a_abteilungen.a_id
inner join l_lehrer on l_lehrer.l_id = k_klassen.k_l_klavst
order by a_abtname, k_id;

#4
select a_id, a_abtname, a_kurzel, concat(l_name, ' ', l_vorname) as AV, gs_maennlichweiblich
from a_abteilungen inner join l_lehrer
on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
inner join gs_geschlechter on l_lehrer.l_gs_geschlecht = gs_geschlechter.gs_id
order by a_abtname, l_name;

#5
select k_id, a_abtname, a_kurzel, concat(l_name, ' ', l_vorname) as AV, gs_maennlichweiblich
from a_abteilungen inner join l_lehrer
on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
inner join gs_geschlechter on l_lehrer.l_gs_geschlecht = gs_geschlechter.gs_id
inner join k_klassen on a_abteilungen.a_id = k_klassen.k_bez
order by k_id;

#6
select concat(s_name,' ', s_vorname) as Schülerinnen, k_bez, l_name
from s_schueler inner join k_klassen
on s_schueler.s_k_klasse = k_klassen.k_id
inner join l_lehrer on k_klassen.k_l_klavst = l_lehrer.l_id
where s_schueler.s_gs_geschlecht = 2 and l_lehrer.l_gs_geschlecht = 2;