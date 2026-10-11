# ALTUNDAS Samet 11.02.2026 3BHIF
# Abfragen mit und ohne Joins DON2025v2

#1 Gib aus den Namen aller Klassenvorstände unter Angabe der dazugehörigen Klasse, alphabetisch nach 
# Lehrernamen sortiert.

select l_name, l_vorname, k_id
from l_lehrer inner join k_klassen on k_klassen.k_l_klavst = l_lehrer.l_id
order by l_name;


#2 Gebe alle Abteilungen mit Namen und Geschlecht des AV aus

select a_abtname, a_l_abtleiter, gs_maennlichweiblich
from l_lehrer inner join gs_geschlechter on gs_geschlechter.gs_id = l_lehrer.l_gs_geschlecht
inner join a_abteilungen on a_abteilungen.a_l_abtleiter = l_lehrer.l_id;


#3  Wir suchen die Lehrer/innen (Name und Sprechstunde), die das Fach Programmieren (POS) oder Mathe (AM) 
# geprüft haben. Jede/r Lehrer/in soll nur 1x in der Liste aufscheinen.

select distinct l_name, l_vorname, l_sprstunde_tag, p_g_fach
from l_lehrer inner join p_pruefungen on l_lehrer.l_id = p_pruefungen.p_l_pruefer
where p_g_fach like 'POS' or p_g_fach like 'AM'
order by l_name;

#4 In welchen Klassen sind Schüler/innen in den Sommermonaten geboren? Ausgabe: Schülernr, Name, Klasse, 
# Geburtsdatum, nach Klasse und Schülername sortiert

select s_nr, s_name, s_vorname, s_k_klasse, s_gebdat
from s_schueler
where month(s_gebdat) in (6,7,8)
order by s_k_klasse, s_name;

#5 Erstelle eine Liste mit den Namen der Lehrer/innen und ihre Dienstjahre (verwende zur Berechnung die Spalte 
# Eintrittsjahr), sortiert nach Dienstjahren absteigend, bei gleichem Dienstalter sollen die Damen vor den Herren stehen

select l_name, l_vorname, year(current_date) - l_eintrittsjahr as Dienstjahre
from l_lehrer inner join gs_geschlechter on l_gs_geschlecht = gs_id
order by Dienstjahre desc, gs_maennlichweiblich desc;

#6 Gebe alle Klassen (k_id) mit dem Namen der Abteilung und des KVs (Klassenvorstand) aus, nach Klassen sortiert. 

select k_id, a_abtname, k_l_klavst
from k_klassen inner join l_lehrer on k_klassen.k_l_klavst = l_lehrer.l_id
inner join a_abteilungen on a_abteilungen.a_id = k_klassen.k_a_abteilung
order by k_id;

#7 Wir suchen alle Burschen des 3. und 4. Jahrganges, die eine bessere Note als 3 auf ihre Prüfungen bekommen 
# haben. Ausgabe: S-Name, Klasse, Fach, Note, sortiert nach Klasse, Schülername, Note.

select s_name, s_k_klasse, p_g_fach, p_note
from s_schueler left join p_pruefungen on s_schueler.s_nr = p_pruefungen.p_s_kandidat
inner join gs_geschlechter on s_schueler.s_gs_geschlecht = gs_geschlechter.gs_id
where s_gs_geschlecht = 1 and p_note < 3 and s_k_klasse like "3%" or s_k_klasse like "4%"
order by s_k_klasse, s_name, p_note;

#8 Zu welcher Abteilung sind die Lehrer/innen zugeordnet, die Sprechstunde „Nach Vereinbarung!“ haben? Ausgabe:  
# Name der Abteilung, Lehrerkürzel, Lehrername, Sprechstunde, sortiert nach Abteilungsname und Lehrername, aber 
# die Lehrerinnen sollen vor den Lehrern stehen

select a_abtname, l_id, concat(l_name, " ", l_vorname) as Lehrername, l_sprstunde_tag
from l_lehrer inner join a_abteilungen on l_lehrer.l_a_abteilung = a_abteilungen.a_id
inner join gs_geschlechter on l_lehrer.l_gs_geschlecht = gs_geschlechter.gs_id
where l_sprstunde_tag = "Nach Vereinbarung!"
order by a_abtname, gs_maennlichweiblich asc, l_name;

#9 Gebe alle Klassen mit dem Namen des AV aus

select k_id, concat(l_name, " ", l_vorname) as AVName
from a_abteilungen inner join l_lehrer on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
inner join k_klassen on a_abteilungen.a_id = k_klassen.k_a_abteilung;

#10 Liste alle Schüler/innen aus den 3. HIF-Klassen mit ihrem Alter in Jahren auf. Ausgabe: Klasse, Schülername in 
# einem Feld, Alter in Jahren, sortiert nach Klasse und Alter absteigend

select s_k_klasse, concat(s_name, " ", s_vorname) as Schulername, year(current_date) - year(s_gebdat) as _Alter
from s_schueler
where s_k_klasse like "3BHIF"
order by s_k_klasse, _Alter desc;

#11 Wir suchen alle Lehrerinnen (nur weibliche) die am Donnerstag oder Mittwoch oder Freitag Sprechstunde haben. 
# Ausgabe: Kürzel, Name, Sprechstunde, nach Sprechstunde und Namen sortiert.

select l_id, l_name, l_vorname, l_sprstunde_tag, gs_maennlichweiblich
from l_lehrer inner join gs_geschlechter on l_lehrer.l_gs_geschlecht = gs_id
where gs_maennlichweiblich = 'weiblich'
and l_sprstunde_tag in ('Mittwoch', 'Donnerstag', 'Freitag')
order by l_sprstunde_tag, l_name;

#12 Wir suchen die Lehrer/innen (Lehrername, Gegenstandsname), die nicht die Fächer Programmieren, Mathe oder 
# Rechnungswesen geprüft haben. Jede/r Lehrer/in soll nur 1x in der Liste stehen

select distinct l_name, l_vorname, p_g_fach
from l_lehrer
inner join p_pruefungen on l_lehrer.l_id = p_pruefungen.p_l_pruefer
where p_g_fach not in ('POS', 'AM', 'RW');

#13 In welcher Abteilung ist der Lehrer Kovar der Abteilungsvorstand und welche Klassen gehören zu dieser Abteilung?  
# Ausgabe: Klassen-ID, Abteilungsname, Kürzel des KVs.

select k_id, a_abtname, l_id
from a_abteilungen inner join l_lehrer on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
inner join k_klassen on a_abteilungen.a_id = k_klassen.k_a_abteilung
where l_name = "Kovar";

#14  Welche Lehrer/innen und wann unterrichten in den Klassen Mathe oder Programmieren? Ausgabe: Lehrernamen, 
# Klasse, Fach, Stunde, sortiert nach Lehrernamen, Klasse, Fach. (Anmerkung: Tabelle st_stunden bildet den 
# Stundenplan ab)

select l_name, l_vorname, st_k_klasse, st_g_fach, st_stunde
from st_stunden inner join l_lehrer on st_stunden.st_l_lehrer = l_lehrer.l_id
where st_g_fach in ("AM", "POS")
order by l_name, st_k_klasse, st_g_fach;

# 15 Welche Schüler/innen haben bei einer Prüfung die Note 1 oder 2 in den Fächern Mathe, Programmieren und 
#Rechnungswesen bekommen? Ausgabe: Schülername, Klasse, Fach, Prüfer, Note, sortiert nach Schülername, Fach 
# und Note.

select s_name, s_vorname, s_k_klasse, p_g_fach, p_l_pruefer, p_note
from p_pruefungen inner join s_schueler on p_s_kandidat = s_nr
where p_note in (1,2) and p_g_fach in ("AM", "POS", "BWM")
order by s_name, p_g_fach, p_note;


