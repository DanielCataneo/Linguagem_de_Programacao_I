USE AulaDB
GO

CREATE TABLE Alunos( 
 Id int NOT NULL PRIMARY KEY,
 nome varchar(50) NULL, 
 mensalidade decimal (18, 2) NULL, 
 cidadeId int NULL, 
 DataNascimento datetime NULL 
)

insert into Alunos values (1,'Daniel',500.00,1,'2007-01-21')

delete Alunos where id = 1 

SELECT * FROM Alunos

UPDATE Alunos
SET nome = 'oi'
where id = 1

