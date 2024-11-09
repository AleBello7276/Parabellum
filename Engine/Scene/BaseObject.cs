namespace Bellunity.Scene
{
    public abstract class BaseObject
    {
        public uint id;
        public Dictionary<uint, Component> components = new Dictionary<uint, Component>();
        // Called before even before Init()
        public abstract void PreInit();

        // Called a single time when the Object is first loaded
        // in the scene before Every Update
        public abstract void Init();

        public abstract void Update();
    }
}