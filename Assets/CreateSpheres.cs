using UnityEngine;
using System.Collections;

public class CreateSpheres : MonoBehaviour {

    public static int moveFrames = 80;
    public static int stayFrames = 20;
    int numX = 15;
    int numY = 10;
    int numZ = 30;

	// Use this for initialization
	void Start () {

        

        GameObject BUL = new GameObject("BUL");
        GameObject BDR = new GameObject("BDR");
        GameObject FUR = new GameObject("FUR");
        GameObject FDL = new GameObject("FDL");
        BUL.AddComponent<BUL>();
        BDR.AddComponent<BDR>();
        FUR.AddComponent<FUR>();
        FDL.AddComponent<FDL>();
        

        for (int x = -numX / 2; x <= numX / 2; x++)
        {
            for (int y = -numY / 2; y <= numY / 2; y++)
            {
                for (int z = -numZ / 2; z <= numZ / 2; z++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    
                    sphere.renderer.material.color = Color.black;
                    sphere.transform.localScale = Vector3.one * 0.05f;
                    sphere.transform.position = new Vector3(x + 0.5f, y + 0.5f, z + 0.5f);
                    
                    if (x % 2 == 0) {
                        if (z % 2 == 0)
                        {
                            sphere.transform.parent = BUL.transform;
                        }
                        else
                        {
                            sphere.transform.parent = BDR.transform;
                        }
                    }
                    else
                    {
                        if (z % 2 == 0)
                        {
                            sphere.transform.parent = FDL.transform;
                        }
                        else
                        {
                            
                            sphere.transform.parent = FUR.transform;
                        }
                    }
                }
            }
        }
        BUL.transform.localScale = Vector3.one * 1f;
        BDR.transform.localScale = Vector3.one * 1f;
        FUR.transform.localScale = Vector3.one * 1f;
        FDL.transform.localScale = Vector3.one * 1f;
	}
}
