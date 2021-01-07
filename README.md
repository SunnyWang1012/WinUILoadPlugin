# WinUILoadPlugin

The purpose of this project is to do a simple PoC to let WinUI 3.0(Desktop) App to dynamically load the plugins written in WinUI 3.0(Deskktop) ClassLibrary.
The code sturctures are as followings

* **PluginBase** is a WinUI ClassLibray and it only has the definition of **ICommand** interface to be referenced by the following projects.

* **WinUILoadApp(Package)** and **WinUILoadApp** are WinUI(Desktop) App where inside "MainWindow.xaml" are the details of how to dynamically load external WinUI3.0 ClassLibrary for example, **HelloPlugin**. It directly add reference to **PluginBase** project
* **HelloPlugin** is a WinUI ClassLibrary and it directly add reference to **PluginBase** project and does the implementation of ICommand. Need to mention that it creates a "HelloUserControl" and set it as the return for one field(View) in ICommand interface. 
* **DataProvider** is a WinUI ClassLibray and added as reference by **HelloPlugin** to provide the values for HelloPlugin.

## How To Deploy
* Deploy **WinUILoadApp(Package)** first
* Right click on **HelloPlugin** project to build 
 (The reason why deploying WinUILoadApp (Package) first is, there is a post build script to xcopy HelloPlugin related binaries into **AppX** under **WinUILoadApp(Package)** project (WinUILoadApp (Package)\bin\x64\Debug\AppX)
* Run the project

## Known Issue
Currently, this solution can't run successfully when dynamically loading HelloPlugin. The exceptop occurs inside the constructor of HelloUserControl. 
