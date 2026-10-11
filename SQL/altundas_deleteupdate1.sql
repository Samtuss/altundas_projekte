# ALTUNDAS Samet Delete Update Übungen der Folie
#02.04.2026

#1 Füge die Klasse 3DHIF der DB hinzu
insert into k_klassen (k_id, k_bez)
values ('3DHIF', '3. Jahrgang Informatik');

#2 Füge mind. 5 SchülerInnen der Klasse 3DHIF hinzu

insert into s_schueler (s_nr, s_name, s_vorname, s_gs_geschlecht, s_k_klasse)
values 
(230607, 'dasisteinnachname', 'dasisteinvorname', 2, '3DHIF'),
(236700, 'hnmmmmmmm', 'hmmmmmmvorname', 2, '3DHIF'),
(236767, 'kabrd', 'kabrdvorname', 1, '3DHIF'),
(237676, 'eduardradumatej', 'eduardradumatejvorname', 2, '3DHIF'),
(237060, 'altundasssssss', 'samtusss', 1, '3DHIF');

#3 Füge einen Lehrer hinzu, der als Klassenvorstand für die Klasse 3 DHIF eingetragen wird

insert into l_lehrer (l_id, l_name, l_vorname, l_gs_geschlecht)
values
('ABCD', 'Bankuti2', 'Judit2', 2);

update k_klassen
set k_l_klavst = 'ABCD'
where k_id = '3DHIF';

#4 Ändere dein eigenes Geburtsdatum und diene eigene Adresse

update s_schueler
set s_gebdat = '01-01-2100' and s_strasse = 'blablablablabla 6/7' and s_plz = 6767676 and s_ort = 'Tokio'
where s_nr = '32';

#5 Ändere den Klassensprecher der Klaasse 3DHIF

update k_klassen
set k_s_klaspr = 32
where k_id = '3DHIF';

#6 Lösche den Klassesprecher aus der Schüler-Tabelle

delete from s_schueler
where s_nr = 32;

#7 Lösche die Klasse 3DHIF aus der DB

delete from s_schueler
where s_k_klasse = '3DHIF';

delete from k_klassen
where k_id = '3DHIF';