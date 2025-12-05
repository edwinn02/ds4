CREATE DATABASE Parcial3DB;
GO
USE Parcial3DB;
GO

CREATE TABLE Solicitante (
    SolicitanteId INT IDENTITY(1,1) PRIMARY KEY,
    TipoDocumento VARCHAR(20),
    NumeroDocumento VARCHAR(20),
    Nombres VARCHAR(100),
    Apellidos VARCHAR(100),
    FechaNacimiento DATE,
    Nacionalidad VARCHAR(50),
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Correo VARCHAR(100)
);

CREATE TABLE EstadoSolicitud (
    EstadoSolicitudId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50)
);

CREATE TABLE SolicitudPasaporte (
    SolicitudId INT IDENTITY(1,1) PRIMARY KEY,
    SolicitanteId INT FOREIGN KEY REFERENCES Solicitante(SolicitanteId),
    FechaSolicitud DATETIME,
    TipoSolicitud VARCHAR(20),
    EstadoSolicitudId INT FOREIGN KEY REFERENCES EstadoSolicitud(EstadoSolicitudId),
    Observaciones VARCHAR(500)
);

