@echo off

echo Writing details...
set ProjName = Test
set authors = Test
echo [package] > Cargo.toml
echo name = "%ProjName%" >> Cargo.toml
echo version = "0.1.0" >> Cargo.toml
echo authors = ["%authors%"] >>Cargo.toml
echo Done!

echo #Batch hates newlines so this fills in for it. >> cargo.toml

echo Writing dependencies...
set DepNum = 0
echo [dependencies] >> Cargo.toml
rem remove "rem" to test file loading.
rem set Deps = < deps.tmp
echo Done!
pause
