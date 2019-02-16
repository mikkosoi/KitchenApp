-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: sql7.freesqldatabase.com    Database: sql7245392
-- ------------------------------------------------------
-- Server version	5.5.58-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `OSTOSLISTA`
--

DROP TABLE IF EXISTS `OSTOSLISTA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `OSTOSLISTA` (
  `Aine_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nimi` varchar(50) NOT NULL,
  `Maara` int(11) NOT NULL,
  `Yksikko` varchar(5) NOT NULL,
  PRIMARY KEY (`Aine_ID`),
  CONSTRAINT `aine` FOREIGN KEY (`Aine_ID`) REFERENCES `AINEET` (`Aine_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OSTOSLISTA`
--

LOCK TABLES `OSTOSLISTA` WRITE;
/*!40000 ALTER TABLE `OSTOSLISTA` DISABLE KEYS */;
INSERT INTO `OSTOSLISTA` VALUES (1,'Maito',2,'l'),(20,'Kahvi',1000,'g'),(21,'TESTMEAT',1,'kpl'),(22,'TESTMEAT',1,'kpl'),(23,'gtd',2,'kpl'),(24,'123e345',222,'kpl'),(25,'Kana',500,'g'),(26,'Sikanauta',500,'g');
/*!40000 ALTER TABLE `OSTOSLISTA` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-06 15:00:00