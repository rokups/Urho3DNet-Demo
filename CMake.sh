#!/usr/bin/env sh
mkdir build
pushd build
cmake ..
cmake --build . --target DemoApplication -- -j$(nproc --all)
popd
