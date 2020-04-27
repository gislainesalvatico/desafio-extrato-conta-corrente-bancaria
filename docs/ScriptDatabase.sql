CREATE DATABASE ccb;

CREATE TABLE ccb.Extrato (
  Id int NOT NULL AUTO_INCREMENT,
  Data datetime NOT NULL,
  Historico varchar(100) NOT NULL,
  Valor decimal(18,2) NOT NULL,
  Tipo int NOT NULL,
  PRIMARY KEY (Id)
  );