@Echo Off
SETLOCAL EnableDelayedExpansion
for /F "tokens=1,2 delims=#" %%a in ('"prompt #$H#$E# & echo on & for %%b in (1) do     rem"') do (
  set "DEL=%%a"
)
mode con:cols=83 lines=5
ECHO OFF 
echo.
echo.
call :colorEcho 0c "Please wait for the programs to open. This window will close as soon as it's done."
echo.

:: here you can put programs you want to execute, eg. here its outlook, file explorer and notepad++
start OUTLOOK.EXE
explorer
cd "C:\Program Files (x86)\Notepad++\"
start notepad++.exe
TIMEOUT 5

exit
:colorEcho
echo off
<nul set /p ".=%DEL%" > "%~2"
findstr /v /a:%1 /R "^$" "%~2" nul
del "%~2" > nul 2>&1i