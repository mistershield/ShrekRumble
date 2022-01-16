using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushProjectile : ProjectileFather
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
    public float PushForce
    {
        get
        {
            return pushForce;
        }
        set
        {
            pushForce = value;
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
    public List<string> CanPushList
    {
        get
        {
            return canPushList;
        }
        set
        {
            canPushList = value;
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
    ///Es la fuerza con que se empujara al objeto colisionado.
    ///</summary>
    [SerializeField]
    private float pushForce;
    ///<summary>
    ///Determina la distancia máxima que puede viajar el proyectil antes de destruirse.
    ///</summary>
    [SerializeField]
    private float maxDistance;
    ///<summary>
    ///Esta es una lista de STRINGS que se utiliza para determinar si el proyectil se destruirá al colisionar con un objeto. 
    ///Si el tag del objeto con el que colisionó el proyectil existe dentro de la lista, el proyectil no se destruirá.
    ///</summary>
    [SerializeField]
    private List<string> dontDestroyOnCollision = new List<string>();
    ///<summary>
    ///Esta es una lista de STRINGS que se utiliza para determinar si el proyectil Puede empujat al objeto con el que collisiono. 
    ///Si el tag del objeto con el que colisionó el proyectil existe dentro de la lista y este tiene un RigidBody2D, el proyectil lo empujara.
    ///</summary>
    [SerializeField]
    private List<string> canPushList = new List<string>();
    ///<summary>
    ///El RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;

    ///<summary>
    ///Duracion de HitSound
    ///</summary>
    private float hitSoundLength = 0;

    ///<summary>
    ///Inicializa variables e impulsa al projectil
    ///</summary>
    private void Start()
    {
        initialPosition = transform.position;
        if (HitSound)
        {
            hitSoundLength = HitSound.length;
        }
        rb.AddForce(gameObject.transform.right * speed, ForceMode2D.Impulse);
    }
    ///<summary>
    ///Verifica si se necesita destruir al proyectil porque supero su distancia maxima.
    ///</summary>
    private void FixedUpdate()
    {
        this.distance = CalculateDistance(initialPosition, transform.position);
        if (this.distance > maxDistance)
        {
            StartCoroutine(DestroyProyectile());
        }
    }
    ///<summary>
    ///llama a ProjectileCollision cuando el proyectil es colisionado.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProjectileCollision(collision.gameObject);
    }
    ///<summary>
    ///llama a ProjectileCollision cuando el proyectil es triggereado.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileCollision(collision.gameObject);
    }
    ///<summary>
    ///Reproduce hitSound, inicia el proceso de destruccion si collision no contiene el codigo ProjectileFather 
    ///y el tag de collision no existe dentro de dontDestroyOnCollision y Empuja al objeto collision.
    ///</summary>
    ///<param name="collision">
    ///El objeto con el que se tubo la colicion o que triggereo al proyectil.
    ///</param>
    private void ProjectileCollision(GameObject collision)
    {
        if (!collision.GetComponent<ProjectileFather>() && !dontDestroyOnCollision.Contains(collision.tag))
        {
            if (HitSound)
            {
                AudioSource.PlayOneShot(HitSound);
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (collision.GetComponent<Rigidbody2D>() && canPushList.Contains(collision.tag))
            {
                collision.GetComponent<Rigidbody2D>().velocity += rb.velocity.normalized * pushForce;
            }
            StartCoroutine(DestroyProyectile());
        }
    }
    ///<summary>
    ///Destruye el proyectil cuando hitSound termina de reproducirse.
    ///</summary>
    private IEnumerator DestroyProyectile()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(hitSoundLength);
        Destroy(gameObject);
    }
}
