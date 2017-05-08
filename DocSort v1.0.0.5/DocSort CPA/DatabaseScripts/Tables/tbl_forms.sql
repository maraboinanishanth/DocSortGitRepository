/*
SQLyog Community v12.2.6 (64 bit)
MySQL - 5.5.15 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `tbl_forms` (
	`Form_ID` int (11),
	`FormClassName` varchar (450),
	`FormName` varchar (450),
	`MenuID` int (11),
	`Status` bit (1)
); 
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('1','SearchString','Workspace Setup','15','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('2','DashBoardHome','All Cabinets','16','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('3','NewFileCabinet','New Cabinet','17','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('4','OpenFileCabinet','Open Cabinet','18','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('5','Documents','All Documents','19','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('6','DocumentsCountReport','Summary by Folder','20','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('7','DocumentStatusReport','Document Status','21','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('8','DocumentsReport','Summary by Status','22','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('9','Import','Import','23','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('10','Useraccesspermissions','User Access Permissions','24','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('11','ChangePassword','Change Password','25','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('12','Log_History','My Activity','26','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('13','Help','Help','27','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('14','Feedback','Feedback','28','');
insert into `tbl_forms` (`Form_ID`, `FormClassName`, `FormName`, `MenuID`, `Status`) values('15','UserEntry','NewUser','29','');
