# DatabaseMinder
Backup and restore command line executable for managing SQL databases

This utility performs actions such as.
- database backup
- database restore
 
------------------------
Usage:
------------------------
/help                   Show help

Example:

DatabaseMinder.exe /b /u /c CONNECTION STRING GOES HERE

Arguments:

        /s ServerName - eg localhost
        /f Filename - eg ExampleDatabase.bak  ExampleZip.zip
        /r Restore - Restore database
        /b Backup - Backup database. Server name and ToDirectory required
        /d DatabaseName - backup / restore name for the DB
        /n PromptsEnabled - Uses this flag on build server to skip any prompt
        /x XfromDirectory
        /t ToDirectory
