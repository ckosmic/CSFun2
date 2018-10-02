# CSFun 2 
CSFun 2 is a modular program that executes C# projects in the form of plugins called Subprocesses (or Subs for short).  This is a follow-up to the original legacy CSFun written in Java, making this C# version faster and easier to use.

Legacy CSFun was made to mess around and have fun in Computer Science class by running WinAPI programs to make computers look like they were breaking, thus giving the extremely creative name: CSFun.

## Instructions
Download the latest release of CSFun 2, extract the files and run CSFun 2.exe.  You can add a Sub by clicking "Add New Subprocess...", browsing for a Subprocess plugin dll and clicking "Add Sub".

## Creating a Subprocess
To create Subprocess plugins, first download `CSFun2.Plugin.dll`.  After you have the dll, open Visual Studio 2017 and create a new solution.  Create a new project in the solution and call it whatever you want.  Mke sure to include the CSFun2.Plugin namespace by right clicking on "References" and selecting "Add Reference...".  When the Reference Manager window pups up, choose "Browse" from the left sidebar and browse for the dll.  Enable `CSFun2.Plugin.dll` by checking it and hit OK.
All CSFun 2 Subs require two things:
1. The main class for the Sub must inherit the `ISub` interface from CSFun2.Plugin
2. There must be a settings class present, INSERT EXAMPLE HERE.