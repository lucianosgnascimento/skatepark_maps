-- MySQL Script generated by MySQL Workbench
-- Sun Sep 12 11:05:02 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering


-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
--CREATE database BasePistas ;
USE BasePistas ;

-- -----------------------------------------------------
-- Table Status_aprovacao
-- -----------------------------------------------------
CREATE TABLE Status_aprovacao (
  id_status_aprovacao INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  ds_status_aprovacao VARCHAR(45) NOT NULL)
;


-- -----------------------------------------------------
-- Table Tamanhos
-- -----------------------------------------------------
CREATE TABLE Tamanhos (
  id_Tamanho INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  ds_tamanho VARCHAR(45) NULL)
;


-- -----------------------------------------------------
-- Table Estado
-- -----------------------------------------------------
CREATE TABLE Estado (
  id_estado INT NOT NULL,
  nm_estado VARCHAR(75) NULL,
  uf varchar(5) NULL,
  PRIMARY KEY (id_estado))
;


-- -----------------------------------------------------
-- Table Cidade
-- -----------------------------------------------------
CREATE TABLE Cidade (
  id_cidade INT NOT NULL,
  nm_cidade VARCHAR(100) NULL,
  id_estado INT NOT NULL,
  PRIMARY KEY (id_cidade),
  CONSTRAINT fk_Cidade_Estado1
    FOREIGN KEY (id_estado)
    REFERENCES Estado (id_estado)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;


-- -----------------------------------------------------
-- Table Endereço
-- -----------------------------------------------------
CREATE TABLE Endereco (
  id_endereco INT IDENTITY(1,1) PRIMARY KEY,
  ds_endereco VARCHAR(45) NULL,
  nr_endereco int NULL,
  cd_cep VARCHAR(45) NULL,
  nr_latitude DECIMAL(18) NULL,
  nr_longitude DECIMAL(18) NULL,
  id_cidade INT NOT NULL,
    FOREIGN KEY (id_cidade)
    REFERENCES Cidade (id_cidade)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

--ALTER TABLE Endereco ALTER COLUMN  nr_latitude float NULL;
--ALTER TABLE Endereco ALTER COLUMN  nr_longitude float  NULL;
--ALTER TABLE Endereco ALTER COLUMN ds_endereco VARCHAR(256) NULL;

--exec sp_rename 'Endereço', 'Endereco'
-- -----------------------------------------------------
-- Table Pistas
-- -----------------------------------------------------
CREATE TABLE Pistas (
  id_pista INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  nm_pista VARCHAR(100) NOT NULL,
  ds_pista VARCHAR(500) NULL,
  fl_paga INT NULL,
  ds_horario_funcionamento VARCHAR(45) NULL,
  fl_pista_ativa INT NULL,
  fl_capacete INT NULL,
  fl_aluga_capacete INT NULL,
  id_status_aprovacao INT NOT NULL,
  nr_nota INT NULL,
  id_tamanho INT NOT NULL,
  ds_notas_gerais VARCHAR(100) NULL,
  id_endereco INT NOT NULL,
  CONSTRAINT fk_Pistas_Status_aprovacao1
    FOREIGN KEY (id_status_aprovacao)
    REFERENCES Status_aprovacao (id_status_aprovacao)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Pistas_Tamanhos1
    FOREIGN KEY (id_tamanho)
    REFERENCES Tamanhos (id_Tamanho)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Pistas_Endereço1
    FOREIGN KEY (id_endereco)
    REFERENCES Endereço (id_endereco)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
--ALTER TABLE Pistas
--alter column id_usuario_envio int null;
--ALTER TABLE Pistas
--ADD FOREIGN KEY (id_usuario_envio) REFERENCES Usuario_envio(id_usuario_envio);

ALTER TABLE Pistas
ADD fl_cobertura int null;


--ALTER TABLE Pistas
--ALTER COLUMN ds_pista VARCHAR(700) NULL
--ALTER TABLE Pistas
---ALTER COLUMN  fl_capacete INT NULL
--ALTER TABLE Pistas
--ALTER COLUMN  fl_aluga_capacete INT NULL

--ALTER TABLE Pistas
--ALTER COLUMN  ds_notas_gerais  VARCHAR(600) NULL
--ALTER TABLE Pistas
--ALTER COLUMN  ds_horario_funcionamento  VARCHAR(128) NULL

--select * from pistas
--sp_rename 'Pistas.ds_descricao_pista', 'ds_pista', 'COLUMN';
-- -----------------------------------------------------
-- Table Professores
-- -----------------------------------------------------
CREATE TABLE Professores (
  id_professor INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  nm_professor VARCHAR(45) NULL,
  cd_cpf VARCHAR(45) NULL,
  ds_telefone VARCHAR(12) NOT NULL,
  ds_email VARCHAR(45) NULL,
  ds_instagram VARCHAR(45) NULL,
  nr_estrelas FLOAT NULL,
  nr_anos_experiencia INT NULL,
  nm_apelido VARCHAR(45) NULL,
  vl_hora_aula FLOAT NULL)
;
ALTER TABLE Professores
ADD fl_ativo int;
ALTER TABLE Professores
ADD id_status_aprovacao int;

ALTER TABLE Professores
ADD FOREIGN KEY (id_status_aprovacao) REFERENCES Status_aprovacao(id_status_aprovacao);

update Professores set fl_ativo = 1 where id_professor = 1
ALTER TABLE Professores ALTER COLUMN id_status_aprovacao int NOT NULL;
ALTER TABLE Professores ALTER COLUMN cd_cpf VARCHAR(45) NOT NULL;

ALTER TABLE Professores add nm_profile VARCHAR(50) NULL;
ALTER TABLE Professores alter column nm_profile VARCHAR(50) not NULL;
update Professores set nm_profile = 'eu.jpg' where id_professor = 1

ALTER TABLE Professores ALTER COLUMN nm_profile VARCHAR(256) NULL;



-- -----------------------------------------------------
-- Table Pistas_Professores
-- -----------------------------------------------------
CREATE TABLE Pistas_Professores (
  id_pista_professor INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  id_pista INT NOT NULL,
  id_professor INT NOT NULL,
  CONSTRAINT fk_Pistas_has_Professores_Pistas
    FOREIGN KEY (id_pista)
    REFERENCES Pistas (id_pista)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Pistas_has_Professores_Professores1
    FOREIGN KEY (id_professor)
    REFERENCES Professores (id_professor)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

--drop table Pistas_Professores
-- -----------------------------------------------------
-- Table Modalidades
-- -----------------------------------------------------
CREATE TABLE Modalidades (
  id_modalidade INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  nm_modalidade VARCHAR(45) NULL,
  ds_modalidade VARCHAR(200) NULL)
;



-- -----------------------------------------------------
-- Table Modalidades_Pistas
-- -----------------------------------------------------
CREATE TABLE Modalidades_Pistas (
  id_modalidade_pista INT not null IDENTITY(1,1) PRIMARY KEY,
  id_modalidade INT NOT NULL,
  id_pista INT NOT NULL,
  CONSTRAINT fk_Modalidades_has_Pistas_Modalidades1
    FOREIGN KEY (id_modalidade)
    REFERENCES Modalidades (id_modalidade)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Modalidades_has_Pistas_Pistas1
    FOREIGN KEY (id_pista)
    REFERENCES Pistas (id_pista)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

--drop table Modalidades_Pistas

-- -----------------------------------------------------
-- Table Niveis_dificuldade
-- -----------------------------------------------------
CREATE TABLE Niveis_dificuldade (
  id_nivel_dificuldade INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  nm_nivel_dificuldade VARCHAR(45) NULL,
  ds_nivel_dificuldade VARCHAR(200) NULL)
;


-- -----------------------------------------------------
-- Table Niveis_dificuldade_Pistas
-- -----------------------------------------------------
CREATE TABLE Niveis_dificuldade_Pistas (
  id_nivel_dificuldade_pista INT not null IDENTITY(1,1) PRIMARY KEY,
  id_nivel_dificuldade INT NOT NULL,
  id_pista INT NOT NULL,
  CONSTRAINT fk_Niveis_dificuldade_has_Pistas_Niveis_dificuldade1
    FOREIGN KEY (id_nivel_dificuldade)
    REFERENCES Niveis_dificuldade (id_nivel_dificuldade)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Niveis_dificuldade_has_Pistas_Pistas1
    FOREIGN KEY (id_pista)
    REFERENCES Pistas (id_pista)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;


-- -----------------------------------------------------
-- Table Fotos
-- -----------------------------------------------------
CREATE TABLE Fotos (
  id_foto INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  nm_foto VARCHAR(256) NULL,
  id_pista INT NOT NULL,
  CONSTRAINT fk_Fotos_Pistas1
    FOREIGN KEY (id_pista)
    REFERENCES Pistas (id_pista)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;
--ALTER TABLE Fotos ALTER COLUMN nm_foto VARCHAR(256) NULL;
--drop Table Fotos
-- -----------------------------------------------------
-- Table Usuario
-- -----------------------------------------------------
CREATE TABLE Usuario
(
	IdUsuario INT IDENTITY(1, 1) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(150) NULL,
	Login VARCHAR(50) NOT NULL,
	Senha VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario)
);
ALTER TABLE Usuario DROP COLUMN Senha
ALTER TABLE usuario ADD Hash VARCHAR(256)
ALTER TABLE usuario ADD Salt VARCHAR(256)
UPDATE Usuario SET Hash = 'NLAZBttBU8HbUrODUPQxViEDr1d7RMi4B/2F6yaKOrQ=', Salt = 'Nkt8krN4/TBHUJXu4zEm6A==' 
WHERE Login = 'admin'

--ALTER TABLE Pistas
--ALTER COLUMN nr_endereco int NULL;

--select * from pistas

CREATE TABLE Usuario_envio (
  id_usuario_envio INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  nm_usuario_envio VARCHAR(256) NULL,
  nr_telefone varchar(32) NULL,
  ds_email varchar(64) NULL
  );