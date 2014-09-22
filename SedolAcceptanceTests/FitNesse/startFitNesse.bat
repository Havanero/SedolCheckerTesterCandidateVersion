@echo off

REM check if we can use msBuild
if exist C:\Windows\Microsoft.NET\Framework\v4.0.30319 (echo USING Framework V4 && SET MSBUILDEXE=C:\Windows\Microsoft.NET\Framework\v4.0.30319\) ELSE (
echo No v4 Framework Found )

if %MSBUILDEXE%=="" (echo no msbuild.exe found &&  SET MSBUILDEXE="C:\Windows\Microsoft.NET\Framework\v3.5")

REM if exist C:\Windows\Microsoft.NET\Framework\v3.5 (echo USING v3.5) ELSE ( echo No V3.5 Fond)

REM SET MSBUILDEXE="C:\Windows\Microsoft.NET\Framework\v4.0.30319\"
(echo %MSBUILDEXE%)
(echo Checking for Java.....)
where java
if %errorlevel%==1 (echo YOU NEED JAVA ON THIS MACHINE && Exit /B 1 ) ELSE (
echo Found JAVA! so far so good....
)

IF exist ..\bin\Debug (echo Cool! We assume libraries have been built...We need this for real demo)ELSE (
rem echo attempting to run msBuild.exe && msbuild.exe ..\..\MarketDataChecker.sln /t:SedolAcceptanceTests:Rebuild /p:Configuration=Debug /p:Platform="Any CPU");
echo Attempting to run msBuild cmd..; 

REM "C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe" ..\..\MarketDataChecker.sln /t:SedolAcceptanceTests:Rebuild /p:Configuration=Debug /p:Platform="Any CPU");
%MSBUILDEXE%MSBuild.exe ..\..\MarketDataChecker.sln /t:SedolAcceptanceTests:Rebuild /p:Configuration=Debug /p:Platform="Any CPU" );

REM %MSBUILDEXE%MSBuild.exe /?

if %errorlevel%==0 (echo Build was successfully && goto :RUNSUT ) ELSE (
echo Build FAILED....Starting View Mode && goto :JUSTVIEW)
done 

:RUNSUT
(echo Hitting the ground RUNNING)
start /min java -jar fitnesse-standalone.jar -p 9696 -d . -r FitNesseRoot
rem Adding Hack to sleep for 4sec before opening the browser to run the test suit:
ping 127.0.0.1 -n 5 -w 4000 > nul
rem -----------------------------------------------------------Hack End here
REM fire browser and run test
start /max http://localhost:9696/FitNesse.SedolAcceptanceTests?suite
Exit /B 0

:JUSTVIEW
(echo We have started FitNesse for you to browse and view ONLY Mode. You can still run test once you have build the source code via VS)
start /min java -jar fitnesse-standalone.jar -p 9696 -d . -r FitNesseRoot
ping 127.0.0.1 -n 5 -w 4000 > nul
start /max http://localhost:9696/FitNesse.SedolAcceptanceTests