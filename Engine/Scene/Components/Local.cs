namespace Bellunity.Scene
{
    public class Local : Component
    {
        public float x;
        public float y;
        public float z;  // Ignored or used for Layer order rendering if using 2D


        // rotation uses short so we have 65535 angles of precision it should 
        // be enough floats are just too much un needed precision for rotation
        // this short value is converted to floating point value in BellMath and sent to GPU
        // for rendering or other shit
        public short pitch;
        public short yaw;
        public short roll;


        public Local(float _x, float _y, float _z, short _pitch, short _yaw, short _roll)
        { 
            x = _x;
            y = _y;
            z = _z;
            pitch = _pitch;
            yaw = _yaw;
            roll = _roll;
        } 
    }
}