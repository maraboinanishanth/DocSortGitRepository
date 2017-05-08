/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_folder` (
	`Folder_ID` int (11),
	`FileCabinet_ID` int (11),
	`Folder_Name` varchar (750),
	`ParentFolderID` int (11),
	`IsDelete` varchar (15)
); 
