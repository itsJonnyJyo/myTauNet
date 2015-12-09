# Jensen_Jonathan_cs300
BUILD INSTRUCTIONS:
  By far the simplest way to build and execute the project would be in visual studio. 
  All filepaths within the sourcecode must be changed to a valid filepath on the build machine.
  contacts.csv must be supplied as it is not in the 
  However it may also be built and executed in a linux environment by installing the Mono Framework.
  sudo apt-get install mono-runtime
  sudo apt-get install mono-xbuild
  sudo apt-get install mono-complete
  
  Currently I havent been able to get xbuild to run the TauNet.sln but I have worked around this buy ssh-ing
  into my pi from 2 separate console windows and compiling and running TauNetPrimary.csproj in one of them
  and TauNet
