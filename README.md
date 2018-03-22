Urho3DNet Demo
==============

This is a demo project of Urho3D .net bindings usage.

### Testing on Linux

1. Install `llvm` and `clang` packages. Names of packages may differ depending on your distribution.
2. Run `CMake.sh`
3. Run `mono build/bin/DemoApplication.exe`

### Testing on Windows

1. Install [prebuilt llvm/clang distribution](http://releases.llvm.org/5.0.1/LLVM-5.0.1-win64.exe) to `C:\LLVM`
2. Open "Developer Command Prompt for VS 2017". Opening wrong command prompt may result in failure to find C# compiler.
3. Run `CMake.bat`
4. Run `build/bin/Debug/DemoApplication.exe`

### Misc notes

If you are basing your project on this code note that `Urho3DNet.csproj` is completely not necessary and can be removed. This project exists in order to aid testing and debugging C# wrapper code.

You may use different LLVM version or install location. Do not forget to modify `CMake.bat` if you do.
