git clean -xdf
IF %ERRORLEVEL% NEQ 0 ( 
	EXIT /B %ERRORLEVEL%
)


:: https://github.com/PowerShell/Microsoft.PowerShell.Archive/issues/71
::
REM powershell Compress-Archive -Path * -DestinationPath GunvorAssessment.clean.zip -Force
REM IF %ERRORLEVEL% NEQ 0 ( 
	REM EXIT /B %ERRORLEVEL%
REM )


@set path=%path%;c:\Program Files\7-Zip\
7z a GunvorAssessment.clean.zip *.* -r
IF %ERRORLEVEL% NEQ 0 ( 
	EXIT /B %ERRORLEVEL%
)
