using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Este script controla el movimiento y detona a los proyectilñes explosivos
///Si los usuarios desean que sus proyectiles explosivos tengan un arco, 
///estos tendran que darle una gravedad y un peso al rigyd body del objeto proyectil explosibo
///</summary>
public class ExplosiveProjectile : ProjectileFather
{
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
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
    public float MaxDistance
    {
        get
        {
            return maxDistance;
        }
        set
        {
            maxDistance = value;
        }
    }
    public List<string> DontDestroyOnCollision
    {
        get
        {
            return dontDestroyOnCollision;
        }
        set
        {
            dontDestroyOnCollision = value;
        }
    }
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
        set
        {
            rb = value;
        }
    }

    ///<summary>
    ///Determina qué tan rápido se moverá el proyectil.
    ///</summary>
    [SerializeField]
    private float speed;
    ///<summary>
    ///Determina el tamaño máximo que puede tener el proyectil al explotar.
    ///</summary>
    [SerializeField]
    private float maxExplosionSize;
    ///<summary>
    ///Determina qué tan rápido crecerá la explosion. Cuando el proyectil detona este vector es sumado a la escala del objeto cada Update.
    ///</summary>
    [SerializeField]
    private Vector3 explosionGrowtScale;
    ///<summary>
    ///Determina el tiempo que debe de pasar entre que el objeto colisione y la detonación del proyectil.
    ///</summary>
    [SerializeField]
    private float explosionDelay;
    ///<summary>
    ///Esta es un SPRITE al cual cambiará el proyectil al detonar.
    ///</summary>
    [SerializeField]
    private Sprite explosionSprite;
    ///<summary>
    ///Determina la distancia máxima que puede viajar el proyectil antes de destruirse.
    ///</summary>
    [SerializeField]
    private float maxDistance;
    ///<summary>
    ///Esta es una lista de STRINGS que se utiliza para determinar si el proyectil se detonará al colisionar con un objeto. 
    ///Si el tag del objeto con el que colisionó el proyectil existe dentro de la lista, el proyectil no se destruirá.
    ///</summary>
    [SerializeField]
    private List<string> dontDestroyOnCollision = new List<string>();
    ///<summary>
    ///Este es el RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;

    ///<summary>
    ///Duracion de HitSound.
    ///</summary>
    private float explosionSoundLength = 0;
    ///<summary>
    ///El estado del objeto explosivo.
    ///</summary>
    private short explode = 0;

    ///<summary>
    ///Inicializa variables e impulsa al projectil.
    ///</summary>
    private void Start()
    {
        if (HitSound)
        {
            explosionSoundLength = HitSound.length;
        }
        initialPosition = transform.position;
        rb.AddForce(gameObject.transform.right * speed, ForceMode2D.Impulse);
    }
    ///<summary>
    ///Destruye al proyectil sui supera su distancia maxima y lo escala cuando explota.
    ///</summary>
    private void FixedUpdate()
    {
        this.distance = CalculateDistance(initialPosition, transform.position);
        if (this.distance > maxDistance)
        {
            Destroy(gameObject);
        }
        if (explode == 1)
        {
            if (transform.localScale.x <= maxExplosionSize && transform.localScale.y <= maxExplosionSize)
            {
                transform.localScale += explosionGrowtScale;
            }
            else
            {
                StartCoroutine(DestroyProyectile());
            }
        }
    }
    ///<summary>
    ///Cuando el proyectil collisiona llama a la funcion ProjectileCollision.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProjectileCollision(collision.gameObject);
    }
    ///<summary>
    ///Cuando el proyectil es triggereado llama a la funcion ProjectileCollision.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileCollision(collision.gameObject);
    }
    ///<summary>
    ///Llama a la funcion StartExplosion si el proyectil no ha explotado, el tag de objeto collision no esta dentro de dontDestroyOnCollision
    ///y collision no tiene el codigo ProjectileFather.
    ///</summary>
    ///<param name="collision">
    ///El objeto con el que se tubo la colicion o que triggereo al proyectil.
    ///</param>
    private void ProjectileCollision(GameObject collision)
    {
        if (explode == 0 && !collision.gameObject.GetComponent<ProjectileFather>() && !dontDestroyOnCollision.Contains(collision.tag))
        {
            StartCoroutine(StartExplosion());
        }
    }
    ///<summary>
    ///Inicia la explosion del objeto y reproduce HitSound.
    ///</summary>
    private IEnumerator StartExplosion()
    {
        yield return new WaitForSeconds(explosionDelay);
        explode = 1;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = explosionSprite;
        if (HitSound && !AudioSource.isPlaying)
        {
            AudioSource.PlayOneShot(HitSound);
        }
    }
    ///<summary>
    ///Destruye el proyectil.
    ///</summary>
    private IEnumerator DestroyProyectile()
    {
        explode = 3;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(explosionSoundLength);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(explosionSoundLength);
        Destroy(gameObject);
    }
}
