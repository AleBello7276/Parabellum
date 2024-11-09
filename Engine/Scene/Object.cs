using Parabellum.Renderer;

namespace Parabellum.Scene
{
    public class Object : BaseObject
    {
        public Local? local;
        public QueueItem? item;
        public Shader? _shader;
        public Camera? camera;

        // Called before even before Init()
        public override void PreInit() { }

        // Called a single time when the Object is first loaded
        // in the scene before Every Update
        public override void Init() { }

        public override void Update() { }

        public void createItemQueue()
        {
            item = new QueueItem();

            foreach (Component comp in components.Values)
            {   
                if (comp is MeshRenderer)
                {
                    this.item.renderableMesh = ((MeshRenderer)comp).verts;
                    this.item.shader = ((MeshRenderer)comp)._shader;
                }

               
                this.item.local = this.local;

                if (comp is Camera)
                {
                    this.item.cam = camera;

                    //Logger.Log(item.cam.GetType().ToString() + " sda");
                    //Logger.Log(((Camera)comp).GetType().ToString());
                }
                    
                
            }

        }

        public void addComponent(Component comp)
        {   
            Random random = new Random();

            // Generate random id for object
            comp.id = (uint)random.NextInt64(uint.MaxValue);

            // objcet ids can't be 0 - 2048 (Engine reserved ids)
            if (comp.id <= 2048){
                Logger.Warning("TRIED TO BOUND SCENE OBJECT TO RESERVED ID, GENERATING RANDOM ID");

                comp.id = (uint)random.NextInt64(2300, uint.MaxValue);
            }

            // Check if id is already bound
            if (components.ContainsKey(comp.id))
            {
                Logger.Warning("TRIED TO BOUND SCENE OBJECT TO ALREADY BOUND ID, GENERATING NEW RANDOM ID");

                // keep generating new ids unitl is not in the list
                do
                {
                    comp.id = (uint)random.NextInt64(2300, uint.MaxValue);
                } while (components.ContainsKey(comp.id));
            }

            Logger.Log(comp.GetType().ToString()+ "  " + comp.id);
            // finally safely adds object to scene list
            this.components.Add(comp.id, comp);
        }
    }
}