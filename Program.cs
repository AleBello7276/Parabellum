
using Parabellum;
using Parabellum.Scene;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Program
{

    public static float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f,  0.5f, 0.0f  //Top vertex
        };

        static float[] cube = {
            -0.5f, -0.5f, -0.5f, 
            0.5f, -0.5f, -0.5f, 
            0.5f,  0.5f, -0.5f, 
            0.5f,  0.5f, -0.5f, 
            -0.5f,  0.5f, -0.5f, 
            -0.5f, -0.5f, -0.5f, 

            -0.5f, -0.5f,  0.5f, 
            0.5f, -0.5f,  0.5f, 
            0.5f,  0.5f,  0.5f, 
            0.5f,  0.5f,  0.5f, 
            -0.5f,  0.5f,  0.5f, 
            -0.5f, -0.5f,  0.5f, 

            -0.5f,  0.5f,  0.5f, 
            -0.5f,  0.5f, -0.5f, 
            -0.5f, -0.5f, -0.5f, 
            -0.5f, -0.5f, -0.5f, 
            -0.5f, -0.5f,  0.5f, 
            -0.5f,  0.5f,  0.5f, 

            0.5f,  0.5f,  0.5f, 
            0.5f,  0.5f, -0.5f, 
            0.5f, -0.5f, -0.5f, 
            0.5f, -0.5f, -0.5f, 
            0.5f, -0.5f,  0.5f, 
            0.5f,  0.5f,  0.5f, 

            -0.5f, -0.5f, -0.5f, 
            0.5f, -0.5f, -0.5f, 
            0.5f, -0.5f,  0.5f, 
            0.5f, -0.5f,  0.5f, 
            -0.5f, -0.5f,  0.5f, 
            -0.5f, -0.5f, -0.5f, 

            -0.5f,  0.5f, -0.5f, 
            0.5f,  0.5f, -0.5f, 
            0.5f,  0.5f,  0.5f, 
            0.5f,  0.5f,  0.5f, 
            -0.5f,  0.5f,  0.5f, 
            -0.5f,  0.5f, -0.5f
        };


    public static void Main(string[] args)
    {
        Scene mainScene = new Scene();

        //TestTriangle
        MeshRenderer mesh1 = new MeshRenderer();
        Shader tdShad = new Shader("Engine/BaseShaders/3dshader.vert", "Engine/BaseShaders/3dshader.frag");
        Local loc1 = new Local(0.0f, 0.0f, -5.0f, 0, 0, 0);
        mesh1._shader = tdShad;
        mesh1.loadMeshRaw(cube);

    

        TriangleObject obj1 = new TriangleObject();
        obj1.local = loc1;
        obj1.addComponent(loc1);
        obj1.addComponent(tdShad);
        obj1.addComponent(mesh1);



       
        
        Local playerLoc = new Local(0.0f, 0.0f, 30.0f, 0, 0, 0);
        Camera playerCam = new Camera(new Vector3(playerLoc.x, playerLoc.y, playerLoc.z), 800/600);

    

        PlayerObject obj2 = new PlayerObject();
        obj2.local = playerLoc;
        obj2.addComponent(playerLoc);
        obj2.addComponent(playerCam);


        mainScene.addObject(obj1);
        mainScene.addObject(obj2);

        Bell.currentScene = mainScene;

        using (Bell theBell = new Bell(800, 600, "Bell"))
        {
            theBell.Run();
        }
    }
}