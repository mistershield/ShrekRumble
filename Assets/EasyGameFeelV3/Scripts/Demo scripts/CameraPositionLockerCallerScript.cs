using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este codigo solo existe para provar el elemento CameraPositionLocker. El script es activado con la tecla "E".
/// </summary>
public class CameraPositionLockerCallerScript : MonoBehaviour
{
    public CameraPositionLocker positionLocker;

    private int x = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (x > 2)
            {
                positionLocker.StopLockingCamera();
                x = 0;
            }
            else
            {
                positionLocker.LockeCamera(x, -10);
                x++;
            }
        }
    }
}
