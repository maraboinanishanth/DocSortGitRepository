/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_scanneddocumentresults` (
	`ID` int (11),
	`Date` varchar (150),
	`Keyword_ID` int (11),
	`Document_ID` int (11),
	`Document_Path` text ,
	`MatchStatus` varchar (45)
); 
