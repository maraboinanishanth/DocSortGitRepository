/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_loghistory` (
	`log_ID` int (11),
	`log_datetme` varchar (150),
	`loggedIn_user` varchar (150),
	`Description` text ,
	`Type` varchar (150),
	`Log_Date` varchar (150)
); 
