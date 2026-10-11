# ALTUNDAS Samet Joins Übungen 4 
# 25.02.2026

# B01  Liste die Namen der Mädchen auf, die am Donnerstag Unterrichtssunden in Programmieren haben. 
# Ausgabe: Klasse, Schülername, Unterrichtsstunde, Lehrername, Raum, sortiert nach Lehrernamen und Klasse 

#?????
select s_k_klasse, concat(s_name,' ', s_vorname) as Schulername, st_g_fach, l_name, st_r_raum
from s_schueler inner join k_klassen
on s_schueler.s_k_klasse = k_klassen.k_id
inner join st_stunden
on k_klassen.k_id = st_stunden.st_k_klasse
inner join l_lehrer
on st_stunden.st_l_lehrer = l_lehrer.l_id
where s_schueler.s_gs_geschlecht = 2 and st_stunden.st_g_fach in ('POS') and st_stunden.st_stunde like 'DO%'
order by l_name, k_id;

# B02  Welche HIF-Schüler sind in den Wintermonaten geboren und gehen in eine Klasse ohne Mädchen? 
# Ausgabe: Schülername, Geburtsmonat, Klasse, sortiert nach Klasse, aber die jüngeren Schüler sollen vorne stehen 

select concat(s_name,' ', s_vorname) as Schulername, s_gebdat, k_id
from a_abteilungen inner join k_klassen
on a_abteilungen.a_id = k_klassen.k_a_abteilung
inner join s_schueler
on k_klassen.k_id = s_schueler.s_k_klasse
where s_schueler.s_gs_geschlecht = 2 and a_abteilungen.a_kurzel in ('IF') and month(s_gebdat) in (12,1,2)
order by k_id, s_gebdat desc;

# B03  Welche Gegenstände haben LehrerInnen geprüft, die nicht der Informatik-Abteilung zugehören? 
# Ausgabe: Gegenstandsbezeichnung, Lehrer-ID, Lehrername, Abteilungsname, sortiert nach Abteilungsname, die Damen sollen aber vor den Herren stehen 

select g_bez, l_id, concat(l_name, " ", l_vorname) as Lehrername, a_abtname
from a_abteilungen inner join l_lehrer
on a_abteilungen.a_id = l_lehrer.l_a_abteilung
inner join p_pruefungen
on l_lehrer.l_id = p_pruefungen.p_l_pruefer
inner join g_gegenstaende
on p_pruefungen.p_g_fach = g_gegenstaende.g_id
where l_a_abteilung not in (4)
order by a_abtname, l_gs_geschlecht desc;

# B04  Wann haben Klassenvorstände der 2. und 3. Jahrgängen Sprechstunde? 
# Ausgabe: Abteilungsname, Klasse, Name des KVs, Sprechstunde, sortiert nach Abteilungsname und Klasse 

select a_abtname, k_id, concat(l_name, " ", l_vorname) as Lehrername, l_sprstunde_tag
from l_lehrer inner join k_klassen
on l_lehrer.l_id = k_klassen.k_l_klavst
left join a_abteilungen
on l_lehrer.l_id = a_abteilungen.a_l_abtleiter
where k_id like '3%' or k_id like '2%'
order by a_abtname, k_id;

# B05  Liste alle (!) Klassen mit dem Namen des KVs und dem Namen des Klassensprecher-Stellvertreters auf. 
# Ausgabe: Klasse, Name des KVs, Name des Klassensprecher-Stellvertreters 

select k_id, l_name, concat(s_name,' ', s_vorname) as KSStellvertreter
from k_klassen left join s_schueler
on k_klassen.k_s_klasprstv = s_schueler.s_nr
left join l_lehrer
on l_lehrer.l_id = k_klassen.k_l_klavst;

# B06  Zu welchen Abteilungen gehören keine Klassen? 
# Ausgabe: Abteilungsname und Name des Abteilungsvorstandes. 

select a_abtname, a_l_abtleiter, concat(l_name, " ", l_vorname) as Lehrername
from a_abteilungen left join k_klassen
on a_abteilungen.a_id = k_klassen.k_a_abteilung
inner join l_lehrer
on a_abteilungen.a_l_abtleiter = l_lehrer.l_id
where k_a_abteilung is null;

# B07 Liste alle Klassen auf in denen die Schüler/innen keine Prüfungen abgelegt haben.  
# Ausgabe: Klasse, Name des Klassenvortands, nach Namen des KVs sortiert, aber die weiblichen KV sollen am Anfang der Liste stehen 

select distinct k_id, k_l_klavst, concat(l_name, " ", l_vorname) as Lehrername
from s_schueler left join p_pruefungen
on s_schueler.s_nr = p_pruefungen.p_s_kandidat
inner join k_klassen
on s_schueler.s_k_klasse = k_klassen.k_id
inner join l_lehrer
on k_klassen.k_l_klavst = l_lehrer.l_id
where p_s_kandidat is null
order by l_gs_geschlecht desc, Lehrername;

# B08 In welchen Räumen haben keine 3. Klassen Unterricht?  
# Ausgabe: Raum-ID und Plätze, sortiert nach den Plätzen absteigend  

select distinct r_id, r_plaetze
from r_raume left join st_stunden
on r_raume.r_id = st_stunden.st_r_raum
where st_k_klasse not like '3%'
order by r_plaetze desc;