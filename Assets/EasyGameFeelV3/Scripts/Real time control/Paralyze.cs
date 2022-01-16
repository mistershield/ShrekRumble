using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
///Solo funciona si el objeto hace su movimiento con rigidbody2D y si simulated esta activado.
///</summary>
public class Paralyze : MonoBehaviour
{
    public float ParalyseTimeLength
    {
        get
        {
            return paralyseTimeLength;
        }
        set
        {
            paralyseTimeLength = value;
        }
    }
    public float MaxTimeBetweenParalyzing
    {
        get
        {
            return maxTimeBetweenParalyzing;
        }
        set
        {
            maxTimeBetweenParalyzing = value;
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
    public List<string> ParalyzerTags
    {
        get
        {
            return paralyzerTags;
        }
        set
        {
            paralyzerTags = value;
        }
    }

    ///<summary>
    ///Determina cuánto durará la paralización. 
    ///</summary>
    [SerializeField]
    private float paralyseTimeLength;
    ///<summary>
    ///Determina cuánto tiempo debe de pasar después de que el objeto sea paralizado para que pueda ser paralizado de nuevo.
    ///</summary>
    [SerializeField]
    private float maxTimeBetweenParalyzing;
    ///<summary>
    ///El RigidBody2D del objeto.
    ///</summary>
    [SerializeField]
    private Rigidbody2D rb;
    ///<summary>
    ///Lista de STRINGS que determinan los objetos que paralizan al objeto con Paralyze, 
    ///si el tag del objeto con el que se colisionó existe dentro de la lista el elemento será paralizado.
    ///</summary>
    [SerializeField]
    private List<string> paralyzerTags = new List<string>();

    ///<summary>
    ///Indica si el objeto esta paralizado.
    ///</summary>
    private bool active = false;
    ///<summary>
    ///Indica si el objeto puede ser paralizado.
    ///</summary>
    private bool canBeParalyzed = true;
    ///<summary>
    ///Indica si el Rigidbody2D del objeto tiene la opcion de freezeRotation activada.
    ///</summary>
    private bool freezeRotation = false;

    ///<summary>
    ///Cuando hay una colision verifica si el objeto esta paralizado, si no lo esta inicia el poceso de paralización.
    ///</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in paralyzerTags)
        {
            if (collision.gameObject.tag == tag && canBeParalyzed)
            {
                StartCoroutine(StopObject());
                active = true;
                break;
            }
        }
    }

    ///<summary>
    ///Cuando el objeto es trigereado verifica si el objeto esta paralizado, si no lo esta inicia el poceso de paralización.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in paralyzerTags)
        {
            if (collision.gameObject.tag == tag && canBeParalyzed)
            {
                StartCoroutine(StopObject());
                active = true;
                break;
            }
        }
    }
    ///<summary>
    ///Regresa un booleano el cual indica si el elemento está activo o no, si el objeto está paralizado o no.
    ///</summary>
    ///<return>
    ///Regresa true si el elemento esta activo. Si esta paralizado.
    ///</return>
    public bool GetActive()
    {
        return active;
    }
    ///<summary>
    ///Paraliza al objeto durante una cantidad de tiempo dada por paralyseTimeLength, desparaliza al objeto despues de este tiempo
    ///y hace que no pueda ser paralizado por una cantidad de tiempo dada por maxTimeBetweenParalyzing.
    ///</summary>
    private IEnumerator StopObject()
    {
        canBeParalyzed = false;
        if (rb.freezeRotation)
        {
            freezeRotation = true;
        }
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(paralyseTimeLength);
        rb.constraints = RigidbodyConstraints2D.None;
        if (freezeRotation)
        {
            rb.freezeRotation = true;
        }
        rb.velocity = new Vector3(0.01f, 0, 0);
        active = false;
        yield return new WaitForSeconds(maxTimeBetweenParalyzing);
        canBeParalyzed = true;
    }
}
