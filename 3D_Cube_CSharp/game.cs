﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.ES20;

namespace OpenTk_tut
{
    public class Game
    {
        double theta = 0.0,
        GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }
        void Start()
        {
            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60.0);
        }
        void resize(object ob, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50.0, 50.0, -50.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);

        }


        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Rotate(theta, 0.0, 0.0, 1.0);
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(30.0, 30.0);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(-30.0, 30.0);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(-30.0, -30.0);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex2(30.0, -30.0);

            GL.End();
            window.SwapBuffers();

            theta += 1.0;
            if (theta > 360)
                theta -= 360;
        }
        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
