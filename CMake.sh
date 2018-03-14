#!/usr/bin/env sh
mkdir build
cd build
cmake ..
cmake --build . --target Urho3DNet -- -j$(nproc --all)
