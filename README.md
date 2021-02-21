# .NET Core dump demo

This is a demo of .NET 5 "incomplete" crash dump file in asynchronous context.

## Reproduce the issue

1. Enable full crash dump with RegEdit:
	1. Go to `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\Windows Error Reporting\LocalDumps`
	2. Add a new `32 bits DWORD` value named `DumpType`
	3. Set `DumpType` value to `2` (Full dump)
1. Run `.\publish.cmd` to build *AsyncConsoleApp* and *SyncConsoleApp* in release mode with debug info (targeting win-x64)
1. Run `.\SyncConsoleApp\bin\Release\net5.0\publish\SyncConsoleApp.exe`
1. Run `.\AsyncConsoleApp\bin\Release\net5.0\publish\AsyncConsoleApp.exe`
1. Dump files are generated in `%localappdata%\CrashDumps`
1. Open dump files with Visual Studio 2019 and run *Debug with Managed Only*

With *SyncConsoleApp* you will see the full call trace, the C# source code and the exception in `SyncConsoleApp\Program.cs`.

With *AsyncConsoleApp* you will see a partial call stack, and trying to access `AsyncConsoleApp!AsyncConsoleApp.Program.<Main>(string[] args)` stack frame will give you a `Source Not Available` error.  
The final exception will be in `System.Private.CoreLib!System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw() Line 56`