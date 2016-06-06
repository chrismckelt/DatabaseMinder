<Query Kind="Program">
  <NuGetReference>DatabaseMinder</NuGetReference>
  <Namespace>DatabaseMinder</Namespace>
  <Namespace>Serilog</Namespace>
</Query>

void Main()
{
	var args = new DatabaseMinder.CommandArgs();
	args.DatabaseName = "DatabaseMinder";
	args.Restore = true;
	args.Folder = @"C:\temp\DatabaseMinder_20160606";
	args.PromptsEnabled = false;
	DatabaseMinder.Handler.HandleCommand(args);
}

 