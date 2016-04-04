using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CapturePhotoScene : MonoBehaviour {

    private bool takeHiResShot = false;
    public GameObject cam;
    string filename;
 //   public GameObject background;
 //   public Text info;


    public void TakeHiResShot()
    {
        takeHiResShot = true;

    }
    void LateUpdate()
    {
//        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(4);
        if (takeHiResShot)
        {
            RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
            cam.GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            cam.GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            screenShot.Apply();

            PromoView.instance.photo = screenShot;
 //           background.SetActive(true);
 //           background.GetComponent<MeshRenderer>().material.mainTexture = screenShot;
 //           background.GetComponent<MeshRenderer>().material.shader = Shader.Find("Sprites/Default");

            cam.GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);

 //           info.text = "DONE";
            //byte[] bytes = screenShot.EncodeToPNG();
            //filename = ScreenShotName(Screen.width, Screen.height);
            //System.IO.File.WriteAllBytes(filename, bytes);
            //Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
            Debug.Log("Selfie Shot");
            SceneManager.LoadScene(2);
        }
    }

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screen_{1}x{2}_{3}.png",
                             Application.persistentDataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
