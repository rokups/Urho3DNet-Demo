
add_executable(MonoHost WIN32 MonoHost.cpp)

target_include_directories(MonoHost PRIVATE ${MONO_INCLUDE_DIRS})
target_link_libraries(MonoHost Urho3D Urho3DCSharp ${MONO_LIBRARIES})
target_compile_options(MonoHost PRIVATE ${MONO_CFLAGS})
add_dependencies(MonoHost Urho3DNet)
