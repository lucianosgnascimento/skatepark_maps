use BasePistas;

insert into Tamanhos Values('Pequena'),
('Média'),
('Grande')

insert into Modalidades Values('Bowl/Banks','Piscina com ou sem entradas mais leves, para mandar manobras da categoria Vertical como aereos e manobras deslizando nas bordas.'),
('Street','Manobras em obstáculos que são encontrados nas ruas como pequenas rampas, corrimãos, muretas, escadas e afins.'),
('HalfPipe','Pista com no mínimo 3,5 metros de altura em formato de U.'),
('Mini-Ramp','Similar Aos HalfPipes em formato de U porem de altura bem reduzida.'),
('DownHill/LongBoard','Descida de Ladeiras para LongBoard para conseguir velocidade ou mandar slides.'),
('Local Aberto Liso','Local Aberto idealpara o Treino de Manobras no chão liso como Solo e FreeStyle');

insert into Status_aprovacao Values('Validado'),
('Pendente'),
('Recusado');

insert into Niveis_dificuldade Values
('Facil','Pista com obstáculos para quem quer começar aprender, com obstáculos fáceis para treinar os básicos'),
('Média/Facil','Pista com obstáculos para quem já está em um nível saindo do básico com obstáculos um pouco mais desafiadores'),
('Média/Difícil','Pista com obstáculos para quem já tem uma noção maior de skate e já saiu do básico com obstáculos de tamanho medios, que necessitam de mais habilidades'),
('Dificil','Pista com obstáculos para quem está em um nível maior, com obstáculos altos que necessitam de habilidade e confiança.'),
('Pro','Nijah é você ? Pista alta para quem já é pró no skate.');

INSERT INTO Usuario (Nome, Login, Senha) VALUES ('Administrador', 'admin', '123456')

select * from Tamanhos;
select * from Modalidades;
select * from Status_aprovacao;
select * from Niveis_dificuldade;

--truncate table Niveis_dificuldade