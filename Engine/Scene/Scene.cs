using Parabellum.Renderer;

namespace Parabellum.Scene
{
    public class Scene
    {
        public string Name { get; set;}
        private Dictionary<uint, Object> objects = new Dictionary<uint, Object>();

        public bool isLoaded = false;

        public void load()
        {
            initializeObjects();
        }

        public void UpdateScene()
        {
            //
            updateObjects();
        }

        private void initializeObjects()
        {
            foreach (Object obj in objects.Values)
            {
                obj.PreInit();

                obj.createItemQueue();

                foreach (Component comp in obj.components.Values)
                {
                    

                    if (comp is Shader)
                    {
                        ((Shader)comp).loadShader(((Shader)comp).vertPath, ((Shader)comp).fragPath);
                    }
                    
                    if (comp is MeshRenderer)
                    {
                        // Generate VBO and VAO for rendering
                        obj.item.GenerateRenderBuffer(); 
                    }
                }
                
            }

            foreach (BaseObject obj in objects.Values){
                obj.Init();
            }
        }


        private void updateObjects()
        {
            
            foreach (Object obj in objects.Values)
            {
                
                obj.Update();

                
                foreach (Component comp in obj.components.Values)
                {
                    if (comp is MeshRenderer)
                    {
                        MeshRenderer mesh = (MeshRenderer)comp;
                        mesh.renderMesh(obj.item);
                    }

                    if (comp is Camera)
                    {
                        ((Camera)comp).addItem(obj.item);
                    }

                }
            }
        }


        public void addObject(Object obj)
        {   
            Random random = new Random();

            // Generate random id for object
            obj.id = (uint)random.NextInt64(uint.MaxValue);

            // objcet ids can't be 0 - 2048 (Engine reserved ids)
            if (obj.id <= 2048){
                Logger.Warning("TRIED TO BOUND SCENE OBJECT TO RESERVED ID, GENERATING RANDOM ID");

                obj.id = (uint)random.NextInt64(2300, uint.MaxValue);
            }

            // Check if id is already bound
            if (objects.ContainsKey(obj.id))
            {
                Logger.Warning("TRIED TO BOUND SCENE OBJECT TO ALREADY BOUND ID, GENERATING NEW RANDOM ID");

                // keep generating new ids unitl is not in the list
                do
                {
                    obj.id = (uint)random.NextInt64(2300, uint.MaxValue);
                } while (objects.ContainsKey(obj.id));
            }
            
            // finally safely adds object to scene list
            this.objects.Add(obj.id, obj);
        }
    }
}