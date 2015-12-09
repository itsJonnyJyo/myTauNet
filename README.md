# Jensen_Jonathan_cs300
BUILD INSTRUCTIONS:
   
  All filepaths within the sourcecode must be changed to a valid filepath on the build machine in order
  to work properly.
  The Build machines local IP address must be supplied  to "server.cs" in order for the server
  to function properly.
  
  By far the simplest way to build and execute the project would be in visual studio.
  
  However it may also be built and executed in a linux environment by installing the Mono Framework.
  sudo apt-get install mono-runtime
  sudo apt-get install mono-xbuild
  sudo apt-get install mono-complete
  
  navigate to /jensen_jonathan_cs300/Taunet where the TauNet.sln is located and use the command
  "xbuild Taunet.sln" to build the project.
  
  In order to debug and run the separate projects I ssh-ed into my pi via two separate terminal windows.
  In the first window, navigate to /TauNet/TauNet/bin/Debug where "TauNet.exe" will be located and use 
  the command "mono TauNet.exe" to run.
  In the second window, navigate to /TauNet/TauNetServer/bin/Debug where "TauNetServer.exe" will be located
  and use the command "mono TauNetServer.exe" to run.
