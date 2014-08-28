@setlocal enableextensions
@cd /d "%~dp0"

diskpart /s MountEfi.txt

taskkill /im explorer.exe /f 
explorer.exe 