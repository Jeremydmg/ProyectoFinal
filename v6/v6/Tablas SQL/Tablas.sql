-- Crear la tabla Votantes
CREATE TABLE Votantes (
    ID INT PRIMARY KEY IDENTITY(1,1),          -- Clave primaria con incremento automático
    Nombre NVARCHAR(50) NOT NULL,              -- Nombre del votante, no puede ser nulo
    Apellido NVARCHAR(50) NOT NULL,            -- Apellido del votante, no puede ser nulo
    FechaRegistro DATE NOT NULL DEFAULT GETDATE() -- Fecha de registro, por defecto la fecha actual
);

-- Crear la tabla Candidatos
CREATE TABLE Candidatos (
    ID INT PRIMARY KEY IDENTITY(1,1),          -- Clave primaria con incremento automático
    Nombre NVARCHAR(50) NOT NULL,              -- Nombre del candidato, no puede ser nulo
    Apellido NVARCHAR(50) NOT NULL,            -- Apellido del candidato, no puede ser nulo
    Partido NVARCHAR(50),                      -- Partido político del candidato
    FechaRegistro DATE NOT NULL DEFAULT GETDATE(), -- Fecha de registro, por defecto la fecha actual
    CONSTRAINT UQ_Candidatos_NombreApellido UNIQUE (Nombre, Apellido) -- Restricción única para combinar nombre y apellido
);

-- Crear la tabla Votos
CREATE TABLE Votos (
    ID INT PRIMARY KEY IDENTITY(1,1),          -- Clave primaria con incremento automático
    ID_Candidato INT NOT NULL,                 -- Clave foránea para el candidato
    ID_Votante INT NOT NULL,                   -- Clave foránea para el votante
    FechaVoto DATE NOT NULL DEFAULT GETDATE(), -- Fecha del voto, por defecto la fecha actual
    CONSTRAINT FK_Votos_Candidatos FOREIGN KEY (ID_Candidato) REFERENCES Candidatos(ID), -- Restricción de clave foránea para candidatos
    CONSTRAINT FK_Votos_Votantes FOREIGN KEY (ID_Votante) REFERENCES Votantes(ID) -- Restricción de clave foránea para votantes
);

-- Crear la tabla Resultados
CREATE TABLE Resultados (
    ID INT PRIMARY KEY IDENTITY(1,1),          -- Clave primaria con incremento automático
    ID_Candidato INT NOT NULL,                 -- Clave foránea para el candidato
    CantidadVotos INT NOT NULL DEFAULT 0,      -- Cantidad de votos, por defecto 0
    CONSTRAINT FK_Resultados_Candidatos FOREIGN KEY (ID_Candidato) REFERENCES Candidatos(ID), -- Restricción de clave foránea para candidatos
    CONSTRAINT CHK_CantidadVotos CHECK (CantidadVotos >= 0) -- Restricción para asegurarse de que la cantidad de votos sea positiva
);
