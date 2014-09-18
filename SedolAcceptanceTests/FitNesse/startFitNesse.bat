@echo off

IF exist ..\bin\Debug (echo ===>>Cool! We assume libraries have been built...We need this for real demo)ELSE (
echo Attempting to run msBuild cmd.. && msbuild ..\..\MarketDataChecker.sln /t:SedolAcceptanceTests:Rebuild /p:Configuration=Debug /p:Platform="Any CPU") 

if errorlevel 1 echo "====>>>>Build was not executed successfully..PLEASE TRY Opening Solution and build from Visual Studio";
 

java -jar fitnesse-standalone.jar -d . -r FitNesseRoot