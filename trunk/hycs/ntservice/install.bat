@echo off

set CWD=%~dp0

set ServiceName=

if "%1"=="" (
  set ServiceName=HelloService
  goto INSTALL_SERVICE
) else if "%1"=="/u" (
  if "%2"=="" (
    set ServiceName=HelloService
  ) else (
    set ServiceName=%2
  )  
  goto UNINSTALL_SERVICE
) else (
  set ServiceName=%1
  goto INSTALL_SERVICE
)

:INSTALL_SERVICE
echo Install Service
sc create %ServiceName% binPath= "%CWD%%ServiceName%.exe" DisplayName= "%ServiceName%" start= auto
goto END_BATCH

:UNINSTALL_SERVICE
echo Uninstall Service
sc delete %ServiceName%
goto END_BATCH

:UNKOWN_ACTION
echo Unkonwn action

:END_BATCH
@pause
