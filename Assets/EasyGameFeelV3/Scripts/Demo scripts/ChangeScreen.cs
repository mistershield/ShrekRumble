using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este codigo solo existe para provar el elemento ScreenChangeAcordingToHP. El script es activado con la tecla "E".
/// </summary>
public class ChangeScreen : MonoBehaviour
{
    public ScreenChangeAcordingToHP changeAcordingToHP;
    
    private int x = 70;

    void Start()
    {
        changeAcordingToHP = FindObjectOfType<ScreenChangeAcordingToHP>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            x -= 20;
            changeAcordingToHP.ChangeStateImage(x);
        }
    }
}
