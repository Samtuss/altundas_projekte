insert into s_schueler (s_nr, s_name, s_vorname, s_gebdat, s_k_klasse, s_plz, s_ort, s_strasse, s_gs_geschlecht) values (1999, 'Alterschüler', 'Hugo', '1970-08-02', '4AHET', 1230, 'Wien', 'Traisenstr. 58/2', 1);
update l_lehrer set l_gebdat='1985-04-30' where l_id='POSH';

# 1
select l_name, l_vorname, l_gebdat
from l_lehrer
where l_gebdat = (select min(l_gebdat) from l_lehrer);

# 2
select a_abtname, l_name, l_vorname, min(l_gebdat) as aeltester_lehrer
from l_lehrer
inner join a_abteilungen a on l_a_abteilung = a_id
group by a_abtname;

#3
select concat(s_name, " ", s_vorname) as Schuelername, concat(l_name, " ", l_vorname) as KVname
from s_schueler
inner join k_klassen on s_nr = k_s_klaspr or s_nr = k_s_klasprstv
inner join l_lehrer on l_id = k_l_klavst;

# 4
select s_name, s_vorname, s_gebdat
from s_schueler
where s_gebdat < (select max(l_gebdat) from l_lehrer);

# 5
select min(l_gehalt) as ZweitniedrigstesGehalt
from l_lehrer
where l_gehalt > (select min(l_gehalt) from l_lehrer);

# 6
select g_bez
from g_gegenstaende
where g_id not in
(select st_g_fach from st_stunden where st_k_klasse = '3AHIF' and st_stunde like 'DO%');

# 7
select distinct g_bez, r_id
from st_stunden
inner join g_gegenstaende on g_id = st_g_fach
inner join r_raume on r_id = st_r_raum
where st_r_raum not like 'D%' and st_r_raum not like 'V%';

# 8
select distinct l_lehrer.l_name, l_lehrer.l_vorname, l_lehrer.l_gehalt
from st_stunden
inner join l_lehrer on l_lehrer.l_id = st_stunden.st_l_lehrer
where st_stunden.st_k_klasse = '3AHIF' and l_lehrer.l_gehalt <
(select avg(l2.l_gehalt) from st_stunden st2
inner join l_lehrer l2 on l2.l_id = st2.st_l_lehrer
where st2.st_k_klasse <> '3AHIF' and st2.st_k_klasse like '3%HIF');

# 9
select g_bez
from g_gegenstaende
where g_id not in (select p_g_fach from p_pruefungen where month(p_datum) = 1);

# 10
select l_id, concat(l_name, " ", l_vorname) as Lehrername, l_gehalt, l_a_abteilung, l_gebdat
from l_lehrer
where l_a_abteilung = (select l_a_abteilung from l_lehrer where l_id = 'REIT')
and l_gehalt < (select l_gehalt from l_lehrer where l_id = 'REIT');

# 11
select l_name, l_gehalt, (select avg(l_gehalt) from l_lehrer) as Durchschnittsgehalt
from l_lehrer
where l_gehalt > (select avg(l_gehalt) from l_lehrer);

# 12
select r_id
from r_raume where r_id not in
(select st_r_raum from st_stunden where st_stunde like 'DO%');

# 13
select k_id
from k_klassen
where k_id =
(select s_k_klasse from s_schueler group by s_k_klasse order by count(*) desc limit 1);

# 14
select s_vorname, s_name, s_gebdat, l_vorname, l_name, l_gebdat, k_id
from k_klassen
inner join l_lehrer on l_id = k_l_klavst
inner join s_schueler on s_gebdat = (select min(s_gebdat) from s_schueler)
where l_gebdat > (select min(s_gebdat) from s_schueler);

