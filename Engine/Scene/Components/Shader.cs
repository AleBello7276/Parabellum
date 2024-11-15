using Parabellum.Renderer;
using Parabellum.Shaders;

namespace Parabellum.Scene
{
    public class Shader : Component
    {
        public BaseShader baseShader;

        public Shader() {   }

        public string vertPath, fragPath; 
        public Shader(string _vertPath, string _fragPath)
        {
            vertPath = _vertPath;
            fragPath = _fragPath;
        }

        public void loadShader(string vertPath, string fragPath)
        {
            baseShader = new BaseShader(vertPath, fragPath);
        }

    }
}