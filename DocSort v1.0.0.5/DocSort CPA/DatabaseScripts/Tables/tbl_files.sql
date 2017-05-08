/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_files` (
	`File_ID` int (11),
	`Folder_ID` int (11),
	`FileCabinet_ID` int (11),
	`File_Name` varchar (750),
	`File_Path` text ,
	`IsDelete` varchar (15)
); 
