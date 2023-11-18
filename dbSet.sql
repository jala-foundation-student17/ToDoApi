create schema ToDoApi;
use ToDoApi;
CREATE TABLE `categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(100) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
);

CREATE TABLE `assignments` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DueDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `IdCategory` int(11) NOT NULL,
  `AssignmentStatus` int(11) NOT NULL,
  `Description` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Completed` bit(1) NOT NULL,
  `Active` bit(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `assignments_categories_idx` (`IdCategory`),
  CONSTRAINT `assignments_categories` FOREIGN KEY (`IdCategory`) REFERENCES `categories` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
);
