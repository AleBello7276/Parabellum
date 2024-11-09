using OpenTK.Mathematics;

namespace Bellunity.Scene
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