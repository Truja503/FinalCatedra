use master
go

CREATE DATABASE Consesionaria
go

Use Consesionaria
go


CREATE TABLE Usuario(
IdUser int PRIMARY KEY Identity(1,1), 
Nombre varchar(100) NOT NULL,
Apellido varchar(100) NOT NULL,
Correo varchar(200) NOT NULL,
telefono varchar(20),
Contrase�a varchar(200), 
Pais varchar(50), 
Ciudad varchar(70),
)
go

CREATE TABLE PuestoTrabajo(
CodigoPuestoTrabajo int Primary KEY identity(1,1), 
NombrePuesto varchar(10)
)
go

CREATE TABLE Administrador(
IdAdmin int PRIMARY KEY identity (1,1), 
Nombre varchar(100),
Apellido varchar(100),
Correo varchar(200),
Contrase�a varchar(100),
IdPuestoTrabajo int, 
FOREIGN KEY (IdPuestoTrabajo) REFERENCES PuestoTrabajo(CodigoPuestoTrabajo)
)
go

CREATE TABLE MarcaVehiculo(
IdMarca int PRIMARY KEY identity (1,1), 
NombreMarca varchar(100),
)
go

CREATE TABLE Vehiculo(
IdVehiculo int PRIMARY KEY identity(1,1), 
NombreVehiculo varchar(100),
IdMarca int,
A�o int, 
Precio float,
Cantidad int, 
Motor float,
Modelo varchar(30),
Descripcion text, 
Transmision varchar(30),
Imagen image, 
FOREIGN KEY (IdMarca) REFERENCES MarcaVehiculo(IdMarca)
)
go

CREATE TABLE Facturas(
IdFactura int PRIMARY KEY identity (1,1),
FechaFactura date,
IdCliente int, 
IdVehiculo int, 
Cantidad int, 
Precio float,
FOREIGN KEY (IdCliente) REFERENCES Usuario(IdUser),
FOREIGN KEY (IdVehiculo) REFERENCES Vehiculo(IdVehiculo), 
)
go


USE Consesionaria;
GO

-- Inserciones en la tabla PuestoTrabajo
INSERT INTO PuestoTrabajo (NombrePuesto) VALUES
('Gerente'),
('Vendedor'),
('Mec�nico'),
('Recepcion'),
('Supervisor'),
('Contador'),
('Asistente');
go
-- Inserciones en la tabla Administrador
INSERT INTO Administrador (Nombre, Apellido, Correo, Contrase�a, IdPuestoTrabajo) VALUES
('Juan', 'P�rez', 'juan.perez@empresa.com', 'password123', 1),
('Ana', 'G�mez', 'ana.gomez@empresa.com', 'securepass456', 2),
('Luis', 'Ram�rez', 'luis.ramirez@empresa.com', 'mypassword789', 3),
('Claudia', 'Fern�ndez', 'claudia.fernandez@empresa.com', 'claudia2024', 4),
('Mario', 'Torres', 'mario.torres@empresa.com', 'mariopass', 5);
go

-- Inserciones en la tabla MarcaVehiculo
INSERT INTO MarcaVehiculo (NombreMarca) VALUES
('Toyota'),
('Ford'),
('Honda'),
('Chevrolet'),
('Nissan'),
('BMW'),
('Mercedes-Benz'),
('Audi'),
('Kia'),
('Hyundai');
go

-- Inserciones en la tabla Vehiculo
INSERT INTO Vehiculo (NombreVehiculo, IdMarca, A�o, Precio, Cantidad, Motor, Modelo, Descripcion, Transmision, Imagen) VALUES
('Corolla', 1, 2020, 20000.00, 10, 1.8, 'SE', 'Compacto y econ�mico', 'Autom�tico', NULL),
('Mustang', 2, 2022, 35000.00, 5, 5.0, 'GT', 'Deportivo y potente', 'Manual', NULL),
('Civic', 3, 2021, 22000.00, 8, 2.0, 'EX', 'Sed�n c�modo', 'Autom�tico', NULL),
('Silverado', 4, 2019, 40000.00, 6, 6.2, 'LT', 'Camioneta robusta', 'Autom�tico', NULL),
('Altima', 5, 2021, 25000.00, 7, 2.5, 'SV', 'Sed�n con estilo', 'Autom�tico', NULL);
go

-- Inserciones en la tabla Usuario
INSERT INTO Usuario (Nombre, Apellido, Correo, telefono, Contrase�a, Pais, Ciudad) VALUES
('Carlos', 'L�pez', 'carlos.lopez@correo.com', '123456789', 'carlospass', 'M�xico', 'Ciudad de M�xico'),
('Mar�a', 'Rodr�guez', 'maria.rodriguez@correo.com', '987654321', 'mariar2024', 'Argentina', 'Buenos Aires'),
('Pedro', 'Gonz�lez', 'pedro.gonzalez@correo.com', NULL, 'pedrog123', 'Espa�a', 'Madrid'),
('Laura', 'Mart�nez', 'laura.martinez@correo.com', '234567890', 'lauramart', 'Chile', 'Santiago'),
('Andr�s', 'Hern�ndez', 'andres.hernandez@correo.com', NULL, 'andresh2023', 'Colombia', 'Bogot�');
go

-- Inserciones en la tabla Facturas
INSERT INTO Facturas (FechaFactura, IdCliente, IdVehiculo, Cantidad, Precio) VALUES
('2024-01-15', 1, 1, 1, 20000.00),
('2024-02-20', 2, 3, 2, 44000.00),
('2024-03-10', 3, 5, 1, 25000.00),
('2024-04-25', 4, 2, 1, 35000.00),
('2024-05-05', 5, 4, 3, 120000.00);
go


CREATE VIEW VerFacturaCompleta
AS 
SELECT IdFactura,FechaFactura, U.Nombre, U.Apellido, U.Pais, V.NombreVehiculo, V.Modelo, M.NombreMarca, F.Cantidad, F.Precio FROM Facturas F
INNER JOIN Usuario U ON IdCliente = U.IdUser
INNER JOIN Vehiculo V ON F.IdVehiculo = V.IdVehiculo 
INNER JOIN MarcaVehiculo M ON V.IdMarca = M.IdMarca


CREATE PROCEDURE AgregarVehiculo
    @NombreVehiculo VARCHAR(100),
    @IdMarca INT,
    @A�o INT,
    @Precio FLOAT,
    @Cantidad INT,
    @Motor FLOAT,
    @Modelo VARCHAR(30),
    @Descripcion TEXT,
    @Transmision VARCHAR(30),
    @Imagen VARBINARY(MAX)
AS
BEGIN
    INSERT INTO Vehiculo (NombreVehiculo, IdMarca, A�o, Precio, Cantidad, Motor, Modelo, Descripcion, Transmision, Imagen)
    VALUES (@NombreVehiculo, @IdMarca, @A�o, @Precio, @Cantidad, @Motor, @Modelo, @Descripcion, @Transmision, @Imagen);
END;

-- Procedimiento para actualizar un veh�culo existente
CREATE PROCEDURE EditarVehiculo
    @IdVehiculo INT,
    @NombreVehiculo VARCHAR(100),
    @IdMarca INT,
    @A�o INT,
    @Precio FLOAT,
    @Cantidad INT,
    @Motor FLOAT,
    @Modelo VARCHAR(30),
    @Descripcion TEXT,
    @Transmision VARCHAR(30),
    @Imagen VARBINARY(MAX)
AS
BEGIN
    UPDATE Vehiculo
    SET NombreVehiculo = @NombreVehiculo,
        IdMarca = @IdMarca,
        A�o = @A�o,
        Precio = @Precio,
        Cantidad = @Cantidad,
        Motor = @Motor,
        Modelo = @Modelo,
        Descripcion = @Descripcion,
        Transmision = @Transmision,
        Imagen = @Imagen
    WHERE IdVehiculo = @IdVehiculo;
END;

-- Procedimiento para eliminar un veh�culo
CREATE PROCEDURE EliminarVehiculo
    @IdVehiculo INT
AS
BEGIN
    DELETE FROM Vehiculo
    WHERE IdVehiculo = @IdVehiculo;
END;


--Tabla Marca Vehiculo

-- Procedimiento para agregar una nueva marca de veh�culo
CREATE PROCEDURE AgregarMarcaVehiculo
    @NombreMarca VARCHAR(100)
AS
BEGIN
    INSERT INTO MarcaVehiculo (NombreMarca)
    VALUES (@NombreMarca);
END;

-- Procedimiento para actualizar una marca de veh�culo existente
CREATE PROCEDURE EditarMarcaVehiculo
    @IdMarca INT,
    @NombreMarca VARCHAR(100)
AS
BEGIN
    UPDATE MarcaVehiculo
    SET NombreMarca = @NombreMarca
    WHERE IdMarca = @IdMarca;
END;

-- Procedimiento para eliminar una marca de veh�culo
CREATE PROCEDURE EliminarMarcaVehiculo
    @IdMarca INT
AS
BEGIN
    DELETE FROM MarcaVehiculo
    WHERE IdMarca = @IdMarca;
END;


--Tabla Usuario

use Consesionaria
-- Procedimiento para agregar un nuevo usuario
CREATE PROCEDURE AgregarUsuario
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Correo VARCHAR(200),
    @Telefono VARCHAR(20),
    @Contrase�a VARCHAR(100),
    @Pais VARCHAR(50),
    @Ciudad VARCHAR(70)
AS
BEGIN
    INSERT INTO Usuario (Nombre, Apellido, Correo, Telefono, Contrase�a, Pais, Ciudad)
    VALUES (@Nombre, @Apellido, @Correo, @Telefono, @Contrase�a, @Pais, @Ciudad);
END;

-- Procedimiento para actualizar un usuario existente
CREATE PROCEDURE EditarUsuario
    @IdUser INT,
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Correo VARCHAR(200),
    @Telefono VARCHAR(20),
    @Contrase�a VARCHAR(100),
    @Pais VARCHAR(50),
    @Ciudad VARCHAR(70)
AS
BEGIN
    UPDATE Usuario
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Correo = @Correo,
        Telefono = @Telefono,
        Contrase�a = @Contrase�a,
        Pais = @Pais,
        Ciudad = @Ciudad
    WHERE IdUser = @IdUser;
END;

-- Procedimiento para eliminar un usuario
CREATE PROCEDURE EliminarUsuario
    @IdUser INT
AS
BEGIN
    DELETE FROM Usuario
    WHERE IdUser = @IdUser;
END;


--Tabla Administrador

-- Procedimiento para agregar un nuevo administrador
CREATE PROCEDURE AgregarAdministrador
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Correo VARCHAR(200),
    @Contrase�a VARCHAR(100),
    @IdPuestoTrabajo INT
AS
BEGIN
    INSERT INTO Administrador (Nombre, Apellido, Correo, Contrase�a, IdPuestoTrabajo)
    VALUES (@Nombre, @Apellido, @Correo, @Contrase�a, @IdPuestoTrabajo);
END;

-- Procedimiento para actualizar un administrador existente
CREATE PROCEDURE EditarAdministrador
    @IdAdmin INT,
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Correo VARCHAR(200),
    @Contrase�a VARCHAR(100),
    @IdPuestoTrabajo INT
AS
BEGIN
    UPDATE Administrador
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Correo = @Correo,
        Contrase�a = @Contrase�a,
        IdPuestoTrabajo = @IdPuestoTrabajo
    WHERE IdAdmin = @IdAdmin;
END;

-- Procedimiento para eliminar un administrador
CREATE PROCEDURE EliminarAdministrador
    @IdAdmin INT
AS
BEGIN
    DELETE FROM Administrador
    WHERE IdAdmin = @IdAdmin;
END;

