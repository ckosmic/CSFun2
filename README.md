# CSFun 2 
CSFun 2 is a modular program that executes C# projects in the form of plugins called Subprocesses (or Subs for short).  This is a follow-up to the original, legacy CSFun written in Java, making this C# version faster and easier to use.

## Creating Subprocesses
To create Subprocess plugins, first clone the `plugin` branch from this repository (`git clone -b plugin --single-branch https://github.com/ckosmic/CSFun2.git`) or download it as a .ZIP file.  After you have the files, open CSFun 2.sln in Visual Studio 2017.  Create a new project in the solution and call it whatever you want.  When the project is created, make sure to include the CSFun2.Plugin namespace by right clicking on "References" and selecting "Add Reference...".  When the Reference Manager window pups up, choose "Projects" from the left sidebar and "Solution" from the dropdown.  Enable "CSFun2.Plugin" by checking it and hit OK.
All CSFun 2 Subs require two things:
1. The main script for the Sub must inherit the ISub interface from the CSFun2.Plugin project
2. There must be a settings class present, INSERT EXAMPLE HERE.