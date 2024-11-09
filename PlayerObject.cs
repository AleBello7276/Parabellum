using OpenTK.Mathematics;

namespace Parabellum.Scene
{
    public class PlayerObject : Object
    {

        
        public override void PreInit() { }

        public override void Init() 
        { 
            
            Logger.Log(" INIT \n");
        }


        public override void Update() 
        {
            Logger.Log(" UPDATE");
        }
    }
}