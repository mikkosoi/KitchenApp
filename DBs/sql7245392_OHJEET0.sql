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
-- Table structure for table `OHJEET`
--

DROP TABLE IF EXISTS `OHJEET`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `OHJEET` (
  `Ohjeet_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Resepti_ID` int(11) NOT NULL,
  `Aine_ID` int(11) NOT NULL,
  `Maara` int(11) NOT NULL,
  `Mittayksikko` varchar(5) NOT NULL,
  PRIMARY KEY (`Ohjeet_ID`),
  KEY `aineet_idx` (`Aine_ID`),
  KEY `reseptit` (`Resepti_ID`),
  CONSTRAINT `reseptit` FOREIGN KEY (`Resepti_ID`) REFERENCES `RESEPTIT` (`Resepti_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `aineet` FOREIGN KEY (`Aine_ID`) REFERENCES `AINEET` (`Aine_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=118 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OHJEET`
--

LOCK TABLES `OHJEET` WRITE;
/*!40000 ALTER TABLE `OHJEET` DISABLE KEYS */;
INSERT INTO `OHJEET` VALUES (2,1,44,600,'g'),(3,1,47,400,'g'),(4,1,10,1,'kpl'),(5,1,41,4,'g'),(6,1,46,1,'g'),(7,1,33,4,'g'),(8,1,8,3,'kpl'),(9,1,1,1,'l'),(10,2,48,500,'ml'),(11,2,8,3,'kpl'),(12,2,27,45,'g'),(13,2,23,4,'g'),(14,2,32,2,'g'),(15,2,24,4,'g'),(16,2,40,4,'g'),(17,2,22,500,'g'),(18,2,7,150,'g'),(27,3,27,400,'g'),(28,3,26,100,'g'),(29,3,8,4,'kpl'),(30,3,40,4,'g'),(31,3,7,200,'g'),(32,3,25,200,'g'),(33,3,22,90,'g'),(34,3,23,4,'g'),(79,4,47,700,'g'),(80,4,10,1,'kpl'),(81,4,11,1,'kpl'),(82,4,59,1,'kpl'),(83,4,2,200,'g'),(84,4,64,400,'g'),(85,4,63,400,'g'),(86,4,66,400,'g'),(87,4,61,400,'g'),(88,4,62,400,'g'),(89,4,65,400,'g'),(90,4,66,250,'g'),(91,4,28,8,'g'),(92,4,22,8,'g'),(101,4,67,4,'g'),(102,4,68,4,'g'),(103,4,43,16,'g'),(113,4,37,8,'g'),(114,4,33,4,'g'),(115,4,69,12,'g'),(116,4,70,16,'g'),(117,4,57,0,'l');
/*!40000 ALTER TABLE `OHJEET` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-06 14:59:58
