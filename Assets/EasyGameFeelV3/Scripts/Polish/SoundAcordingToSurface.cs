using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAcordingToSurface : MonoBehaviour
{
    public List<string> CanPlayAudioTags
    {
        get
        {
            return canPlayAudioTags;
        }
        set
        {
            canPlayAudioTags = value;
        }
    }
    public float ExtraAudioLength
    {
        get
        {
            return extraAudioLength;
        }
        set
        {
            extraAudioLength = value;
        }
    }
    public AudioClip CollisionSound
    {
        get
        {
            return collisionSound;
        }
        set
        {
            collisionSound = value;
        }
    }
    public AudioClip ExitCollisionSound
    {
        get
        {
            return exitCollisionSound;
        }
        set
        {
            exitCollisionSound = value;
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
    ///Esta es una lista de STRINGS que determina qué objetos pueden causar un sonido al colisionar con este elemento, 
    ///si el tag del objeto que colisionó con el elemento existe dentro de la lista, se reproducirá el sonido correspondiente.
    ///</summary>
    [SerializeField]
    private List<string> canPlayAudioTags = new List<string>();
    ///<summary>
    ///Determina cuánto tiempo extra, además de la longitud del clip de audio, debe de esperar el elemento para poder reproducir un sonido.
    ///</summary>
    [SerializeField]
    private float extraAudioLength = 0;
    ///<summary>
    ///Este es el AUDIOCLIP que se reproducirá cuando haya una colisión y/o se mantenga la colisión y el objeto que está colisionando se mueva. 
    ///Si se llegase a escuchar el audio sin que se moviese el objeto que colisiona con el elemento, intente acortar la duración del audio o alargarla.
    ///</summary>
    [SerializeField]
    private AudioClip collisionSound;
    ///<summary>
    ///Este es el AUDIOCLIP que se reproducirá cuando se termine una colisión.
    ///</summary>
    [SerializeField]
    private AudioClip exitCollisionSound;
    ///<summary>
    ///El AudioSource del objeto. 
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;

    ///<summary>
    ///Lista de objetos con los que el elemento tiene una colicion continua.
    ///</summary>
    private List<GameObject> objectList = new List<GameObject>();
    ///<summary>
    ///Lista de todos los objetos hijos del elemento que contienen el codigo SoundPlayer.
    ///</summary>
    private List<GameObject> sons = new List<GameObject>();

    ///<summary>
    ///Asigna un hijo al objeto que colisiono con el elemento, si hay hijos sin objetos a seguir de otra forma se llamara a CreateNewObject.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool emptySonFound = false;
        if (!objectList.Contains(collision.gameObject) && canPlayAudioTags.Contains(collision.gameObject.tag.ToString()))
        {
            objectList.Add(collision.gameObject);
            if (sons.Count > 0)
            {
                foreach (GameObject son in sons)
                {
                    if (!son.GetComponent<SoundPlayer>().ObjectToFollow)
                    {
                        son.GetComponent<SoundPlayer>().ObjectToFollow = collision.gameObject;
                        emptySonFound = true;
                        break;
                    }
                }
            }
            if (sons.Count < 1 || !emptySonFound)
            {
                CreateNewObject(collision.gameObject);
            }
        }
    }
    ///<summary>
    ///Quita de objectList al objeto que termino de colisionar con el elemento, lo quita como objeto a seguir del hijo que lo seguia y reproduce exitCollisionSound.
    ///</summary>
    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (GameObject son in sons)
        {
            if(son.GetComponent<SoundPlayer>().ObjectToFollow == collision.gameObject)
            {
                son.GetComponent<AudioSource>().Stop();
                son.GetComponent<AudioSource>().PlayOneShot(exitCollisionSound);
                son.GetComponent<SoundPlayer>().ObjectToFollow = null;
            }
        }
        objectList.Remove(collision.gameObject);
    }
    ///<summary>
    ///Crea un objeto hijo el cual tenga SoundPlayer y todas las caracteristicas del audio source del elemento padre, le asigna un objeto a seguir y lo incerta dentro de sons.
    ///</summary>
    ///<param name="gameObject">
    ///El objeto al que seguira el nuevo hijo.
    ///</param>
    private void CreateNewObject(GameObject gameObject)
    {
        GameObject tmp = new GameObject();
        tmp.AddComponent<AudioSource>();
        tmp.AddComponent<SoundPlayer>();
        AudioSource tmpAudioSource = tmp.GetComponent<AudioSource>();
        AudioSource thisAudioSource = GetComponent<AudioSource>();
        tmpAudioSource.clip = thisAudioSource.clip;
        tmpAudioSource.outputAudioMixerGroup = thisAudioSource.outputAudioMixerGroup;
        tmpAudioSource.mute = thisAudioSource.mute;
        tmpAudioSource.bypassEffects = thisAudioSource.bypassEffects;
        tmpAudioSource.bypassListenerEffects = thisAudioSource.bypassListenerEffects;
        tmpAudioSource.bypassReverbZones = thisAudioSource.bypassReverbZones;
        tmpAudioSource.playOnAwake = thisAudioSource.playOnAwake;
        tmpAudioSource.loop = thisAudioSource.loop;
        tmpAudioSource.priority = thisAudioSource.priority;
        tmpAudioSource.volume = thisAudioSource.volume;
        tmpAudioSource.pitch = thisAudioSource.pitch;
        tmpAudioSource.panStereo = thisAudioSource.panStereo;
        tmpAudioSource.spatialBlend = thisAudioSource.spatialBlend;
        tmpAudioSource.reverbZoneMix = thisAudioSource.reverbZoneMix;
        tmpAudioSource.dopplerLevel = thisAudioSource.dopplerLevel;
        tmpAudioSource.spread = thisAudioSource.spread;
        tmpAudioSource.rolloffMode = thisAudioSource.rolloffMode;
        tmpAudioSource.minDistance = thisAudioSource.minDistance;
        tmpAudioSource.maxDistance = thisAudioSource.maxDistance;
        tmp.GetComponent<SoundPlayer>().ExtraAudioLength = extraAudioLength;
        tmp.GetComponent<SoundPlayer>().AudioSource = tmp.GetComponent<AudioSource>();
        tmp.GetComponent<SoundPlayer>().CollisionSound = collisionSound;
        tmp.GetComponent<SoundPlayer>().ObjectToFollow = gameObject;
        if (!sons.Contains(tmp))
        {
            sons.Add(tmp);
        }
    }
}
