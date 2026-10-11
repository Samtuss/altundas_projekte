# ALTUNDAS Samet 3BHIF

#1
select concat(l_name, " ", l_vorname) as Lehrernamen, gs_lehrer
from l_lehrer inner join gs_geschlechter on l_lehrer.l_gs_geschlecht = gs_geschlechter.gs_id
order by gs_id desc, l_name asc;

#2
select k_id
from k_klassen left join s_schueler on k_klassen.k_id = s_schueler.s_k_klasse
where s_k_klasse is null;

#3
select l_id, concat(l_name, " ", l_vorname) as Lehrername, a_abtname
from l_lehrer left join a_abteilungen on l_lehrer.l_id = a_abteilungen.a_l_abtleiter
order by a_abtname desc, l_name, a_abtname;

#4
select k_id, st_stunde
from k_klassen left join st_stunden on k_klassen.k_id = st_stunden.st_k_klasse
where st_k_klasse is null;

#5
select l_id, concat(l_name, " ", l_vorname) as Lehrername, k_id, l_sprstunde_tag, k_l_klavst
from l_lehrer left join k_klassen on l_lehrer.l_id = k_klassen.k_l_klavst;

#6
select k_id, s_name, s_vorname
from k_klassen left join s_schueler
on k_klassen.k_s_klaspr = s_schueler.s_k_klasse
where k_s_klaspr is null;

#7
select k_id, l_id
from l_lehrer left join k_klassen
on l_lehrer.l_id = k_klassen.k_l_klavst
where k_l_klavst is null;

#8
select a_abtname, l_id, l_name, l_vorname, l_eintrittsjahr
from a_abteilungen inner join l_lehrer
on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
where l_eintrittsjahr is null;

#9
select s_nr, s_name, s_vorname, p_g_fach, p_note
from p_pruefungen inner join s_schueler
on p_pruefungen.p_s_kandidat = s_schueler.s_nr;

#10
select g_id, g_bez
from g_gegenstaende left join p_pruefungen
on g_gegenstaende.g_id = p_pruefungen.p_g_fach
where p_g_fach is null;