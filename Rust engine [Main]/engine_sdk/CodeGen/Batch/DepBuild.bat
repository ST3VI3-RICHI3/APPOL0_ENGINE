@echo off

rem STVI3 STUDIOS 2018
echo Writing details...
set "ProjName=<ProjName.ini"
echo y | del ProjName.ini
set "Auhors=Test"
echo Project name: %ProjName%
echo Project authors(s): %Authors%
echo [package] > Cargo.toml
echo name = "%ProjName%" >> Cargo.toml
echo version = "0.1.0" >> Cargo.toml
echo Auhors = ["%Auhors%"] >>Cargo.toml
echo Done!

echo( >> cargo.toml

echo Writing dependencies...
echo [dependencies] >> Cargo.toml
echo Done!
pause
