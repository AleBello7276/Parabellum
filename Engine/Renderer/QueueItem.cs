using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Parabellum.Scene;
using Parabellum.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Parabellum.Renderer
{
    public class QueueItem
    {
        public uint id = 0;
        public List<float> renderableMesh;
        public int renderingMode = -1;
        public PrimitiveType primitiveType = PrimitiveType.Triangles;
        public Shader shader;
        public Local local;
        public Camera cam;

        public int VertexArrayObject;
        int VertexBufferObject;

        public QueueItem()
        {
        }

        public QueueItem(List<float> _renderableMesh) { renderableMesh = _renderableMesh; }

        public void GenerateRenderBuffer()
        {
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, this.renderableMesh.Count * sizeof(float), renderableMesh.ToArray(), BufferUsageHint.StaticDraw);
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }
    }
}