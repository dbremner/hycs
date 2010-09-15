@echo off

csc /? 2>NUL 1>NUL 

if ERRORLEVEL 1 (
    if exist D:\Progs\VS9.0\VC\vcvarsall.bat call D:\Progs\VS9.0\VC\vcvarsall.bat
    if exist D:\Progs\VS8\VC\vcvarsall.bat call D:\Progs\VS8\VC\vcvarsall.bat
) else (
    echo VCVARALL has been set!
)
make


:END

@pause
