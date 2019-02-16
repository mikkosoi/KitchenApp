-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: mysql.labranet.jamk.fi    Database: L8316
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
-- Table structure for table `AINEET`
--

DROP TABLE IF EXISTS `AINEET`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AINEET` (
  `Aine_ID` int(11) NOT NULL AUTO_INCREMENT,
  `nimi` varchar(30) NOT NULL,
  `maara` float(5,1) NOT NULL,
  `mittayksikko` varchar(20) NOT NULL,
  `parastaennen` date DEFAULT NULL,
  PRIMARY KEY (`Aine_ID`),
  UNIQUE KEY `Aine_ID_UNIQUE` (`Aine_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AINEET`
--

LOCK TABLES `AINEET` WRITE;
/*!40000 ALTER TABLE `AINEET` DISABLE KEYS */;
INSERT INTO `AINEET` VALUES (1,'Maito',2.0,'l','2018-11-07'),(2,'Juusto',600.0,'g','2018-11-07'),(3,'Sitruuna',1.0,'kpl','2018-11-07'),(4,'Korianteri',100.0,'g','2018-11-07'),(5,'Majoneesi',250.0,'g','2018-11-07'),(6,'Sinappi',300.0,'g','2018-11-07'),(7,'Voi',500.0,'g','2018-11-07'),(8,'Kananmuna',15.0,'kpl','2018-11-07'),(10,'Sipuli',4.0,'kpl','2018-11-07'),(11,'Valkosipuli',5.0,'kpl','2018-11-07'),(12,'Kinkku',400.0,'g','2018-11-07'),(13,'Kerma',100.0,'ml','2018-11-07'),(14,'Porkkana',8.0,'kpl','2018-11-07'),(15,'Omenat',5.0,'kpl','2018-11-07'),(17,'Leipa',500.0,'g','2018-11-07'),(18,'Oliivioljy',300.0,'ml','2018-11-07'),(19,'Rypsioljy',250.0,'ml','2018-11-07'),(20,'Kahvi',1000.0,'g','2018-11-07'),(21,'Hunaja',400.0,'g','2018-11-07'),(22,'vehnajauho',2000.0,'g','2018-11-07'),(23,'Leivinjauhe',100.0,'g','2018-11-07'),(24,'Ruokasooda',100.0,'g','2018-11-07'),(25,'Suklaa',200.0,'g','2018-11-07'),(26,'Leivontakaakao',250.0,'g','2018-11-07'),(27,'Sokeri',500.0,'g','2018-11-07'),(28,'Fariinisokeri',400.0,'g','2018-11-07'),(29,'Tomusokeri',500.0,'g','2018-11-07'),(30,'Laakerinlehti',4.0,'g','2018-11-07'),(31,'Musta pippuri',220.0,'g','2018-11-07'),(32,'Suola',500.0,'g','2018-11-07'),(33,'Paprika',250.0,'g','2018-11-07'),(34,'Kaneli',400.0,'g','2018-11-07'),(35,'Mausteneilikka',50.0,'g','2018-11-07'),(36,'Perunajauho',500.0,'g','2018-11-07'),(37,'Kumina',22.0,'g','2018-11-07'),(38,'Muskottipahkina',23.0,'g','2018-11-07'),(39,'Rosmariini',40.0,'g','2018-11-07'),(40,'Vaniljasokeri',100.0,'g','2018-11-07'),(41,'Curry',97.0,'g','2018-11-07'),(42,'Oregano',50.0,'g','2018-11-07'),(44,'makaroni',500.0,'g','2019-07-03'),(47,'jauheliha',1100.0,'g','2018-07-10'),(48,'piima',1000.0,'ml','2018-07-10'),(55,'Naggei',12.0,'kpl','2018-07-04'),(56,'Sausage',3.0,'kpl','2018-07-14'),(58,'Kurkkua',5.0,'kpl','2018-07-07'),(59,'vihrea paprika',4.0,'kpl','2018-11-07'),(60,'creme fraiche',300.0,'g','2018-11-07'),(61,'kidney pavut',399.0,'g','2018-11-07'),(63,'paseerattu tomaatti',500.0,'g','2018-11-07'),(64,'tomaattimurska',500.0,'g','2018-11-07'),(65,'vihreat pavut',400.0,'g','2018-11-07'),(66,'maissi',400.0,'g','2018-11-07'),(67,'basilika',160.0,'g','2018-11-07'),(68,'sipulijauhe',100.0,'g','2018-11-07'),(69,'valkosipulijauhe',100.0,'g','2018-11-07'),(70,'kookosoljy',400.0,'g','2018-11-07'),(71,'Voi',500.0,'g','2018-07-06');
/*!40000 ALTER TABLE `AINEET` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-10 11:13:29
