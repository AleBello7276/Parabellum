using Bellunity.Renderer;
using OpenTK.Mathematics;

namespace Bellunity.Scene
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