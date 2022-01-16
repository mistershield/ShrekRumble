using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListsForCustomWindow : MonoBehaviour
{
    //Seccion del codigo basado en: https://medium.com/nerd-for-tech/how-to-create-a-list-in-a-custom-editor-window-in-unity-e6856e78adfc
    [HideInInspector]
    public List<string> listString = new List<string>();
    [HideInInspector]
    public List<float> listFloat = new List<float>();
    [HideInInspector]
    public List<GameObject> gameObjectList = new List<GameObject>();
    [HideInInspector]
    public List<AudioClip> audioClipList = new List<AudioClip>();

    public void SetStringList(string text)
    {
        listString.Insert(0,text);
    }

    public void SetFloatList(float x, float y, float z)
    {
        listFloat.Insert(0, x);
        listFloat.Insert(1, y);
        listFloat.Insert(2, z);
    }

    public List<string> GetStringList()
    {
        return listString;
    }
    public List<float> GetFloatList()
    {
        return listFloat;
    }
    public List<GameObject> GetGameObjectList()
    {
        return gameObjectList;
    }
    public List<AudioClip> GetAudioClipList()
    {
        return audioClipList;
    }
}
