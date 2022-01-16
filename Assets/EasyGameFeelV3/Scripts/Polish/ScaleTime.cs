using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTime : MonoBehaviour
{
    public float ScaleTimeLength
    {
        get
        {
            return scaleTimeLength;
        }
        set
        {
            scaleTimeLength = value;
        }
    }
    public float ScaleTimeTo
    {
        get
        {
            return scaleTimeTo;
        }
        set
        {
            scaleTimeTo = value;
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
    ///Determina por cuánto tiempo se escalará el tiempo del juego.
    ///</summary>
    [SerializeField]
    private float scaleTimeLength;
    ///<summary>
    ///Determina a que se escalara el tiempo del juego.
    ///</summary>
    [SerializeField]
    private float scaleTimeTo;
    ///<summary>
    ///Determina si el elemento puede realizar su funcionalidad, si puede escalar el tiempo.
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
    ///Escala el tiempo del juego por una cantidad de tiempo indicada por scaleTimeLength, 
    ///despues de que el tiempo indicado por scaleTimeLength pasa, la escala de tiepo vuelve a ser 1.
    ///</summary>
    private IEnumerator StopGame()
    {
        Time.timeScale = scaleTimeTo;
        yield return new WaitForSecondsRealtime(scaleTimeLength);
        active = false;
        Time.timeScale = 1;
        canCallCoroutine = true;
    }
}
