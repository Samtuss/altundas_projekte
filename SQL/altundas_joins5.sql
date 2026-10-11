# ALTUNDAS Samet 

# 1 Wie viele Schüler wohnen nicht in Wien (über PLZ ermitteln)?

select count(s_nr)
from s_schueler
where s_plz > 1999;

# 2 Wie viele Lehrer haben keine Sprechstunde eingetragen?

select count(l_id)
from l_lehrer
where l_sprstunde_tag is null;

# 3 Wie viel beträgt das Durchschnittsgehalt aller Lehrer?

select avg(l_gehalt)
from l_lehrer;

# 4 Wieviel beträgt das Durchschnittsgehalt der Lehrer pro Abteilung?

select avg(l_gehalt), l_a_abteilung, count(l_id)
from l_lehrer
group by l_a_abteilung;

# 5 Wie viele Stunden haben die Klassen? (Klasse, Stundenanzahl)

select k_id, count(st_stunde)
from st_stunden right join k_klassen on k_klassen.k_id = st_stunden.st_k_klasse
group by k_id;

# 6 Wie viele Schüler gibt es je Klasse in der HIF? (Klasse, Schüleranz...)

select k_id, count(s_nr)
from s_schueler right join k_klassen on s_schueler.s_k_klasse = k_klassen.k_id
where k_id like ('%HIF')
group by k_id
having count(s_nr) >= 20;

# 7 Wie viele Mädchen gibt es in der Schule?

select count(*) as anzahl_maedchen
from s_schueler s
join gs_geschlechter g on s.s_gs_geschlecht = g.gs_id
where g.gs_mw = 'w';

# 8 Wie viele Mädchen gibt es in den Klassen je Abteilung? (Abteilung, Klasse, Anzahl Mädls)

select a.a_abtname, k.k_id, count(s.s_nr) as anzahl_maedchen
from s_schueler s
join gs_geschlechter g on s.s_gs_geschlecht = g.gs_id
join k_klassen k on s.s_k_klasse = k.k_id
join a_abteilungen a on k.k_a_abteilung = a.a_id
where g.gs_mw = 'w'
group by a.a_abtname, k.k_id;

# 9 Wie viele Lehrer je Abteilung haben am Mittwoch oder Donnerstag Sprechstunde? (Abteilung, Tag, Anzahl Lehrer)

select a.a_abtname, l.l_sprstunde_tag, count(l.l_id) as anzahl_lehrer
from l_lehrer l
join a_abteilungen a on l.l_a_abteilung = a.a_id
where l.l_sprstunde_tag in ('Mittwoch', 'Donnerstag')
group by a.a_abtname, l.l_sprstunde_tag;

# 10 Welche Klassen haben mind. 3 POS- oder NSCS-Stunden? (Klasse, Fach, Stundenanz.)

select st.st_k_klasse, st.st_g_fach, count(*) as stundenanzahl
from st_stunden st
where st.st_g_fach in ('POS', 'NSCS')
group by st.st_k_klasse, st.st_g_fach
having count(*) >= 3;

#11 In welchen Abteilungen gibt es mehr als 10 Lehrerinnen (nur weibl.!)

select a.a_abtname, count(l.l_id) as anzahl_lehrerinnen
from l_lehrer l
join gs_geschlechter g on l.l_gs_geschlecht = g.gs_id
join a_abteilungen a on l.l_a_abteilung = a.a_id
where g.gs_mw = 'w'
group by a.a_abtname
having count(l.l_id) > 10;

#12 In welchen Klassen ist die Durchschnittsnote der Prüfungen besser als befriedigend? (Klasse, Durchschnittsnote)

select s.s_k_klasse, avg(p.p_note) as durchschnittsnote
from p_pruefungen p
join s_schueler s on p.p_s_kandidat = s.s_nr
group by s.s_k_klasse
having avg(p.p_note) < 3;