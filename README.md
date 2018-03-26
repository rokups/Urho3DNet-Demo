Urho3DNet Demo
==============

This is a demo project of Urho3D .net bindings usage.

### Testing on Linux

1. Install `llvm` and `clang` packages. Names of packages may differ depending on your distribution.
2. Run `CMake.sh`
3. Run `mono build/bin/DemoApplication.exe`

### Testing on Windows

1. Install [prebuilt llvm/clang distribution](http://releases.llvm.org/5.0.1/LLVM-5.0.1-win64.exe) to `C:\Program Files\LLVM` (default path)
2. Run `CMake.bat` (VS2017 required)
3. Run `build/bin/Debug/DemoApplication.exe`

### Misc notes

If you are basing your project on this code note that `Urho3DNet.csproj` is completely not necessary and can be removed. This project exists in order to aid testing and debugging C# wrapper code.

You may use different LLVM version or install location. Do not forget to modify `CMake.bat` if you do.
