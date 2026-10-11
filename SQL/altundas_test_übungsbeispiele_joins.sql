# Übungsbeispiele für Test
# ALTUNDAS Samet

#A01  Wie viele Lehrer und Lehrerinnen (also je Geschlecht) haben keine Sprechstunde eingetragen? 
# Ausgabe: Bezeichnung 'Lehrer'/'Lehrerin', Anzahl der Personen

select gs_lehrer, count(l_id)
from l_lehrer
inner join gs_geschlechter on l_lehrer.l_gs_geschlecht = gs_geschlechter.gs_id
where l_sprstunde_tag is null
group by gs_lehrer;

#A02  Welche Schüler wurden von einem Klassenvorstand geprüft?
#Ausgabe: Schülername, Klasse, Klassenvorstand-Kürzel, Fach-Kürzel

select  distinct concat(s_name, " ", s_vorname) as Schulername, s_k_klasse, k_l_klavst, p_g_fach
from s_schueler
inner join p_pruefungen on s_schueler.s_nr = p_pruefungen.p_s_kandidat
inner join k_klassen on s_schueler.s_k_klasse = k_klassen.k_id
inner join l_lehrer on l_lehrer.l_id = k_l_klavst
where k_l_klavst = p_l_pruefer;

#A03  Gebe die Anzahl der Prüfungen pro Abteilung und Lehrerin (nur weibliche Prüfer) aus?  
#Ausgabe: Abteilungsname, Lehrername, Anzahl der Prüfungen, sortiert nach Anzahl der Prüfungen und Zuname

select a_abtname, concat(l_name, " ", l_vorname) as Lehrername, count(p_s_kandidat) as anzahl
from l_lehrer l
inner join p_pruefungen p on l.l_id = p.p_l_pruefer
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
where l_gs_geschlecht = 2
group by Lehrername, a_abtname
order by anzahl desc, Lehrername;

#A04  Wie viel 3-er hat es bei den Prüfungen je Fach und Prüfer gegeben? 
#Ausgabe: Gegenstandsbezeichnung, Lehrername, Anzahl der 3-er.

select g_bez, concat(l_name, " ", l_vorname) as Lehrername, count(p_note), p_note
from p_pruefungen p
inner join g_gegenstaende g on g.g_id = p.p_g_fach
inner join l_lehrer l on l.l_id = p_l_pruefer
where p_note = 3
group by g_bez, Lehrername, p_note;

#A05  Wo wohnen die Schülerinnen (nur weibliche) der Informatik-Klassen 
#(alle Informatik Klassen, auch die Fachschulklassen mit einbezogen)?   
#Ausgabe: Schülername, Klasse, Wohnort, sortiert nach Klasse und Schülername

select concat(s_name, " ", s_vorname) as Schulername, s_k_klasse, s_ort
from s_schueler
where s_gs_geschlecht = 2 and s_k_klasse like ('%HIF%')
order by s_k_klasse, Schulername;

#A06  Liste pro Abteilung die Anzahl der Schüler auf. 
#Die Abteilungen, zu denen keine Schüler gehören, sollen auch in der Liste angeführt werden. 
#Ausgabe: Abteilungsname, Anzahl der Schüler, sortiert nach Anzahl der Schüler absteigend.

select a_abtname, count(s_nr) as anzahl
from a_abteilungen a
left join k_klassen k on a.a_id = k.k_a_abteilung
left join s_schueler s on s.s_k_klasse = k.k_id
group by a_abtname
order by anzahl desc;

#A07  In welchen Gegenständen hat es mehr als 2 Prüfungen gegeben, die mit der Note 4 beurteilt wurden? 
#Ausgabe: Gegenstandsbezeichnung, Anzahl der Prüfungen, sortiert nach Anzahl der Prüfungen absteigend

select g_bez, count(p_s_kandidat) as anzahl
from p_pruefungen p
inner join g_gegenstaende g on p.p_g_fach = g.g_id
where p_note = 4
group by g_bez
having count(p_s_kandidat) > 2
order by anzahl desc;

#A08  Gebe die Lehrer aus, die kein Klassenvorstand sind und auch keine Sprechstunde eingetragen haben. 
#Ausgabe: Lehrerkürzel, Lehrername, Vorgesetzte

select l_id, concat(l_name, " ", l_vorname) as Lehrername, l_l_chef
from l_lehrer l
left join k_klassen k on l.l_id = k.k_l_klavst
where k_l_klavst is null and l_sprstunde_tag is null;

#A09  Erstellen Sie eine Statistik, die zeigt, wie viele Prüfungen je Klasse und Fach stattgefunden haben. 
#Ausgabe: Klasse, Gegenstandsname, Anzahl der Prüfungen

select s_k_klasse, p_g_fach, count(p_s_kandidat) as anzahl
from s_schueler s
inner join p_pruefungen p on s.s_nr = p.p_s_kandidat
group by s_k_klasse, p_g_fach;

#A10  In welchen Gegenständen haben die Schüler, die nicht in Wien wohnen Prüfungen abgelegt? 
#Ausgabe: Klasse, Schülername, Gegenstandsbezeichnung, Duplikate sollen in der Ausgabe nicht erscheinen

select distinct s_k_klasse, concat(s_name, " ", s_vorname) as Schulername, g_bez, s_ort
from p_pruefungen p
inner join g_gegenstaende g on g.g_id = p.p_g_fach
inner join s_schueler s on s.s_nr = p.p_s_kandidat
where s_plz < 1000 or s_plz > 1999;

#---------------------------------------------------------------------------------------------------------------

#1 Wie viele Lehrer haben den gleichen Vornamen? 
# (Vorname, Anzahl der Lehrer, sortiert nach Anzahl der Lehrer absteigend)

select count(l_id) as anzahl, l_vorname
from l_lehrer
group by l_vorname
order by anzahl desc;

#2 Wie viele Lehrer gehören zu den einzelnen Abteilungen? 
# Ausgabe: Abteilungsname, Kürzel des Vorgesetzten, Anzahl der Lehrer)

select a_l_abtleiter, count(l_id) as anzahllehrer, a_abtname
from l_lehrer l
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
group by a_l_abtleiter, a_abtname;

#3 Wie viele Schüler haben die Klassen? 
# (Abteilungsname, Klasse, Anzahl der Schüler)

select a_abtname, s_k_klasse, count(s_nr) as anzahl
from k_klassen k
inner join s_schueler s on k.k_id = s.s_k_klasse
inner join a_abteilungen a on a.a_id = k.k_a_abteilung
group by a_abtname, s_k_klasse;

#4 Wie viele Schüler sind in den einzelnen Jahren geboren? 
# (Jahr, Anzahl der Schüler) 

select year(s_gebdat), count(s_nr) as anzahl
from s_schueler s
group by year(s_gebdat);

#5 Wie viel beträgt das maximale Gehalt bei den Lehrern? 
# (Gehalt)

select max(l_gehalt)
from l_lehrer l;

#6 Wie viel beträgt das Durchschnittsgehalt der Lehrer und Lehrerinnen (nach Geschlecht getrennt) proAbteilung? 
# Ausgabe: Abteilungsname, Kürzel des Vorgesetzten, Geschlecht, Durchschnittsgehalt 

select a_abtname, a_l_abtleiter, l_gs_geschlecht, avg(l_gehalt)
from l_lehrer l
inner join a_abteilungen a on a.a_id = l.l_a_abteilung
group by a_abtname, a_l_abtleiter, l_gs_geschlecht;

#7 Was ist die Durchschnittsnote pro Prüfer? 
# (L-Nr, Lehrername, Durchschnittsnote)

select l_id, concat(l_name, " ", l_vorname) as Lehrername, avg(p_note)
from l_lehrer l
inner join p_pruefungen p on l.l_id = p.p_l_pruefer
group by l_id, Lehrername;

#8 Was ist die Durchschnittsnote pro Fach ? 
# (Fachkürzel, Gegenstandname, Durchschnittsnote) 

select p_g_fach, g_bez, avg(p_note) as avgnote
from p_pruefungen p
inner join g_gegenstaende g on p.p_g_fach = g.g_id
group by p_g_fach, g_bez;

#9 Bei welchen Fächern ist die Durchschnittsnote besser als befriedigend? 
#(Fachkürzel, Gegenstandname, Durchschnittsnote)

select p_g_fach, g_bez, avg(p_note) as avgnote
from p_pruefungen p
inner join g_gegenstaende g on p.p_g_fach = g.g_id
group by p_g_fach, g_bez
having avgnote < 3;

#10 Wie viele Lehrer gibt es je Prüfungsfach? – nur die verschiedenen Lehrer zählen 
# (Gegenstandsname, Anzahl der Lehrer)

select g_bez, count(distinct l_id)
from l_lehrer l
inner join p_pruefungen p on l.l_id = p.p_l_pruefer
inner join g_gegenstaende g on g.g_id = p.p_g_fach
group by g_bez;

#11 Wie viele Lehrer haben keine Prüfungen durchgeführt, nach Abteilungen aufgeschlüsselt? 
# (Abteilungsname, Anzahl der Lehrer) 

select a_abtname, count(l_id) as anzahl
from l_lehrer l
left join p_pruefungen p on l.l_id = p.p_l_pruefer
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
where p_l_pruefer is null
group by a_abtname;

#12 In welchen Abteilungen gibt es mehr als 2 weibliche Klassenvorstände? 
# (Abteilungsname, Kürzel AV, Anzahl der Klassenvorstände) 

select a_abtname, a_l_abtleiter, count(k_l_klavst) as anzahl
from l_lehrer l
inner join k_klassen k on k.k_l_klavst = l.l_id
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
where l_gs_geschlecht = 2
group by a_abtname, a_l_abtleiter
having anzahl > 2;

#13. Was ist die Durchschnittsnote pro Prüfer und Fach? 
# (L-Nr, Lehrername, Fachkürzel, Gegenstandsname, Durchschnittsnote) 

select l_id, concat(l_name, " ", l_vorname) as Lehrername, p_g_fach, g_bez, avg(p_note)
from p_pruefungen p
inner join g_gegenstaende g on g.g_id = p.p_g_fach
inner join l_lehrer l on l.l_id = p.p_l_pruefer
group by l_id, Lehrername, p_g_fach, g_bez;

#14 Wie viel beträgt das minimale und maximale Gehalt bei den Lehrern je Abteilung? 
# (Abteilungsname, MinimumGehalt, Maximum-Gehalt)

select a_abtname, min(l_gehalt) as mingehalt, max(l_gehalt) as maxgehalt
from a_abteilungen a
inner join l_lehrer l on a.a_id = l.l_a_abteilung
group by a_abtname;

#15 Wie viele Schüler je Klasse wohnen im gleichen Ort? 
# (Klasse, Ort, Anzahl der Schüler)

select s_k_klasse, s_ort, count(s_nr) as anzahl
from s_schueler s
group by s_k_klasse, s_ort;

#16 In wie vielen Klassen haben die Schüler keine Prüfungen gemacht? 
# (Abteilungsname, Anzahl der Klassen) 

select a_abtname, count(distinct k_id) as anzahlklassen
from a_abteilungen a
inner join k_klassen k on a.a_id = k.k_a_abteilung
left join s_schueler s on s.s_k_klasse = k.k_id
left join p_pruefungen p on p.p_s_kandidat = s.s_nr
where p_s_kandidat is null
group by a_abtname;

#17 Wie viel beträgt die Summe der Lehrergehälter je Abteilung? 
# (Abteilungsname, Summe der Gehälter) 
select a_abtname, sum(l_gehalt) as sumgehalt
from l_lehrer l
inner join a_abteilungen a on a.a_id = l.l_a_abteilung
group by a_abtname;

#18 In welchen Abteilungen gibt es mindestens 2 Lehrer, die kein Klassenvorstand sind und weniger als 
#300 Gehalt haben? 
#( Vorgesetzte, Abteilungsname, Anzahl der Lehrer) 

select l_l_chef, a_abtname, count(l_id) as anzahl
from l_lehrer l
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
left join k_klassen k on l.l_id = k.k_l_klavst
where l_gehalt < 300 and k_l_klavst is null
group by l_l_chef, l_a_abteilung
having anzahl >= 2;

#19 Was ist die schlechteste und die beste Note je Prüfungsfach und Jahr? 
# (Jahr, Gegenstandsname, schlechteste Note, beste Note)

select year(p_datum) as jahr, g_bez, min(p_note) as bestenote, max(p_note) as schlechtestenote
from p_pruefungen p
inner join g_gegenstaende g on g.g_id = p.p_g_fach
group by jahr, g_bez;

#20 In welchen Klassen gibt es mindestens 3 Mädchen? 
# (Klasse, Anzahl der Mädels)

select s_k_klasse, count(s_gs_geschlecht) as anzahl
from s_schueler s
where s_gs_geschlecht = 2
group by s_k_klasse
having anzahl >= 3;

# -------------------------------------------------------------------------------------------------------------

#B01 Liste die Namen der Mädchen auf, die am Donnerstag Unterrichtssunden in Programmieren haben.
#Ausgabe: Klasse, Schülername, Unterrichtsstunde, Lehrername, Raum, sortiert nach Lehrernamen und Klasse

select s_k_klasse, concat(s_name, " ", s_vorname) as Schulername, st_stunde,
concat(l_name, " ", l_vorname) as Lehrername, r_id
from st_stunden st
inner join r_raume r on r.r_id = st.st_r_raum
inner join l_lehrer l on l.l_id = st.st_l_lehrer
inner join k_klassen k on st.st_k_klasse = k.k_id
inner join s_schueler s on k.k_id = s.s_k_klasse
where st_stunde like "DO%" and st_g_fach in ("POS") and s_gs_geschlecht = 2
order by Lehrername, s_k_klasse;

# B02 Welche HIF-Schüler sind in den Wintermonaten geboren und gehen in eine Klasse ohne Mädchen?
#Ausgabe: Schülername, Geburtsmonat, Klasse, sortiert nach Klasse, aber die jüngeren Schüler sollen vorne stehen

select concat(s_name, " ", s_vorname) as Schulername, s_gebdat, s_k_klasse
from s_schueler s
left join k_klassen k on k.k_id = s.s_k_klasse
where s_k_klasse like "%HIF%" and month(s_gebdat) in (12, 1, 2) and s_gs_geschlecht = 1
order by s_k_klasse, s_gebdat desc;

# B03 Welche Gegenstände haben LehrerInnen geprüft, die nicht der Informatik-Abteilung zugehören?
#Ausgabe: Gegenstandsbezeichnung, Lehrer-ID, Lehrername, Abteilungsname, sortiert nach Abteilungsname,
#die Damen sollen aber vor den Herren stehen

select g_bez, l_id, concat(l_name, " ", l_vorname) as Lehrername, a_abtname, l_gs_geschlecht
from p_pruefungen p
inner join g_gegenstaende g on g.g_id = p.p_g_fach
inner join l_lehrer l on l.l_id = p.p_l_pruefer
inner join a_abteilungen a on l.l_a_abteilung = a.a_id
where a_kurzel not like "IF"
order by a_abtname, l_gs_geschlecht desc;

# B04 Wann haben Klassenvorstände der 2. und 3. Jahrgängen Sprechstunde?
# Ausgabe: Abteilungsname, Klasse, Name des KVs, Sprechstunde, sortiert nach Abteilungsname und Klasse

select a_abtname, k_id, l_name, l_sprstunde_tag
from l_lehrer l
inner join k_klassen k on k.k_l_klavst = l.l_id
inner join a_abteilungen a on k.k_a_abteilung = a.a_id
where k_id like "2%" or k_id like "3%"
order by a_abtname, k_id;

# B05 Liste alle (!) Klassen mit dem Namen des KVs und dem Namen des Klassensprecher-Stellvertreters auf.
# Ausgabe: Klasse, Name des KVs, Name des Klassensprecher-Stellvertreters

select k_id, l_name, s_name
from k_klassen k
left join s_schueler s on s.s_nr = k.k_s_klasprstv
left join l_lehrer l on l.l_id = k.k_l_klavst;

# B06 Zu welchen Abteilungen gehören keine Klassen?
# Ausgabe: Abteilungsname und Name des Abteilungsvorstandes

select a_abtname, l_name
from a_abteilungen a
left join l_lehrer l on l.l_id = a.a_l_abtleiter
left join k_klassen k on k_a_abteilung = a.a_id
where k_a_abteilung is null;

# B07 Liste alle Klassen auf in denen die Schüler/innen keine Prüfungen abgelegt haben.
# Ausgabe: Klasse, Name des Klassenvortands, nach Namen des KVs sortiert, aber die weiblichen KV sollen am
# Anfang der Liste stehen

select distinct k_id, l_name
from k_klassen k
inner join l_lehrer l on k.k_l_klavst = l.l_id
left join p_pruefungen p on p.p_l_pruefer = l.l_id
left join s_schueler s on s.s_k_klasse = k.k_id
where p_s_kandidat is null
order by l_gs_geschlecht desc, l_name;

# B08 In welchen Räumen haben keine 3. Klassen Unterricht?
# Ausgabe: Raum-ID und Plätze, sortiert nach den Plätzen absteigend

select distinct r_id, r_plaetze
from st_stunden st
right join r_raume r on r.r_id = st.st_r_raum
where st_k_klasse not like "3%"
order by r_plaetze desc;

# ---------------------------------------------------------------------------------------------------------

# A08
select concat(s_name, " ", s_vorname) as Schulername, s_gebdat
from s_schueler
where s_gs_geschlecht = 2 and day(s_gebdat) = 23
order by s_gebdat desc;

