@echo off
mkdir build
pushd build
cmake -G "Visual Studio 15 2017 Win64" -DLLVM_VERSION_EXPLICIT=5.0.1 -DLIBCLANG_LIBRARY="C:/LLVM/lib/libclang.lib" -DLIBCLANG_INCLUDE_DIR="C:/LLVM/include" -DLIBCLANG_SYSTEM_INCLUDE_DIR="C:/LLVM" -DCLANG_BINARY="C:/LLVM/bin/clang++.exe" ..
cmake --build . --target DemoApplication -- /maxcpucount:%NUMBER_OF_PROCESSORS%
popd
