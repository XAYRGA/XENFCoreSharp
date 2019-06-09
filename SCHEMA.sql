-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.9-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table xen3.xenf_autokick
CREATE TABLE IF NOT EXISTS `xenf_autokick` (
  `index` bigint(20) NOT NULL AUTO_INCREMENT,
  `group` bigint(20) DEFAULT NULL,
  `user` bigint(20) DEFAULT NULL,
  `when` bigint(20) DEFAULT NULL,
  `why` text,
  `type` int(11) DEFAULT NULL,
  `affected` text,
  PRIMARY KEY (`index`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;



-- Dumping structure for table xen3.xenf_groupconfigs
CREATE TABLE IF NOT EXISTS `xenf_groupconfigs` (
  `group` bigint(20) NOT NULL,
  `autobannames` int(11) NOT NULL DEFAULT '1',
  `kicktime` int(11) NOT NULL DEFAULT '30',
  `message` text NOT NULL,
  `autoban` int(11) NOT NULL DEFAULT '1',
  `muteuntilverified` int(11) NOT NULL DEFAULT '0',
  `announcekicks` int(11) NOT NULL DEFAULT '1',
  `activationmode` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`group`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



-- Dumping structure for table xen3.xenf_spoken
CREATE TABLE IF NOT EXISTS `xenf_spoken` (
  `index` int(11) NOT NULL AUTO_INCREMENT,
  `group` bigint(20) NOT NULL,
  `messageid` bigint(20) NOT NULL,
  `lifetime` int(11) NOT NULL,
  `whencreated` bigint(20) NOT NULL,
  PRIMARY KEY (`index`)
) ENGINE=InnoDB AUTO_INCREMENT=293 DEFAULT CHARSET=utf8;

-- Dumping data for table xen3.xenf_spoken: ~7 rows (approximately)
/*!40000 ALTER TABLE `xenf_spoken` DISABLE KEYS */;
/*!40000 ALTER TABLE `xenf_spoken` ENABLE KEYS */;


-- Dumping structure for table xen3.xen_activations
CREATE TABLE IF NOT EXISTS `xen_activations` (
  `index` bigint(20) NOT NULL AUTO_INCREMENT,
  `activation_id` tinytext,
  `activated` int(11) DEFAULT '0',
  `forwho` bigint(20) DEFAULT NULL,
  `group` bigint(20) DEFAULT NULL,
  `whencreated` bigint(20) DEFAULT NULL,
  `activation_checked` int(11) DEFAULT '0',
  `username` text,
  `actmessage` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`index`),
  UNIQUE KEY `activation_id` (`activation_id`(32))
) ENGINE=InnoDB AUTO_INCREMENT=35250 DEFAULT CHARSET=utf8;
