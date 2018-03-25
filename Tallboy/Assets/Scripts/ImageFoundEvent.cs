using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFoundEvent : MonoBehaviour {

    public delegate void ImageFound();
    public static event ImageFound imageFound;

    static string Id;
    static string Text="";

    public static void OnEvent() {
        if(imageFound != null)
        {
            imageFound();
        }
    }

    public static string GetText()
    {
        return Text;
    }
    public static void SetText(string s)
    {
        Text = s;
    }

}
