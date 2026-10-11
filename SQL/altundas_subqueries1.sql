select * from schuldb_2526.l_lehrer;

update l_lehrer set l_gebdat = '1978-04-30' where l_id='POSH';

select l_id, l_name, l_vorname, max(l_gebdat)
from l_lehrer;

select l_id, l_name, l_vorname, l_gebdat
from l_lehrer
where l_id='ANGE';

select max(l_gebdat) 
from l_lehrer;

select l_id, l_name, l_vorname
from l_lehrer
where l_gebdat = '1978-04-30';

select l_id, l_name, l_vorname, l_gebdat
from l_lehrer
where l_gebdat = (select max(l_gebdat) from l_lehrer);

select s_nr, s_name, s_vorname, s_ort, s_plz
from s_schueler
where s_name = 'Clark';

select s_nr, s_name, s_vorname, s_ort, s_plz
from s_schueler
where s_ort = 
(select s_ort from s_schueler where s_name='Milascon') and
s_plz = (select s_plz from s_schueler where s_name = 'Clark');

select l_id, concat(l_name, " ", l_vorname) as Lehrername, l_gehalt
from l_lehrer
where l_gehalt < (select l_gehalt from l_lehrer where l_id = 'HOEF');


