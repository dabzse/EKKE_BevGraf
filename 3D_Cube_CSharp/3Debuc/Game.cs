using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace OpenTk_kocka
{
    public class Game
    {
        private readonly GameWindow window;
        private double theta = 0.0;
        private int shaderProgram;
        private int vertexArrayObject;

        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }

        void Start()
        {
            window.Load += Loaded;
            window.Resize += Resize;
            window.RenderFrame += RenderFrame;
            window.Run(1.0 / 60.0);
        }

        void Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
        }

        void RenderFrame(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(shaderProgram);

            GL.BindVertexArray(vertexArrayObject);

            Matrix4 rotationX = Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(theta));
            Matrix4 rotationXZ = Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(theta));
            Matrix4 model = rotationX * rotationXZ; // Forgások kombinálása
            Matrix4 view = Matrix4.LookAt(new Vector3(0, 33, 50), Vector3.Zero, Vector3.UnitY);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)MathHelper.DegreesToRadians(45), window.Width / (float)window.Height, 0.1f, 100.0f);

            int modelLocation = GL.GetUniformLocation(shaderProgram, "model");
            int viewLocation = GL.GetUniformLocation(shaderProgram, "view");
            int projectionLocation = GL.GetUniformLocation(shaderProgram, "projection");

            GL.UniformMatrix4(modelLocation, false, ref model);
            GL.UniformMatrix4(viewLocation, false, ref view);
            GL.UniformMatrix4(projectionLocation, false, ref projection);

            
            GL.DrawArrays(PrimitiveType.Quads, 0, 24);

            window.SwapBuffers();

            theta += 1.0;    
            if (theta > 360)
                theta -= 360;
        }


        void Loaded(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            string vertexShaderSource = @"
                #version 330 core
                layout(location = 0) in vec3 aPosition;
                layout(location = 1) in vec3 aColor;
                out vec3 vertexColor;
                uniform mat4 model;
                uniform mat4 view;
                uniform mat4 projection;
                void main()
                {
                    gl_Position = projection * view * model * vec4(aPosition, 1.0);
                    vertexColor = aColor;
                }
            ";
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            string fragmentShaderSource = @"
                #version 330 core
                in vec3 vertexColor;
                out vec4 FragColor;
                void main()
                {
                    FragColor = vec4(vertexColor, 1.0);
                }
            ";
            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            
            shaderProgram = GL.CreateProgram();
            GL.AttachShader(shaderProgram, vertexShader);
            GL.AttachShader(shaderProgram, fragmentShader);
            GL.LinkProgram(shaderProgram);

            
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            
            float[] vertices = {
                
                -10.0f,  10.0f,  10.0f,  1.0f, 0.0f, 0.0f,
                -10.0f,  10.0f, -10.0f,  0.0f, 1.0f, 0.0f,
                -10.0f, -10.0f, -10.0f,  0.0f, 1.0f, 1.0f,
                -10.0f, -10.0f,  10.0f,  1.0f, 1.0f, 0.0f,

                10.0f,  10.0f,  10.0f,  1.0f, 0.0f, 1.0f,
                10.0f,  10.0f, -10.0f,  1.0f, 0.0f, 1.0f,
                10.0f, -10.0f, -10.0f,  1.0f, 0.0f, 1.0f,
                10.0f, -10.0f,  10.0f,  1.0f, 0.0f, 1.0f,

                10.0f, -10.0f,  10.0f,  0.0f, 1.0f, 1.0f,
                10.0f, -10.0f, -10.0f,  0.0f, 1.0f, 1.0f,
                -10.0f, -10.0f, -10.0f,  0.0f, 1.0f, 1.0f,
                -10.0f, -10.0f,  10.0f,  0.0f, 1.0f, 1.0f,

                10.0f,  10.0f,  10.0f,  1.0f, 0.0f, 0.0f,
                10.0f,  10.0f, -10.0f,  1.0f, 0.0f, 0.0f,
                -10.0f,  10.0f, -10.0f,  1.0f, 0.0f, 0.0f,
                -10.0f,  10.0f,  10.0f,  1.0f, 0.0f, 0.0f,

                10.0f,  10.0f, -10.0f,  0.0f, 1.0f, 0.0f,
                10.0f, -10.0f, -10.0f,  0.0f, 1.0f, 0.0f,
                -10.0f, -10.0f, -10.0f,  0.0f, 1.0f, 0.0f,
                -10.0f,  10.0f, -10.0f,  0.0f, 1.0f, 0.0f,

                10.0f,  10.0f,  10.0f,  0.0f, 0.0f, 1.0f,
                10.0f, -10.0f,  10.0f,  0.0f, 0.0f, 1.0f,
                -10.0f, -10.0f,  10.0f,  0.0f, 0.0f, 1.0f,
                -10.0f,  10.0f,  10.0f,  0.0f, 0.0f, 1.0f
            };

            
            vertexArrayObject = GL.GenVertexArray();
            int vertexBufferObject = GL.GenBuffer();

            
            GL.BindVertexArray(vertexArrayObject);

            
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                handle.Free();
            }

            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }
    }
}
