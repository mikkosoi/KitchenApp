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
-- Table structure for table `RESEPTIT`
--

DROP TABLE IF EXISTS `RESEPTIT`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `RESEPTIT` (
  `Resepti_ID` int(11) NOT NULL AUTO_INCREMENT,
  `nimi` varchar(50) NOT NULL,
  `ohje` varchar(5000) DEFAULT NULL,
  `valmistusaika` int(11) NOT NULL,
  `haaste` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Resepti_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `RESEPTIT`
--

LOCK TABLES `RESEPTIT` WRITE;
/*!40000 ALTER TABLE `RESEPTIT` DISABLE KEYS */;
INSERT INTO `RESEPTIT` VALUES (1,'makaronilaatikko','Makaronilaatikko.\n\nKeitä makaronit pakkauksen ohjeen mukaan. Voit jättää makaronit myös keittämättä ja pääset näin helpommalla. \n\nKaada kerroksittain makaroneja ja jauhelihaa voideltuun vuokaan. Sekoita kananmunat ja maito (tai lihaliemi) ja kaada vuokaan. \n\nKypsennä 200-asteisen uunin alatasolla 1 tunti.',50,'helppo'),(2,'American Pancakes','blablabla',75,'helppo'),(3,'Brownies','This is the ohje',50,'keskivaikea'),(4,'2 A.M. Chili','this is the ohje',50,'keskivaikea'),(6,'Hot Dog',NULL,30,'Helpp');
/*!40000 ALTER TABLE `RESEPTIT` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-10 11:13:27
