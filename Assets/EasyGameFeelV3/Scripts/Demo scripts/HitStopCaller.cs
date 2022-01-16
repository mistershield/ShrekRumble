using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este codigo solo existe para provar el elemento HitStop. El script es activado con la tecla "E".
/// </summary>
public class HitStopCaller : MonoBehaviour
{
    public HitStop hitStop;

    private void Start()
    {
        hitStop = FindObjectOfType<HitStop>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            hitStop.Active = true;
        }
    }
}
