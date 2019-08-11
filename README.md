# PLPM - *Private Located Package Manager*

[![Build Status](https://dev.azure.com/capra314cabra/PrivateLocatedPackageManager/_apis/build/status/capra314cabra.plpm?branchName=master)](https://dev.azure.com/capra314cabra/PrivateLocatedPackageManager/_build/latest?definitionId=4&branchName=master)
[![Version](https://img.shields.io/badge/latest-v1.1-orange)](https://github.com/capra314cabra/plpm/releases)

This is a tool with which you can create and install some packages locally.

## Description

Do you have any experiences that you wanna test your library or install something temporary? On that time, you may have to put some libraries to the special directory such as "System32", "usr/lib". And you face to the problem - *"Are they detachable?"*  
With this tool, you can create "package"(contains libraries) and share it only in your computer. The "package" shared can be installed whenever you want and it is easy to uninstall.  
You wanna know more information? Watch [Usage](https://github.com/capra314cabra/plpm#usage).

## Installation

Choose one from followings.

### Use GitHub release (Recommended)

1. Jump to [Release page](https://github.com/capra314cabra/plpm/releases)
2. Download package
3. Extract it wherever you wanna install
4. Add the path of the directory where you installed it to PATH values(optional)
5. Finally you can use plpm. Hooray!

### Build from source code (Hard way)

1. Clone this repo
   ```
   git clone https://github.com/capra314cabra/plpm.git
   ```
2. Run dotnet command on "plpmcui" directory
   ```
   cd plpm/scripts/plpmcui
   dotnet publish --runtime <RID>
   ```
   Do you know what is RID?
   See also [Microsoft RID catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)
3. You will see a binaries in bin directory
4. After this, it is the same way to GitHub release section

## Usage

### Create a package

![plpm_create](https://media.githubusercontent.com/media/capra314cabra/plpm/master/img/plpm_create.gif)

When you wanna create a new package, you need to create a "PLPM Project File" first. It is easy to create.  
The PLPM project file is a kind of JSON and it is formatted as following.
```JSON
{
    "Name": "Package Name",
    "Description": "Description",
    "ContentsFiles": [
        "1.txt",
        "subfolder/2.txt",
        "image.png"
    ]
}
```
:warning: **The child of "ContentsFiles" should be a RELATIVE path.**  
:warning: **"PLPM Project File" should be named as "plpmproj.json".**  
  
The PLPM project file works as a blueprint of a package.

Created one? Go to the next step!  
Second, run a commmand in the directory plpmproj.json exists.
```
plpm create
```
This command ran successfully means PLPM created a package successfully!
If you're worried about it, you can check the list of packages by following command.
```
plpm search
```

### Install the package

![plpm_install](https://media.githubusercontent.com/media/capra314cabra/plpm/master/img/plpm_install.gif)

Installing a package is easy.
Move to where you wanna install package and type following command:
```
plpm install [package name]
```
Only this.

### Uninstall the package

Uninstalling a package is easy too.
Move to where you wanna install package and type following command:
```
plpm uninstall [package name]
```
Only this.

## Contribution

We always welcomes you to join us.

## License

This project is under [MIT License](https://github.com/capra314cabra/plpm/blob/master/LICENSE).

## Authors

[capra314cabra](https://github.com/capra314cabra)
