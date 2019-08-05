# PLPM - *Private Located Package Manager*

[![Build Status](https://dev.azure.com/capra314cabra/PrivateLocatedPackageManager/_apis/build/status/capra314cabra.plpm?branchName=master)](https://dev.azure.com/capra314cabra/PrivateLocatedPackageManager/_build/latest?definitionId=4&branchName=master)
[![Version](https://img.shields.io/badge/latest-v1.0-orange)](https://github.com/capra314cabra/plpm/releases)

This is a tool with which you can create and install some packages locally.

## Description

Do you have any experiences that you wanna test your library or install something temporary? On that time, you may have to put some libraries to the special directory such as "System32", "usr/lib". And you face to the problem - *"Are they detachable?"*  
With this tool, you can create "package"(contains libraries) and share it only in your computer. The "package" shared can be installed whenever you want and it is easy to uninstall.  
You wanna know more information? Watch [Usage](/).

## Installation

### Use GitHub release

1. Jump to [Release page](https://github.com/capra314cabra/plpm/releases)
2. Download package
3. Extract it wherever you wanna install
4. Add the path of the directory where you installed it to PATH values(optional)
5. Finally you can use plpm. Hooray!

### Build from source code

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
