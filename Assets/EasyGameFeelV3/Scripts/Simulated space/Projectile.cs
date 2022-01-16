
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ProjectileFather
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
        //La linea de codigo siguiente basada en https://www.youtube.com/watch?v=LNLVOjbrQj4
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
    ///Reproduce hitSound e inicia el proceso de destruccion si collision no contiene el codigo ProjectileFather y el tag de collision no existe dentro de dontDestroyOnCollision.
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
