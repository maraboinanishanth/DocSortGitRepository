DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_UpdateFileDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateFileDetails`(
IN FolderId INT,IN FilecabinetId INT,IN CabinetName VARCHAR(250), 
IN Filename VARCHAR(250),IN Filepath LONGTEXT,IN Isdelete VARCHAR(5))
BEGIN
UPDATE tbl_files
SET File_Path = Filepath,
    Folder_ID = FolderId,
    FileCabinet_ID = (SELECT FileCabinet_ID FROM tbl_filecabinet 
                      WHERE FileCabinet_Name = CabinetName)
WHERE File_ID = FilecabinetId;  
END$$

DELIMITER ;