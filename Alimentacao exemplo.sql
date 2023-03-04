use BasePistas;


--minimo pista

insert into Endereco Values
('R. Ipiranga',792,04630010,-23.6379,-46.6616,5270);

insert into Pistas Values
('chuvisco','A pista é boa e grande com varias alturas de obstaculos de vert e alguns para street ',0,'todo dia das 7 as 18',1,0,0,1,8,3,'',1,1,0);

insert into Niveis_dificuldade_Pistas Values
(2,1);

insert into Modalidades_Pistas Values
(1,1),
(2,1),
(4,1);

insert into Fotos Values
('meta.jpg',1);

update Fotos set nm_foto = 'meta.jpeg' where id_foto = 2

select * from Fotos
select * from Niveis_dificuldade_Pistas

--professores

insert into Professores Values
('Luciano Nascimento','42401201874','13974123900','lucianosgnascimento@gmail.com','@lucianoosouza',5,2,'Tio raposo',120,1,1,'raposo');

insert into Pistas_Professores Values
(1,1);

insert into Usuario_envio Values
('Luciano','13974123900','lucianosgnascimento@gmail.com');

select * from usuario_envio
update Pistas set fl_cobertura = 0
select * from Endereco
delete from Endereco where id_endereco = 10

Select * from Pistas





