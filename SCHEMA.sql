-- --------------------------------------------------------
-- Host:                         xayr.ga
-- Server version:               5.5.9-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for xen3
CREATE DATABASE IF NOT EXISTS `xen3` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `xen3`;

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
) ENGINE=InnoDB AUTO_INCREMENT=3984 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
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
  `kickurlunactivated` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`group`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Dumping structure for table xen3.xenf_spoken
CREATE TABLE IF NOT EXISTS `xenf_spoken` (
  `index` int(11) NOT NULL AUTO_INCREMENT,
  `group` bigint(20) NOT NULL,
  `messageid` bigint(20) NOT NULL,
  `lifetime` int(11) NOT NULL,
  `whencreated` bigint(20) NOT NULL,
  PRIMARY KEY (`index`)
) ENGINE=InnoDB AUTO_INCREMENT=17930 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
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
) ENGINE=InnoDB AUTO_INCREMENT=52155 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
