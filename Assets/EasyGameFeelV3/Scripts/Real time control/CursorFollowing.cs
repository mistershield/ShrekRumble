using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollowing : MonoBehaviour
{
    public Camera ReferenceCamera
    {
        get
        {
            return referenceCamera;
        }
        set
        {
            referenceCamera = value;
        }
    }
    ///<summary>
    ///Se utiliza para determinar la posición del cursor dentro del mundo del juego. 
    ///Se recomienda que esta cámara no sea hija del objeto con el elemento de Cursor Following.
    ///</summary>
    [SerializeField]
    private Camera referenceCamera;

    ///<summary>
    ///Rota el objeto de forma que apunte al cursor.
    ///Este codigo fue sacado de https://nickhwang.com/2020/04/16/unity-tutorial-quick-tip-2d-look-at-mouse/
    ///</summary>
    private void FixedUpdate()
    {
        var dir = Input.mousePosition - referenceCamera.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
