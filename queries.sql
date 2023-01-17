-- 1.6
--select * from [Philosophy_mod].[dbo].PhilosophersTab
-- 1.7
--select * from [Philosophy_mod].[dbo].PhilosophersTab
--inner join [Philosophy_mod].[dbo].PhyFlowTab on PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID

--select PhilosophersTab.ID,PhilosophersTab.FirstName,PhilosophersTab.MiddleName,PhilosophersTab.Surname,PhilosophersTab.PhyFlowID from [Philosophy_mod].[dbo].PhilosophersTab

--select PhilosophersTab.ID,PhilosophersTab.FirstName,PhilosophersTab.MiddleName,PhilosophersTab.Surname,PhilosophersTab.PhyFlowID,PhyFlowTab.Description
--from [Philosophy_mod].[dbo].PhilosophersTab
--where PhilosophersTab.PhyFlowID = 1
--INNER JOIN [Philosophy_mod].[dbo].PhyFlowTab ON PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID;

--select PhilosophersTab.ID,PhilosophersTab.FirstName,PhilosophersTab.MiddleName,PhilosophersTab.Surname,PhilosophersTab.PhyFlowID,PhyFlowTab.Description
--from [Philosophy_mod].[dbo].PhilosophersTab
--INNER JOIN [Philosophy_mod].[dbo].PhyFlowTab ON PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID;

--order by PhilosophersTab.ID

--select * from [Philosophy_mod].[dbo].PhilosophersTab where PhilosophersTab.PhyFlowID = 1
--inner join [Philosophy_mod].[dbo].PhyFlowTab on PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID

--SELECT
--    PhilosophersTab.*
--FROM [Philosophy_mod].[dbo].PhilosophersTab
--INNER JOIN (
--    SELECT
--        PhyFlowID,
--        COUNT(DISTINCT ID) AS cnt
--    FROM [Philosophy_mod].[dbo].PhilosophersTab
--    WHERE ID IN (2, 3)
--    GROUP BY PhyFlowID
--    HAVING COUNT(DISTINCT ID) = 2) AS b ON [Philosophy_mod].[dbo].PhilosophersTab.PhyFlowID = b.PhyFlowID
--WHERE [Philosophy_mod].[dbo].PhilosophersTab.ID IN (2, 3)



--inner join PhyFlowTab on PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID
--ID,FirstName,MiddleName,Surname,PhilosophersTab.PhyFlowID
-- /////PhilosophersTab.ID, PhilosophersTab.FirstName, PhilosophersTab.Surname, PhilosophersTab.PhyFlowID
-- 1.8
--select * from PhilosophersTab 
--inner join PhyFlowTab on PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID
--where PhilosophersTab.PhyFlowID = 2;
-- 1.9
--select * from PhilosophersTab PhyFlowTab
--inner join PhyFlowTab on PhyFlowTab.PhyFlowID = PhilosophersTab.PhyFlowID
--where PhilosophersTab.ID = 2;
-- 1.10
--insert into PhilosophersTab values('Coco','-','o3o3',1)
--select * from PhilosophersTab
-- 1.11
--insert into PhyFlowTab values('Coca-cola fan')
--select * from PhyFlowTab
-- 1.12
--begin tran
--update [Philosophy_mod].[dbo].PhilosophersTab set FirstName = '23626', MiddleName = '45734', Surname = '141425263', PhyFlowID = 1 where ID = 23
--commit tran;
--rollback tran;
--select * from [Philosophy_mod].[dbo].PhilosophersTab
--rollback; 
-- 1.13
--delete from PhilosophersTab where ID=17
--select * from PhilosophersTab
-- 1.14
--select * from PhyFlowTab
--if COL_LENGTH('PhyFlowTab','PhyFlowID') IS NOT NULL
--    print 'Column "PhyFlowID" Exists';
--else
--    print 'Column "PhyFlowID" does not Exists';
--	  ALTER TABLE PhyFlowTab
--	  ADD PhyFlowID int;
--if COL_LENGTH('PhyFlowTab','Description') IS NOT NULL
  --  print 'Column "Description" Exists';
--else 
    --print 'Column "Description" does not Exists';
	  --ALTER TABLE PhyFlowTab
	  --ADD Description nvarchar(MAX);
	  --insert into PhyFlowTab values(1, 'Materialist'), (2, 'Existentialist'), (3, 'Dualist'), (4, 'Hermeneutic'), (5, 'Idealist')

SET IDENTITY_INSERT [Philosophy_mod].[dbo].PhyFlowTab ON
if COL_LENGTH('PhyFlowTab','PhyFlowID') IS NULL
	  ALTER TABLE PhyFlowTab ADD PhyFlowID int NOT NULL IDENTITY(1, 1);
if COL_LENGTH('PhyFlowTab','Description') IS NULL
	  ALTER TABLE PhyFlowTab ADD Description nvarchar(MAX) 
	  insert into PhyFlowTab values(1, 'Materialist'), (2, 'Existentialist'), (3, 'Dualist'), (4, 'Hermeneutic'), (5, 'Idealist');
SET IDENTITY_INSERT tableA OFF
--select PhyFlowID from [Philosophy_mod].[dbo].PhyFlowTab where Description = 'Co.Inc'
