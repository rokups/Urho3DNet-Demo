#include <Urho3D/Urho3DAll.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/metadata.h>
#include <mono/metadata/mono-config.h>
#include <mono/metadata/mono-debug.h>
#include <mono/jit/jit.h>

extern "C" URHO3D_API void Urho3DRegisterMonoInternalCalls();

int MonoHostMain(int argc, char** argv)
{
    auto* applicationExe = "DemoApplication.exe";

    mono_config_parse(nullptr);
    mono_debug_init(MONO_DEBUG_FORMAT_MONO);
    const char* options[] = {
        // Enable debugger
        "--debugger-agent=transport=dt_socket,address=0.0.0.0:50000,server=y,suspend=y",
        "--optimize=float32"
    };
    mono_jit_parse_options(SDL_arraysize(options), (char**)options);


    MonoDomain *domain = mono_jit_init(applicationExe);
    mono_debug_domain_create(domain);
    MonoAssembly* assembly = mono_domain_assembly_open(domain, applicationExe);

    // Register mono internal calls.
    Urho3DRegisterMonoInternalCalls();

    // Execute application.
    mono_jit_exec(domain, assembly, argc, argv);
}

URHO3D_DEFINE_MAIN(MonoHostMain(argc, argv));
