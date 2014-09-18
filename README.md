I Assume you have the following on your path:

1) Java (to start FitNesse)
2) msbuild (to build from command line)

The Automation Test Fixture are located on the same solution under the project:

SedolAcceptanceTests 

Ive developed it with Fit framework which goes with with non-technical users also.

EXECUTION and DEMO:
...................

Git clone the project (if you have git client)
or

Just download the SedolCheckerTesterCandidateVersion.zip and extract it to C:\

You should not have something like this:

C:\SedolCheckerTesterCandidateVersion

open command prompt (ms dos)

then execute:

cd C:\SedolCheckerTesterCandidateVersion\SedolAcceptanceTests\FitNesse

startFitNesse


This should build the source and start fitNesse on localhost port 80 (default)

open the browser and navigate to http://localhost

from there you can select any test link and press the test button
...



Troubleshoot:
............

1) -->If there is an error with running MSBuild, don't worry just open the solution with Ms Visual Studio and go to the SedolAcceptanceTests and Build it. 

2) --> If there is no java installed then try to extract the zip content into java installed machine

3) --> If fitNesse complains port already in use. Please do the following:
edit startFitNesse.bat located under  C:\SedolCheckerTesterCandidateVersion\SedolAcceptanceTests\FitNesse
like this:


java -jar fitnesse-standalone.jar -p 8080 -d . -r FitNesseRoot

so instead of just
java -jar fitnesse-standalone.jar -d . -r FitNesseRoot
we now passed -p <portNo> to change port.

