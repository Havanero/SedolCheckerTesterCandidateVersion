I Assume you have the following on your path:

1) Java (to start FitNesse)
2) msbuild (to build from command line)

The Automation Test Fixture are located on the same solution under the project:

SedolAcceptanceTests 

They have been developed with Fit framework which goes with with non-technical users also.

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

