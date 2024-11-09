using Bellunity.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Bellunity.Renderer
{
    public static class GlobalRenderer
    {
        private static Dictionary<uint, QueueItem>? renderQueue = new Dictionary<uint, QueueItem>();

        private static float de = 0.0f;
        public static void flushQueue()
        {
            foreach (QueueItem item in renderQueue.Values)
            {
                de += 0.0001f;
                Matrix4 model = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(de));
                
                Matrix4 view = Matrix4.CreateTranslation(item.local.x, item.local.y, item.local.z);
                Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 800 / 600, 0.1f, 100.0f);
                
                Logger.Log("1 sadasdsda");
                Logger.Log(item.cam.GetType().ToString() + " sadasdsda");

                item.shader.baseShader.SetMatrix4("model", model);
                item.shader.baseShader.SetMatrix4("view", item.cam.GetViewMatrix());
                item.shader.baseShader.SetMatrix4("projection", item.cam.GetProjectionMatrix());

                item.shader.baseShader.Use();

                GL.BindVertexArray(item.VertexArrayObject);
                GL.DrawArrays(item.primitiveType, 0, 36);
            }
        }

        


        public static void addItemToQueue(QueueItem item)
        {   
            Random random = new Random();

            // Generate random id for object
            item.id = (uint)random.NextInt64(uint.MaxValue);

            // objcet ids can't be 0 - 2048 (Engine reserved ids)
            if (item.id <= 2048){
                Logger.Warning("Renderer: RESERVED ID, GENERATING RANDOM ID");

                item.id = (uint)random.NextInt64(2300, uint.MaxValue);
            }

            // Check if id is already bound
            if (renderQueue.ContainsKey(item.id))
            {
                Logger.Warning("Renderer: ID ALREADY BOUND ID, GENERATING NEW RANDOM ID");

                // keep generating new ids unitl is not in the list
                do
                {
                    item.id = (uint)random.NextInt64(2300, uint.MaxValue);
                } while (renderQueue.ContainsKey(item.id));
            }

            renderQueue.Add(item.id, item);
        }
    }
}