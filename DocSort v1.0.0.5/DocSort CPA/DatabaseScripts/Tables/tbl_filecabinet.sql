/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_filecabinet` (
	`FileCabinet_ID` int (11),
	`FileCabinet_Name` varchar (750),
	`IsDelete` varchar (15)
); 
insert into `tbl_filecabinet` (`FileCabinet_ID`, `FileCabinet_Name`, `IsDelete`) values('54','6000 files to test','True');
