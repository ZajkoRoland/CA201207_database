--CREATE DATABASE music; 
--USE music;

CREATE TABLE Albums(
id VARCHAR(4) PRIMARY KEY, 
artist VARCHAR(255) NOT NULL, 
title VARCHAR(255) NOT NULL,
release date);

CREATE TABLE Tracks(
id INT PRIMARY KEY IDENTITY,
title VARCHAR(255) NOT NULL,
length time, 
album VARCHAR(4) FOREIGN KEY REFERENCES Albums(id), 
url VARCHAR(30));