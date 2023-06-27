csharp-nunit-101
==

## Usage

This assumes you already have the **Dev Containers** extension installed in VSCode.

1. Start Docker (on a Mac: `open -a Docker`)
2. Open the project in Visual Studio Code (VS Code)
3. Click: **Reopen in Container**
4. Select: **View / Terminal** (may already be open)
5. In the VSCode Terminal window run this command:
```sh
dotnet run
```

## How this project was created:

1. Create a project folder and cd to it
2. Open the project in VS Code
3. Open the Command Palette (**Cmd+Shift+P** on a Mac)
4. Type in **Dev Containers: Add Dev Container Configuration Files ...**
5. Select **C#** and go through the steps
6. Press **Reopen in Container** when prompted
7. Open up the VSCode Terminal window:  **View / Terminal** on a Mac
8. Create a new console project:
```sh
dotnet new console
```
9. Run the project:
```sh
dotnet run
```
10. Add a .gitignore file
```sh
dotnet new gitignore
```

## Install NUnit

See references for more info on how to install **NUnit**.

```sh
dotnet add package NUnit
```

To verify that it was install properly, inspect the *.csproj file for an entry like this:

```xml
  <ItemGroup>
    <PackageReference Include="NUnit" Version="3.13.3" />
  </ItemGroup>
```

## Add sln

```sh
dotnet new sln
```

## Add console project to solution

```sh
dotnet sln add ./csharp-nunit-101.csproj
```

## Make a library

```sh
dotnet new classlib -o DemoLibrary
mv DemoLibrary/Class1.cs DemoLibrary/DemoLibrary.cs
dotnet sln add DemoLibrary/DemoLibrary.csproj
```

* Edit **DemoLibrary/DemoLibrary.cs**
* Change the code to this and save it:
```cs
/**
Reference: 
    https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit
*/

namespace DemoLibrary
{
    public class DemoLibrary
    {
        public bool IsOddNumber(int candidate)
        {
            throw new NotImplementedException("Please create a test first.");
        }
    }
}
```

## Create NUnit package

```sh
dotnet new nunit -o DemoLibrary.Tests
dotnet add DemoLibrary.Tests/DemoLibrary.Tests.csproj reference DemoLibrary/DemoLibrary.csproj
dotnet sln add DemoLibrary.Tests/DemoLibrary.Tests.csproj
```
* Change the file name:
```sh
mv DemoLibrary.Tests/UnitTest1.cs DemoLibrary.Tests/DemoLibrary_IsOddShould.cs
``
* Edit **DemoLibrary.Tests/DemoLibrary_IsOddShould.cs**:
* Replace the contents with the code below and save it:
```cs
using NUnit.Framework;
using DemoLibrary;

namespace DemoLibrary.UnitTests.Services
{
    [TestFixture]
    public class DemoLibrary_IsOddhould
    {
        private DemoLibrary? _demoService;

        [SetUp]
        public void SetUp()
        {
            _demoService = new DemoLibrary();
        }

        [Test]
        public void IsOdd_InputIs1_ReturnTrue()
        {
            var result = _demoService?.IsOddNumber(1);

            Assert.IsTrue(result, "Value should be odd number");
        }
    }
}
```

## Run the tests

** *Note that this first run will fail on purpose!**

* Run this command:

```sh
dotnet test
```

** Note the failure, because of this line:

```cs
throw new NotImplementedException("Please create a test first.");
```

To fix that:
* Open **DemoLibray/DemoLibray.cs**
* Change the contents to the code below and save it the file:
```cs
namespace DemoLibrary
{
    public class DemoLibrary
    {
        public bool IsOddNumber(int candidate)
        {
            // throw new NotImplementedException("Please create a test first.");

            return candidate % 2 != 0;
        }
    }
}
```
* Run the test again:
```sh
dotnet test
```
* Verify everything passed

* * *

## References

* [Unit testing C# with NUnit and .NET Core](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit)
* [NuGet in Visual Studio Code](https://code.visualstudio.com/docs/csharp/package-management)
* [Install and manage NuGet packages with the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli)
* [Installation | NUnit Docs ](https://docs.nunit.org/articles/nunit/getting-started/installation.html)
* [How to use Microsoft Dev Containers (Visual Studio Code, Python)](https://scriptable.com/how-to-use-microsoft-dev-containers-python/)
* [How to Install Dotnet on a Mac (.NET, CSharp)](https://scriptable.com/how-to-install-dotnet-on-a-mac/)
* [.NET Core - When to use "dotnet new sln"](https://stackoverflow.com/questions/42730877/net-core-when-to-use-dotnet-new-sln)
* [Tutorial: Create a .NET class library using Visual Studio Code](https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio-code?pivots=dotnet-7-0)

