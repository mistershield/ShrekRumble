using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    public float StopLength
    {
        get
        {
            return stopLength;
        }
        set
        {
            stopLength = value;
        }
    }
    public bool Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }

    ///<summary>
    ///Determina por cuánto tiempo se parara el tiempo del juego.
    ///</summary>
    [SerializeField]
    private float stopLength;
    ///<summary>
    ///Determina si el elemento puede realizar su funcionalidad, si puede parar el tiempo.
    ///</summary>
    [SerializeField]
    private bool active = false;

    ///<summary>
    ///Indica si se puede llamara StopGame
    ///</summary>
    private bool canCallCoroutine = true;

    ///<summary>
    ///Llama a StopGame si active y canCallCoroutine son verdaderos.
    ///</summary>
    private void Update()
    {
        if (active && canCallCoroutine)
        {
            canCallCoroutine = false;
            StartCoroutine(StopGame());
        }
    }
    ///<summary>
    ///Detiene el juego por una cantidad de tiempo indicada por stopLength, despues de que el tiempo indicado por stopLength pasa,
    ///la escala de tiepo vuelve a ser 1.
    ///</summary>
    private IEnumerator StopGame()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(stopLength);
        active = false;
        Time.timeScale = 1;
        canCallCoroutine = true;
    }
}
