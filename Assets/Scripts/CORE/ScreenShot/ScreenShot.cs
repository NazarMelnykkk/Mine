using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public string FileName;
    public RenderTexture RT;
    public GameObject RenderCamera;
    public byte[] Texture;

    private bool saving = false;

    public void SaveImage()
    {
        if (saving == true)
        {
            return;
        }
        saving = true;

        Texture2D currentTexture = new Texture2D(RT.width, RT.height, TextureFormat.ARGB32, false);
        RenderTexture.active = RT;
        //texture2D.isReadable = true;
        currentTexture.ReadPixels(new Rect(0, 0, RT.width, RT.height), 0, 0);
        currentTexture.Apply();

        /*        string dateString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                LastPath = Path.Combine(Application.persistentDataPath, $"{FileName}_{dateString}.bmp");*/

        Texture = currentTexture.EncodeToPNG();
        // File.WriteAllBytes(LastPath, bytes);

        //Debug.Log("save image path: " + LastPath);

        saving = false;

    }

    public byte[] GetImageBytes()
    {
        return Texture;
    }

    private IEnumerator RenderProcess()
    {
        RenderCamera.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        SaveImage();
        RenderCamera.SetActive(false);
    }

    public void GetSetImage_btn()
    {
        SaveImage();
        //StartCoroutine(RenderProcess());
    }
}
