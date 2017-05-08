DELIMITER $$

USE `cpa-mysql`$$

DROP PROCEDURE IF EXISTS `sp_InsertFolderDetails`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_InsertFolderDetails`(IN FilecabinetId INT,IN Foldername VARCHAR(250),IN ParentfolderId INT,IN Isdelete VARCHAR(5))
BEGIN
INSERT INTO tbl_folder
(
FileCabinet_ID,
Folder_Name,
ParentFolderID,
IsDelete
)
VALUES
(
FilecabinetId,
Foldername,
ParentfolderId,
Isdelete
);
SELECT LAST_INSERT_ID() FolderId;
END$$

DELIMITER ;