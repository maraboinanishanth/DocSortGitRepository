/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_menus` (
	`MenuID` int (11),
	`MenuName` varchar (750),
	`Description` varchar (1500),
	`MainMenuId` int (11),
	`ImageName` varchar (750)
); 
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('1','My Workspace','My Workspace Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('2','Cabinet View','Cabinet View Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('3','Reports','Reports Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('4','Import','Import Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('5','Permissions','Permissions Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('6','Account','Account Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('7','Help','Help Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('8','Feedback','Feedback Desc',NULL,NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('15','Workspace Setup','Workspace Setup Desc','1',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('16','All Cabinets','All Cabinets Desc','2',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('17','New Cabinet','New Cabinet Desc','2',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('18','Open Cabinet','Open Cabinet Desc','2',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('19','All Documents','All Documents Desc','3',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('20','Summary by Folder','Summary by Folder Desc','3',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('21','Document Status','Document Status Desc','3',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('22','Summary by Status','Summary by Status Desc','3',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('23','Import','Import Desc','4',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('24','User Access Permissions','User Access Permissions Desc','5',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('25','Change Password','Change Password Desc','6',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('26','My Activity','My Activity Desc','6',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('27','Help','Help Desc','7',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('28','Feedback','Feedback Desc','8',NULL);
insert into `tbl_menus` (`MenuID`, `MenuName`, `Description`, `MainMenuId`, `ImageName`) values('29','NewUser','NewUser Desc','5',NULL);
