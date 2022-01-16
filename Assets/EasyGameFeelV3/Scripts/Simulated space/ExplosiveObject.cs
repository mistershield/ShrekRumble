using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public float MaxExplosionSize
    {
        get
        {
            return maxExplosionSize;
        }
        set
        {
            maxExplosionSize = value;
        }
    }
    public Vector3 ExplosionGrowtScale
    {
        get
        {
            return explosionGrowtScale;
        }
        set
        {
            explosionGrowtScale = value;
        }
    }
    public float ExplosionDelay
    {
        get
        {
            return explosionDelay;
        }
        set
        {
            explosionDelay = value;
        }
    }
    public string CollisionTag
    {
        get
        {
            return collisionTag;
        }
        set
        {
            collisionTag = value;
        }
    }
    public Sprite ExplosionSprite
    {
        get
        {
            return explosionSprite;
        }
        set
        {
            explosionSprite = value;
        }
    }
    public BoxCollider2D BoxCollider
    {
        get
        {
            return boxCollider;
        }
        set
        {
            boxCollider = value;
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
    public AudioClip ExplosionSound
    {
        get
        {
            return explosionSound;
        }
        set
        {
            explosionSound = value;
        }
    }

    ///<summary>
    ///Determina la cantidad de daño que el objeto puede tomar antes de explotar.
    ///</summary>
    [SerializeField]
    private float damage;
    ///<summary>
    ///Determina el tamaño máximo que puede tener el objeto al explotar.
    ///</summary>
    [SerializeField]
    private float maxExplosionSize;
    ///<summary>
    ///Determina qué tan rápido crecerá la explosion. Cuando el objeto detona este vector es sumado a la escala del objeto cada Update.
    ///</summary>
    [SerializeField]
    private Vector3 explosionGrowtScale;
    ///<summary>
    ///Determina el tiempo que debe de pasar entre que el objeto colisione y que explote.
    ///</summary>
    [SerializeField]
    private float explosionDelay;
    ///<summary>
    ///Determina el tag de los objetos que pueden causar la explosion. 
    ///Si el tag del objeto con que colisionó el objeto explosivo es igual a esta variable, el objeto explota.
    ///</summary>
    [SerializeField]
    private string collisionTag;
    ///<summary>
    ///Esta es un SPRITE al cual cambiará el objeto al detonar.
    ///</summary>
    [SerializeField]
    private Sprite explosionSprite;
    ///<summary>
    ///El BoxCollider2D del objeto.
    ///</summary>
    [SerializeField]
    private BoxCollider2D boxCollider;
    ///<summary>
    ///El AudioSource del objeto
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;
    ///<summary>
    ///Este es un AudioClip que es reproducido cuando el proyectil explota.
    ///</summary>
    [SerializeField]
    private AudioClip explosionSound;

    ///<summary>
    ///Duracion de explosionSound.
    ///</summary>
    private float explosionSoundLength = 0;
    ///<summary>
    ///El estado del objeto explosivo.
    ///</summary>
    private short explode = 0;
    ///<summary>
    ///Indica si el objeto ya exploto.
    ///</summary>
    private bool hasExploded = false;

    ///<summary>
    ///Inicializa explosionSoundLength.
    ///</summary>
    private void Start()
    {
        if (explosionSound)
        {
            explosionSoundLength = explosionSound.length;
        }
    }
    ///<summary>
    ///Si explode es igual a 1 escala el objeto hasta su tamaño maximo, despues de esto llama a la funcion Destroyobject.
    ///</summary>
    private void Update()
    {
        if (explode == 1)
        {
            if(transform.localScale.x <= maxExplosionSize && transform.localScale.y <= maxExplosionSize)
            {
                transform.localScale += explosionGrowtScale;
            }
            else
            {
                StartCoroutine(Destroyobject());
            }
        }
    }
    ///<summary>
    ///Cuando collisiona el objeto llama a StartExplosion si el objeto no ha explotado y el tag del objeto con el que colisiono es igual a collisionTag.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (explode == 0 && collision.gameObject.tag == collisionTag)
        {
            StartCoroutine(StartExplosion());
        }
    }
    ///<summary>
    ///Cuando se triggerea el objeto llama a StartExplosion si el objeto no ha explotado y el tag del objeto que activo el trigger es igual a collisionTag.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (explode == 0 && collision.gameObject.tag == collisionTag)
        {
            StartCoroutine(StartExplosion());
        }
    }
    ///<summary>
    ///Inicia la explosion del objeto y reproduce explosionSound.
    ///</summary>
    private IEnumerator StartExplosion()
    {
        yield return new WaitForSeconds(explosionDelay);
        explode = 1;
        hasExploded = true;
        boxCollider.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        if (explosionSound && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
    ///<summary>
    ///Destruye al objeto cuando explosionSound termina de reproducirse.
    ///</summary>
    private IEnumerator Destroyobject()
    {
        explode = 3;
        yield return new WaitForSeconds(explosionSoundLength);
        Destroy(gameObject);
    }
    ///<summary>
    ///Regresa un ENTERO (del 0 al 3) que indica el estado del objeto explosivo, si este está en el estado inicial, esperando a detonar, explotando o ya explotó.
    ///</summary>
    ///<return>
    ///Regresa el estado de la explocion, si este está en el estado inicial (0), esperando a detonar(1), explotando (2) o ya explotó(3).
    ///</return>
    public short GetExplodeState()
    {
        return explode;
    }
    ///<summary>
    ///Regresa un BOOLEANO el cual indica si el objeto explotó.
    ///</summary>
    ///<return>
    ///Regresa true si el elemento exploto.
    ///</return>
    public bool GetHasExploded()
    {
        return hasExploded;
    }
}
