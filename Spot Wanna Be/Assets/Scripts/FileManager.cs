using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AnotherFileBrowser.Windows;
using UnityEngine.Networking;
using System;

public class FileManager : MonoBehaviour
{
    public RawImage rawImage;
    public GameObject Object;
    Texture texture;
    Renderer rend;
    Color newColor = new Color (1, 1, 1, 1);

    private void Start() {
        rend = Object.GetComponent<Renderer>();
    }

    public void OpenFileBrowser() {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.jpg, *.jpeg, *jfif, *.png) | *.jpg; *.jpeg; *jfif; *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path => {
            StartCoroutine(LoadImage(path));
        });

    }

    IEnumerator LoadImage(string path) {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                //rawImage.texture = uwrTexture;
                rend.material.mainTexture = uwrTexture;
                rend.material.color = newColor;
            }
        }
    }
}
