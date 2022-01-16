using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
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
    public GameObject ObjectToFollow
    {
        get
        {
            return objectToFollow;
        }
        set
        {
            objectToFollow = value;
        }
    }

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
    ///El audio source del elemento
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;
    ///<summary>
    ///El objeto que siguira este elemento
    ///</summary>
    [SerializeField]
    private GameObject objectToFollow;

    ///<summary>
    ///La duracion de collisionSound
    ///</summary>
    private float collisionSoundLength;
    ///<summary>
    ///La pocicion anterior del objeto a seguir de despues de moverse.
    ///</summary>
    private Vector3 previousPosition;
    ///<summary>
    ///Indica si se puede reproducir collisionSound.
    ///</summary>
    private bool canPlay = true;

    ///<summary>
    ///Inicializa variables.
    ///</summary>
    private void Start()
    {
        previousPosition = objectToFollow.transform.position;
        collisionSoundLength = collisionSound.length;
    }
    ///<summary>
    ///hace que el objeto SoundPlayer siga a su objeto a seguir y cuando este se mueve llama a PlaySound.
    ///</summary>
    private void Update()
    {
        if (objectToFollow)
        {
            transform.position = objectToFollow.transform.position;
            if (objectToFollow.transform.position.x != previousPosition.x && !audioSource.isPlaying && canPlay)
            {
                StartCoroutine(PlaySound());
            }
        }
    }
    ///<summary>
    ///Reproduce collisionSound y actualiza previousPosition.
    ///</summary>
    private IEnumerator PlaySound()
    {
        canPlay = false;
        audioSource.PlayOneShot(collisionSound);
        yield return new WaitForSeconds(collisionSoundLength + extraAudioLength);
        if (objectToFollow)
        {
            previousPosition = objectToFollow.transform.position;
        }
        canPlay = true;
    }
}
