using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private Texture2D blackTex;
    public float alpha = 1f;

    private void Awake()
    {
        blackTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        blackTex.SetPixel(0, 0, Color.black);
        blackTex.Apply();
    }

    void OnGUI()
    {
        alpha -= Time.deltaTime  / 2;
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTex);

        if (alpha <= 0f)
        {
            Destroy(this);
        } 
    }
}
