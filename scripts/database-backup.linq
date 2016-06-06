<Query Kind="Program">
  <NuGetReference>DatabaseMinder</NuGetReference>
  <Namespace>DatabaseMinder</Namespace>
  <Namespace>Serilog</Namespace>
</Query>

void Main()
{
	var args = new DatabaseMinder.CommandArgs();
	args.DatabaseName = "DatabaseMinder";
	args.Backup = true;
	args.Folder = @"c:\temp";
	args.PromptsEnabled = false;
	args.ZipBackup = true;
	DatabaseMinder.Handler.HandleCommand(args);
}

 