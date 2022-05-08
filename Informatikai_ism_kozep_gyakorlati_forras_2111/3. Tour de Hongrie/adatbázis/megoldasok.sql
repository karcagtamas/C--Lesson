-- A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!

-- 9. feladat:
create schema tdhongrie collate utf8mb4_hungarian_ci;

-- 11. feladat:

delete from csapat where id = 21;

-- 12. feladat:

select nev from versenyzo
where nemzetiseg like 'HUN'
ORDER BY nev;


-- 13. feladat:

select nemzetiseg, COUNT(id) as indulokSzama from versenyzo
GROUP BY nemzetiseg
ORDER BY indulokSzama desc;


-- 14. feladat:

select e.szakasz, e.ido from eredmeny e
inner join versenyzo v on e.versenyzoId = v.id
where v.nev like 'Valter Attila'
order by e.szakasz;
 
-- 15. feladat:

select cs.csapatNev, COUNT(v.id) as magyarokSzama from csapat cs
inner join versenyzo v on cs.id = v.csapatId
where v.nemzetiseg = 'HUN'
group by cs.csapatNev
having magyarokSzama > 1;
