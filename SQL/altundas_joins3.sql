# ALTUNDAS Asir Samet Übung 3 Joins

#1
select l_id, l_name, l_vorname, a_abtname
from l_lehrer left join a_abteilungen
on a_abteilungen.a_id = l_lehrer.l_a_abteilung
where l_lehrer.l_sprstunde_tag is null
order by a_abtname, l_name;


#2
select g_bez
from g_gegenstaende left join p_pruefungen
on p_pruefungen.p_g_fach = g_gegenstaende.g_id
where p_g_fach is null
order by g_bez;


#3
select l_id, l_name,  l_vorname, g_bez, p_datum
from p_pruefungen join l_lehrer
on l_lehrer.l_id = p_pruefungen.p_l_pruefer join g_gegenstaende
on g_gegenstaende.g_id = p_pruefungen.p_g_fach
where g_id in ('POS', 'AM', 'E')
order by l_name, g_bez, p_datum;

#4
select  concat(l_lehrer.l_name, ' ', l_lehrer.l_vorname) as Lehrer, l_lehrer.l_id, concat(l_chef.l_name, ' ', l_chef.l_vorname) as vorgesetzter, (year(curdate()) - l_lehrer.l_eintrittsjahr) as dienstjahre
from l_lehrer left join l_lehrer l_chef
on l_chef.l_id = l_lehrer.l_l_chef left join k_klassen
on k_klassen.k_l_klavst = l_lehrer.l_id
where (year(curdate()) - l_lehrer.l_eintrittsjahr) > 7 and k_klassen.k_l_klavst is null
order by l_chef.l_name, l_lehrer.l_gs_geschlecht desc, l_lehrer.l_name, dienstjahre;


#5
select concat(l_name, " ", l_vorname) as Pruefer, g_bez , p_datum, p_note
from p_pruefungen inner join l_lehrer
on l_lehrer.l_id = p_pruefungen.p_l_pruefer inner join k_klassen
on k_klassen.k_l_klavst = l_lehrer.l_id inner join g_gegenstaende
on g_gegenstaende.g_id = p_pruefungen.p_g_fach;

#6
select s_nr, concat(s_name, ' ', s_vorname) as SchuelerInnen, s_k_klasse as Klasse
from s_schueler left join p_pruefungen
on p_pruefungen.p_s_kandidat = s_schueler.s_nr
where s_gs_geschlecht = 2 and p_s_kandidat is null
order by s_k_klasse, s_name;

#7
select l_id, l_name, l_vorname, (year(curdate()) - l_eintrittsjahr) as Dienstjahre
from l_lehrer
where (year(curdate()) - l_eintrittsjahr) < 10
order by dienstjahre desc, l_name;

#8
select s_vorname, s_name, s_gebdat
from s_schueler
where s_gs_geschlecht = 2 and day(s_gebdat) = 23
order by s_gebdat desc;

#9
select k_id ,concat(s_name, ' ', s_vorname) as Schueler, p_datum, concat(l_name, ' ', l_vorname) as Lehrer, g_bez, p_note
from p_pruefungen inner join s_schueler
on s_schueler.s_nr = p_pruefungen.p_s_kandidat inner join k_klassen
on k_klassen.k_id = s_schueler.s_k_klasse inner join l_lehrer
on l_lehrer.l_id = p_pruefungen.p_l_pruefer inner join g_gegenstaende
on g_gegenstaende.g_id = p_pruefungen.p_g_fach
where l_eintrittsjahr is null and k_id like '3%'
order by k_id, s_name, g_bez, p_datum desc;

#10
select k_id , a_abtname
from k_klassen left join s_schueler
on s_schueler.s_k_klasse = k_klassen.k_id left join a_abteilungen
on a_abteilungen.a_id = k_klassen.k_a_abteilung
where s_nr is null
order by a_abtname, k_id;

#11
select concat(s_vorname, ' ', s_name) as SchuelerName, gs_mw , timestampdiff(year, s_gebdat, curdate()) as Altersstufe, s_gebdat, s_k_klasse
from s_schueler inner join gs_geschlechter
on gs_geschlechter.gs_id = s_schueler.s_gs_geschlecht
where timestampdiff(year, s_gebdat, curdate()) < 19
order by s_k_klasse, s_gebdat desc;

#12
select k_id, l_id, concat(l_name, ' ', l_vorname) as Lehrer, concat(s_schueler.s_name, ' ', s_schueler.s_vorname) as Klassensprecher
from k_klassen inner join l_lehrer
on l_lehrer.l_id = k_klassen.k_l_klavst left join s_schueler
on s_schueler.s_nr = k_klassen.k_s_klaspr
where l_eintrittsjahr is null
order by l_name, k_id;