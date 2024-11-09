using Parabellum.Renderer;
using OpenTK.Mathematics;

namespace Parabellum.Scene
{
    public class Camera : BaseCamera
    {
        short pitch;
        short yaw;
        short roll;

        public Camera(Vector3 position, float aspectRatio) : base(position, aspectRatio)
        {
        }

        public void addItem(QueueItem item )
        {
            GlobalRenderer.addItemToQueue(item);
        }
    }
}