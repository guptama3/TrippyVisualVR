using UnityEngine;
using System.Collections;

public class CreateSpheres : MonoBehaviour {

    public static float moveFrames = 1.25f;
    public static float stayFrames = 0.20f;
    int numX = 15;
    int numY = 10;
    int numZ = 30;
    GameObject BUL;
    GameObject BDR;
    GameObject FUR;
    GameObject FDL;

    GameObject Cam;
    GameObject CenterAnchor;

    float Scale = 1.0f;

	// Use this for initialization
	void Start () {
        Cam = GameObject.Find("OVRCameraRig");
        CenterAnchor = GameObject.Find("CenterEyeAnchor");

        BUL = new GameObject("BUL");
        BDR = new GameObject("BDR");
        FUR = new GameObject("FUR");
        FDL = new GameObject("FDL");
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
        setScale(Scale);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Scale = Scale * 0.9f;
            setScale(Scale);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Scale = Scale * 1.1f;
            setScale(Scale);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Cam.transform.position = Cam.transform.position + CenterAnchor.transform.forward.normalized * Time.deltaTime * 3f * Scale;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Cam.transform.position = Cam.transform.position - CenterAnchor.transform.forward.normalized * Time.deltaTime * 3f * Scale;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Cam.transform.position = Cam.transform.position + CenterAnchor.transform.right.normalized * Time.deltaTime * 3f * Scale;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Cam.transform.position = Cam.transform.position - CenterAnchor.transform.right.normalized * Time.deltaTime * 3f * Scale;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            OVRManager.display.RecenterPose();
        }
    }

    private void setScale(float scale){
        BUL.SendMessage("OnReset");
        BDR.SendMessage("OnReset");
        FUR.SendMessage("OnReset");
        FDL.SendMessage("OnReset");
        BUL.transform.localScale = Vector3.one * scale;
        BDR.transform.localScale = Vector3.one * scale;
        FUR.transform.localScale = Vector3.one * scale;
        FDL.transform.localScale = Vector3.one * scale;
    }
}
