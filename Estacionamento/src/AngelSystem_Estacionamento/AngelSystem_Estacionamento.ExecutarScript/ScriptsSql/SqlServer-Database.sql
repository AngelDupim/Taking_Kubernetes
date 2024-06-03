IF (NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Estacionamento'))
BEGIN
    CREATE DATABASE [Estacionamento];
END