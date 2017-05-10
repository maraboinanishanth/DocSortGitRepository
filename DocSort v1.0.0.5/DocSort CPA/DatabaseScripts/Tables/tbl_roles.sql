/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_roles` (
	`Role_ID` int (11),
	`Role_Name` varchar (135),
	`Role_Desc` varchar (150),
	`IsActive` bit (1)
); 
insert into `tbl_roles` (`Role_ID`, `Role_Name`, `Role_Desc`, `IsActive`) values('1','admin','admin desc','');
insert into `tbl_roles` (`Role_ID`, `Role_Name`, `Role_Desc`, `IsActive`) values('2','clerk','clerk','');
