use schuldb_don2025;

select l_vorname, l_nachname, l_id 
from l_lehrer
where l_sprechstunde = 'Montag';

select l_vorname, l_nachname, l_id
from l_lehrer
where l_sprechstunde is null;

select k_bez, k_l_klavst
from k_klassen
where k_a_abteilung = 3;

select k_id
from k_klassen
where k_id like 'F__';

select k_bez
from k_klassen
where k_l_klavst like 'LADI';

select s_name, s_vorname
from s_schueler
where s_gs_geschlect = 2;

select s_name, s_vorname, s_k_klasse
from s_schueler
where s_k_klasse like '%ET'
order by s_k_klasse;

select s_name, s_vorname, s_k_klasse
from s_schueler
where s_vorname like 'Benjamin' and s_k_klasse like 'IF';
