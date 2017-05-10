DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertUserValues`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertUserValues`(IN Firstname VARCHAR(45),IN Lastname VARCHAR(45),IN Middlename VARCHAR(45),IN address VARCHAR(200),IN city VARCHAR(45),IN state VARCHAR(45),IN country VARCHAR(45),IN zip VARCHAR(10),IN mobileno VARCHAR(10),IN alternativemobileno VARCHAR(10),IN Username VARCHAR(50),IN PASSWORD VARCHAR(45),IN RoleId INT,IN Isstatus BIT(1))
BEGIN
INSERT INTO tbl_users
(
FirstName,
LastName,
MiddleName,
Address,
City,
State,
Country,
Zip,
MobileNo,
AlternateMobileNo,
User_Name,
PASSWORD,
Role_ID,
STATUS
)
VALUES
(
Firstname,
Lastname,
Middlename,
address,
city,
state,
country,
zip,
mobileno,
alternativemobileno,
Username,
PASSWORD,
RoleId,
Isstatus
);
END$$

DELIMITER ;