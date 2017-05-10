DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateUserDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateUserDetails`(IN UserId INT,IN Firstname VARCHAR(45),IN Lastname VARCHAR(45),IN Middlename VARCHAR(45),IN address VARCHAR(200),IN city VARCHAR(45),IN state VARCHAR(45),IN country VARCHAR(45),IN zip VARCHAR(10),IN mobileno VARCHAR(10),IN alternativemobileno VARCHAR(10),IN Username VARCHAR(50),IN PASSWORD VARCHAR(45),IN RoleId INT,IN Isstatus BIT(1))
BEGIN
UPDATE tbl_users SET
FirstName=Firstname,
LastName=Lastname,
MiddleName=Middlename,
Address=address,
City=city,
State=state,
Country=country,
Zip=zip,
MobileNo=mobileno,
AlternateMobileNo=alternativemobileno,
User_Name=Username,
PASSWORD=PASSWORD,
Role_ID=RoleId,
STATUS=Isstatus
WHERE User_ID=UserId;
END$$

DELIMITER ;