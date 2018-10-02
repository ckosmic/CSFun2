# CSFun 2 
CSFun 2 is a modular program that executes C# projects in parallel in the form of plugins called Subprocesses (or Subs for short).  This is a follow-up to the original legacy CSFun written in Java, making this C# version faster and easier to use.

Legacy CSFun was made to mess around and have fun in Computer Science class by running WinAPI programs to make computers look like they were breaking, thus giving the extremely creative name: CSFun.

## Instructions
Download the latest release of CSFun 2, extract the files and run CSFun 2.exe.  You can add a Sub by clicking "Add New Subprocess...", browsing for a Subprocess plugin dll and clicking "Add Sub".

## Creating a Subprocess
To create Subprocess plugins, first download `CSFun2.Plugin.dll`.  After you have the dll, open Visual Studio 2017 and create a new solution.  Create a new project in the solution and call it whatever you want.  Mke sure to include the CSFun2.Plugin namespace by right clicking on "References" and selecting "Add Reference...".  When the Reference Manager window pups up, choose "Browse" from the left sidebar and browse for the dll.  Enable `CSFun2.Plugin.dll` by checking it and hit OK.
All CSFun 2 Subs require two things:
1. The main class for the Sub must inherit the `ISub` interface from CSFun2.Plugin
2. There must be a settings class present.  Settings classes follow the [PropertyGrid layout](https://www.codeproject.com/Articles/22717/Using-PropertyGrid).  See an example [here](../master/Plugins/Screen%20Glitches/GlitchSettings.cs).

Because Subs are being run on separate threads, they can contain loops that run forever and won't interrupt other Subs.
Every Sub's main class has one entry method and a few variables for information.  The ISub interface implements a method called `SubMethod(dynamic settings)` which is where the program begins.  The `settings` variable is where values from the settings class can be passed to the main class.  The "metadata" variables at the beginning of the class define the:
1. Name of the Subprocess (`name`)
2. Description of the Subprocess (`description`)
3. Author of the Subprocess (`author`)
4. Version of the Subprocess (`version`)
5. The settings class type (`settings`)