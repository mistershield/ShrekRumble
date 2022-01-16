using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///El numero de elementos dentro de HpValues deveria de ser el mismo que en stateImageList y stateSoundList
///</summary>
public class ScreenChangeAcordingToHP : MonoBehaviour
{
    public List<float> HpValues
    {
        get
        {
            return hpValues;
        }
        set
        {
            hpValues = value;
        }
    }
    public List<GameObject> StateImageList
    {
        get
        {
            return stateImageList;
        }
        set
        {
            stateImageList = value;
        }
    }
    public List<AudioClip> StateSoundList
    {
        get
        {
            return stateSoundList;
        }
        set
        {
            stateSoundList = value;
        }
    }
    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
        set
        {
            audioSource = value;
        }
    }

    ///<summary>
    ///Esta es una lista de FLOTANTES los cuales determinan cuando cambiará el estado de la pantalla.
    ///</summary>
    [SerializeField]
    private List<float> hpValues = new List<float>();
    ///<summary>
    ///Esta es una lista de GameObjects los cuales corresponden a un estado de la pantalla, estos son superpuestos en la pantalla y son iniciados como desactivados. 
    ///Estos objetos serán activados de acuerdo al estado de la pantalla. Para evitar errores se recomienda que el tamaño de esta lista sea igual al de Hp Values.
    ///</summary>
    [SerializeField]
    private List<GameObject> stateImageList = new List<GameObject>();
    ///<summary>
    ///Esta es una lista de AUDIOCLIPS los cuales se reproducen de acuerdo al estado de la pantalla. 
    ///Para evitar errores se recomienda que el tamaño de esta lista sea igual al de Hp Values.
    ///</summary>
    [SerializeField]
    private List<AudioClip> stateSoundList = new List<AudioClip>();
    ///<summary>
    ///El AudioSource del objeto.
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;

    ///<summary>
    ///La imagen de estado activa actual.
    ///</summary>
    private GameObject currentImage;

    ///<summary>
    ///Desactiva todas las imagenes dentro de stateImageList y inicializa currentImage como la imagen en el indice 0 de stateImageList.
    ///</summary>
    private void Start()
    {
        foreach(GameObject image in stateImageList)
        {
            image.SetActive(false);
        }
        currentImage = stateImageList[0];
    }
    ///<summary>
    ///Determina el estado actual de la pantalla, Cambia la imagen acual y reproduce el sonido de estado dependiendi del estado actual de la pantalla.
    ///Cuando se pide cambiar el estado al enviar una variable numérica x esta es comparada con los valores de la lista,
    ///si x es menor a uno de los valores de la lista, el estado de la pantalla cambia a ser el estado indicado por el indice del ultimo valor comparado con x, 
    ///osease si x es igual a 7 y la lista es [20, 10, 5], el estado de la pantalla sera el estado en la pocicion 1 
    ///(se cambiara a la imagen en el indice 1 de stateImageList y se reproducira el sonido en el indice 1 en stateSoundList).
    ///se para de comparar valores cuando x es mayor al valor de la lista con el que se está comparando.
    ///</summary>
    ///<param name="hp">
    ///La vida actual del jugador.
    ///</param>
    public void ChangeStateImage(float hp)
    {
        int hpValueIndex = -1;
        foreach (float hpValue in hpValues)
        {
            if(hpValue >= hp)
            {
                hpValueIndex = hpValues.IndexOf(hpValue);
            }
            if(hpValue < hp)
            {
                break;
            }
        }
        if (hpValueIndex == -1)
        {
            currentImage.SetActive(false);
        }
        else if (hpValueIndex != stateImageList.IndexOf(currentImage) || !currentImage.activeSelf && stateImageList.IndexOf(currentImage) == hpValueIndex)
        {
            currentImage.SetActive(false);
            currentImage = stateImageList[hpValueIndex];
            if (audioSource.clip)
            {
                audioSource.Stop();
                audioSource.clip = stateSoundList[hpValueIndex];
                audioSource.Play();
            }
            currentImage.SetActive(true);
        }
    }
}
