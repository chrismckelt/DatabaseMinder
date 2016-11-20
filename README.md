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




## Linqpad sample backup with reference from nuget

    var args = new DatabaseMinder.CommandArgs();
	args.DatabaseName = "DatabaseMinder";
	args.Backup = true;
	args.Folder = @"c:\temp";
	args.PromptsEnabled = false;
	args.ZipBackup = true;
	DatabaseMinder.Handler.HandleCommand(args);

### PRs/Issues/Comments welcome!
