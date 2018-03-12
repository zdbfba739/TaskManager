%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe  %~dp0TaskManager.WinService.exe

Net Start TaskManager.WinService

sc config TaskManager.WinService start= auto

pause
