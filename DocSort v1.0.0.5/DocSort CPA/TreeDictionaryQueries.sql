SELECT cabinets.isdelete, cabinets.filecabinet_id AS FileCabinetID,cabinets.filecabinet_name AS FileCabinetName,
		folders.folder_id AS FolderID,folders.folder_name AS FolderName,folders.parentfolderid AS ParentFolderID,
			files.file_id AS FileID,files.file_name AS FileName,files.file_path AS FilePath
				FROM tbl_filecabinet cabinets 
				JOIN tbl_folder folders ON cabinets.filecabinet_id = folders.filecabinet_id
				JOIN tbl_files files ON folders.folder_id = files.folder_id AND files.filecabinet_id = cabinets.filecabinet_id
					 AND cabinets.isdelete = 'True' AND folders.isdelete = 'True' AND files.isdelete = 'True'