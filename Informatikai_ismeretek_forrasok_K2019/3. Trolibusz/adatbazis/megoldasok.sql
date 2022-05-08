-- A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!


-- 10. feladat:

create schema halozat collate utf8mb4_hungarian_ci;

-- 12. feladat:

insert into megallok(id, nev)
values (198, 'Kőbányai garáz');

update megallok set nev = 'Kőbányai garázs' where id = 198;

-- 13. feladat:

update jaratok set elsoAjtos = false where id = 20;

-- 14. feladat:

select jaratSzam from jaratok
where elsoAjtos;

-- 15. feladat:

select nev from megallok
where nev like '%sétány'
order by nev;

-- 16. feladat:

select h.sorszam, m.nev from halozat h
inner join jaratok j on h.jarat = j.id
inner join megallok m on h.megallo = m.id
where jaratSzam = 'CITY' and h.irany = 'A'
order by h.sorszam;

-- 17. feladat:

select m.nev as megallo, COUNT(h.jarat) as jaratokSzama from halozat h
inner join megallok m on h.megallo = m.id
group by megallo
having jaratokSzama >= 3;

select m.nev as megallo, COUNT(h.jarat) as jaratokSzama from megallok m
inner join halozat h on m.id = h.megallo
    inner join jaratok j on h.jarat = j.id
group by megallo
having jaratokSzama >= 3

