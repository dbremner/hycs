@echo off

csc /? 2>NUL 1>NUL 

if ERRORLEVEL 1 (
    if exist D:\Progs\VS10\VC\vcvarsall.bat (
        call  D:\Progs\VS10\VC\vcvarsall.bat
        goto RUN_MAKE
    )
    if exist D:\Progs\VS9.0\VC\vcvarsall.bat (
        call D:\Progs\VS9.0\VC\vcvarsall.bat
        goto RUN_MAKE
    )
    if exist D:\Progs\VS8\VC\vcvarsall.bat (
        call D:\Progs\VS8\VC\vcvarsall.bat
        goto RUN_MAKE
    )
) else (
    echo VCVARALL has been set!
)

: RUN_MAKE
make


:END

@pause
