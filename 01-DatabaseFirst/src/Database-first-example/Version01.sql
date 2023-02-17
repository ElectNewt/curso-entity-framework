CREATE DATABASE IF NOT EXISTS `cursoEF`;
USE `cursoEF`;



CREATE TABLE IF NOT EXISTS `userid` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) NOT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserName` (`UserName`)
);


CREATE TABLE IF NOT EXISTS `wokringexperience` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `Name` varchar(150) NOT NULL,
  `Details` varchar(5000) NOT NULL,
  `Environment` varchar(500) NOT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`UserId`) REFERENCES `userid`(`UserId`)
);
