using Parabellum.Renderer;

namespace Parabellum.Scene
{
    public class MeshRenderer : Component
    {
        public List<float> verts = new List<float>();

        public Shader _shader;

        public void loadMeshRaw(float[] mesh)
        {
            this.verts.AddRange(mesh);
        }

        // adds the mesh to the rendering Queue
        public void renderMesh(QueueItem item)
        {
            GlobalRenderer.addItemToQueue(item);
        }
    }
}