#ALTUNDAS Samet 
#create view v_schueleralter as
select s_nr, s_name, s_vorname, year(curdate()) - year(s_gebdat) AS alter_in_jahren, s_k_klasse
from s_schueler
where s_k_klasse like '3_HIF'
order by s_k_klasse, year(curdate()) - year(s_gebdat) desc;

select * from v_schueleralter;

# 8
# create view v_aufgabe8 as
select k_id, count(s_nr) as anzahl_schueler, s_vorname, s_name, concat(s_strasse, ', ', s_plz, ' ', s_ort) as adresse
from k_klassen
left join s_schueler on s_nr = k_s_klaspr
group by k_id, s_vorname, s_name, adresse;

select * from v_aufgabe8;

# 9
# create view v_aufgabe9 as
select s_nr, s_name, s_vorname, s_k_klasse, g_bez, p_note
from s_schueler
join p_pruefungen on s_nr = p_s_kandidat
join g_gegenstaende on g_id = p_g_fach;

select * from v_aufgabe9;

# 10
# create view v_aufgabe10 as
select st_k_klasse, g_bez, l_vorname,l_name, count(*) as anzahl_stunden
from st_stunden
join l_lehrer on l_id = st_l_lehrer
join g_gegenstaende on g_id = st_g_fach
group by st_k_klasse, g_bez, l_vorname, l_name;

select * from v_aufgabe10;

# 11
update v_aufgabe9
set p_note = 3
where p_note < 1;

# 12
delete from k_klassen
where k_id in (select k_id from v_aufgabe8 where s_name = 'Adler');