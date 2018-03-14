﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime;
using Urho3D;

namespace DemoApplication
{
    class RotateObject : LogicComponent
    {
        public RotateObject(Context context) : base(context)
        {
            SetUpdateEventMask(USE_UPDATE);
        }

        public override void Update(float timeStep)
        {
            var d = new Quaternion(10 * timeStep, 20 * timeStep, 30 * timeStep);
            Node.Rotate(d);
        }
    }

    class DemoApplication : Application
    {
        private Scene scene_;
        private Viewport viewport_;
        private Node camera_;
        private Node cube_;
        private Node light_;

        public DemoApplication(Context context) : base(context)
        {
        }

        public override void Setup()
        {
            engineParameters_[EngineDefs.EP_FULL_SCREEN] = false;
            engineParameters_[EngineDefs.EP_WINDOW_WIDTH] = 1920;
            engineParameters_[EngineDefs.EP_WINDOW_HEIGHT] = 1080;
            engineParameters_[EngineDefs.EP_WINDOW_TITLE] = "Hello C#";
            engineParameters_[EngineDefs.EP_RESOURCE_PREFIX_PATHS] = Directory.GetCurrentDirectory();
        }

        public override void Start()
        {
            Input.SetMouseVisible(true);

            context_.RegisterFactory<RotateObject>();

            // Viewport
            scene_ = new Scene(context_);
            scene_.CreateComponent<Octree>();

            camera_ = scene_.CreateChild("Camera");
            viewport_ = new Viewport(context_, scene_, camera_.CreateComponent<Camera>());
            Renderer.SetViewport(0, viewport_);

            // Background
            Renderer.DefaultZone.SetFogColor(new Color(0.5f, 0.5f, 0.7f));

            // Scene
            camera_.SetPosition(new Vector3(0, 2, -2));
            camera_.LookAt(Vector3.ZERO);

            // Cube
            cube_ = scene_.CreateChild("Cube");
            var model = cube_.CreateComponent<StaticModel>();
            model.SetModel(Cache.GetResource<Model>("Models/Box.mdl"));
            model.SetMaterial(0, Cache.GetResource<Material>("Materials/Stone.xml"));
            cube_.CreateComponent<RotateObject>();

            // Light
            light_ = scene_.CreateChild("Light");
            light_.CreateComponent<Light>();
            light_.SetPosition(new Vector3(0, 2, -1));
            light_.LookAt(Vector3.ZERO);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new Context())
            {
                using (var application = new DemoApplication(context))
                    application.Run();
            }
        }
    }
}
