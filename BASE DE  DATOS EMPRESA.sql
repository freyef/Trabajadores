create database EMPRESA

CREATE TABLE Trabajadores (
    ID INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    SueldoBruto DECIMAL(10, 2),
    Categoria CHAR(1) CHECK (Categoria IN ('A', 'B', 'C'))
);
INSERT INTO Trabajadores (Nombre, Apellidos, SueldoBruto, Categoria)
VALUES ('Juan', 'Pérez', 2500.00, 'B');
