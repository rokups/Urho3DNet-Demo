cmake_minimum_required (VERSION 3.4.3)

# Name your project. Can be anything.
project (Urho3DNetDemo)

# Set binary output directories. Changing these paths will require you adjusting your resource path configuration!
set (CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set (CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set (CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)

# Include cloned engine directory in a build.
set (BUILD_SHARED_LIBS ON CACHE BOOLEAN "" FORCE)
set (URHO3D_ENABLE_ALL ON CACHE BOOLEAN "" FORCE)
set (URHO3D_SAMPLES OFF CACHE BOOLEAN "" FORCE)
set (CMAKE_CXX_STANDARD 11)
set (CMAKE_CXX_STANDARD_REQUIRED ON)
set (NFD_NO_GTK ON CACHE BOOLEAN "" FORCE)
add_subdirectory(dep/Urho3D)
add_subdirectory(dep/Urho3DNet)

if (URHO3D_CSHARP_MONO)
    add_subdirectory(MonoHost)
endif ()

find_program(MSBUILD msbuild)
if (NOT MSBUILD)
    find_program(MSBUILD xbuild)
    if (NOT MSBUILD)
        message(FATAL_ERROR "msbuild/xbuild not found.")
    endif ()
endif ()

add_custom_target(DemoApplication
    COMMAND ${MSBUILD} ${CMAKE_CURRENT_SOURCE_DIR}/DemoApplication.csproj
    DEPENDS Urho3DNet
)

get_target_property(SOURCE_DIR Urho3D SOURCE_DIR)
get_filename_component(SOURCE_DIR ${SOURCE_DIR} DIRECTORY)
csharp_bind_target(TARGET Urho3D SOURCE_DIR ${SOURCE_DIR} EXTERNAL)
