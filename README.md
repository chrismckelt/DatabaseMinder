[![databaseminder MyGet Build Status](https://www.myget.org/BuildSource/Badge/databaseminder?identifier=3271b45e-de61-41e8-b1a1-7a3188a700e4)](https://www.myget.org/)

## DatabaseMinder  -- requests welcome --> just raise an issue

**Backup and zip or restore a MS SQL database library with command line runner**

### Command line runner NOT included in nuget package ###

#### see LINQPAD reference for use (down below) ####


**if you would like a separate NUGET package let me know & Ill make it**

This utility performs actions such as

1. database backup and zip
2. database restore
 
![image](https://cloud.githubusercontent.com/assets/662868/15823597/f85229f4-2c2d-11e6-9dd9-84b7c4be07cb.png)



## BACKUP with reference from nuget

    var args = new DatabaseMinder.CommandArgs();
	args.DatabaseName = "DatabaseMinder";
	args.Backup = true;
	args.Folder = @"c:\temp";
	args.PromptsEnabled = false;
	args.CompressionEnabled = true;
	args.ZipBackup = true;
	DatabaseMinder.Handler.HandleCommand(args);

## Restore a database from a folder (should contain at least 1 .bak file)

    DatabaseMinder.RestoreDatabase.RestoreDatabaseFromFolder(new Server(), "exampleDB_Name", @"c:\path_to_backup","@c:\path_to_save_mdf_and_ldf");

### PRs/Issues/Comments welcome!
