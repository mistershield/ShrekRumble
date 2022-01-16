using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public float HitPoints
    {
        get
        {
            return hitPoints;
        }
        set
        {
            hitPoints = value;
        }
    }
    public float Delay
    {
        get
        {
            return delay;
        }
        set
        {
            delay = value;
        }
    }
    public bool SpawnsElements
    {
        get
        {
            return spawnsElements;
        }
        set
        {
            spawnsElements = value;
        }
    }
    public bool LeavesBrokenPieces
    {
        get
        {
            return leavesBrokenPieces;
        }
        set
        {
            leavesBrokenPieces = value;
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
    public List<GameObject> DroppableItems
    {
        get
        {
            return droppableItems;
        }
        set
        {
            droppableItems = value;
        }
    }
    public List<GameObject> BrokenPieces
    {
        get
        {
            return brokenPieces;
        }
        set
        {
            brokenPieces = value;
        }
    }

    ///<summary>
    ///Determina la cantidad de daño que el objeto puede tomar antes de ser destruido.
    ///</summary>
    [SerializeField]
    private float hitPoints;
    ///<summary>
    ///Determina el tiempo que debe de pasar entre que el objeto pierde todos sus Hit Points y que éste sea borrado del juego.
    ///</summary>
    [SerializeField]
    private float delay;
    ///<summary>
    ///Determina si el objeto creará “Loot” después de ser destruido.
    ///</summary>
    [SerializeField]
    private bool spawnsElements;
    ///<summary>
    ///Determina si el objeto dejará piezas después de ser destruido.
    ///</summary>
    [SerializeField]
    private bool leavesBrokenPieces;
    ///<summary>
    ///Esta es una variable STRING que determina el tag de los objetos que pueden destruir el objeto. 
    ///Si el tag del objeto con que colisionó el objeto destruible es igual a esta variable, al objeto se le restará un Hit Point, 
    ///si este valor llega a ser cero, el objeto se destruye.
    ///</summary>
    [SerializeField]
    private string collisionTag;
    ///<summary>
    ///Esta es una lista de GameObjects que contiene el loot que se instancian después de que se destruya el objeto.
    ///</summary>
    [SerializeField]
    private List<GameObject> droppableItems;
    ///<summary>
    ///Esta es una lista de GameObjects que contiene las piezas que se instancian después de que se destruya el objeto.
    ///</summary>
    [SerializeField]
    private List<GameObject> brokenPieces;

    ///<summary>
    ///Desactiva todos los objetos dentro de brokenPieces.
    ///</summary>
    private void Start()
    {
        foreach(GameObject pice in brokenPieces)
        {
            pice.SetActive(false);
        }
    }
    ///<summary>
    ///Llama a HitObject cuando hay una collision.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitObject(collision.gameObject);
    }
    ///<summary>
    ///Llama a HitObject cuando el objeto es triggereado.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitObject(collision.gameObject);
    }
    ///<summary>
    ///Verifica que el objeto con que se coliciono o triggereo tiene un tag igual a collisionTag, 
    ///si esto es sierto, se le quita vida al objeto y si esta es menor o igual a 0 se activan los objetos dentro de brokenPieces, 
    ///instancia el loot y llama a la funcion WaitForDelay.
    ///</summary>}
    ///<param name="localObject">
    ///El objeto con el que se tubo la colicion o que triggereo al objeto.
    ///</param>
    private void HitObject(GameObject localObject)
    {
        if (localObject.tag == collisionTag)
        {
            hitPoints--;
        }
        if (hitPoints <= 0)
        {
            if (spawnsElements)
            {
                foreach (GameObject item in droppableItems)
                {
                    Instantiate(item, transform.position, transform.rotation);
                }
            }
            if (leavesBrokenPieces)
            {
                foreach (GameObject pice in brokenPieces)
                {
                    pice.SetActive(true);
                }
            }
            StartCoroutine(WaitForDelay());
        }
    }
    ///<summary>
    ///Destruye el objeto despues de que la cantidad de tiempo indicada por delay pasa.
    ///</summary>
    private IEnumerator WaitForDelay()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
