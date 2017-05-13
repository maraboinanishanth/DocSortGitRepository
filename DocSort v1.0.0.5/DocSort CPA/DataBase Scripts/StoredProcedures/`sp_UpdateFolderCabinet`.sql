DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateFolderCabinet`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateFolderCabinet`(IN CabinetName VARCHAR(250), IN Foldername VARCHAR(250))
BEGIN
UPDATE tbl_folder SET
FileCabinet_Id = (SELECT FileCabinet_ID FROM tbl_fileCabinet WHERE 
                    FileCabinet_Name = CabinetName)
WHERE Folder_Name = Foldername;
END$$

DELIMITER ;