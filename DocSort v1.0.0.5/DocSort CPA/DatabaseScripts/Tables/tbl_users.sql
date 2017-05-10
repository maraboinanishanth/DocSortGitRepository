/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_users` (
	`User_ID` int (11),
	`FirstName` varchar (135),
	`LastName` varchar (135),
	`MiddleName` varchar (135),
	`Address` varchar (600),
	`City` varchar (135),
	`State` varchar (135),
	`Country` varchar (135),
	`Zip` varchar (30),
	`MobileNo` varchar (30),
	`AlternateMobileNo` varchar (30),
	`User_Name` varchar (150),
	`Password` varchar (135),
	`Role_ID` int (11),
	`Status` bit (1)
); 
insert into `tbl_users` (`User_ID`, `FirstName`, `LastName`, `MiddleName`, `Address`, `City`, `State`, `Country`, `Zip`, `MobileNo`, `AlternateMobileNo`, `User_Name`, `Password`, `Role_ID`, `Status`) values('1','Cheguri','Satish','','','','',NULL,'','','','admin','WaaC6GRn/Lo=','1','');
