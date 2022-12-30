# MoleculeSoftware.Packages.InternalLogger

## What is InternalLogger
Internal logger is a small library that extends any consuming application, enabling it to write a simple log to a dedicated logging database. 

## How to use - There are two options. Please choose one of the following

### Reference 
1. Include by using the dotnet CLI
```
dotnet add package MoleculeSoftware.Package.InternalLogger
```
2. Include by adding a reference to the CSPROJ file for your project
```
<PackageReference Include="MoleculeSoftware.Package.InternalLogger"/>
```
### Add using reference 
```c#
using MoleculeSoftware.Packages.InternalLogger;
```
### Create a log
```c#
private void SampleMethod()
{
	// Create log using an object that complies with interface IInternalLog
	SampleLogClass log = new SampleLogClass("Test", "Test", LogTypes.Information, "Sample additional info"); 
	var result = InternalLoggerService.SaveNewLogAsync(); // Will return a boolean
	. . .
}
```
