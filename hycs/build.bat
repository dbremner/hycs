@echo off

csc /? 2>NUL 1>NUL 

if ERRORLEVEL 1 (
    call D:\Progs\VS8\VC\vcvarsall.bat
) else (
    echo VCVARALL has been set!
)
make

@pause
