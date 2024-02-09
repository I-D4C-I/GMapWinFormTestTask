CREATE DATABASE MapDatabase;

USE MapDatabase;

CREATE TABLE Markers (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Latitude FLOAT NOT NULL,
    Longitude FLOAT NOT NULL
);

USE MapDatabase;

DECLARE @i INT = 0;
WHILE @i < 10
BEGIN
    DECLARE @lat FLOAT, @lng FLOAT;
    SET @lat = RAND() * (53.3931892 - (53.3161952)) + (53.3161952);
    SET @lng = RAND() * (83.6541938 - (83.8227464)) + (83.8227464);

    INSERT INTO Markers (Latitude, Longitude)
    VALUES (@lat, @lng);

    SET @i = @i + 1;
END