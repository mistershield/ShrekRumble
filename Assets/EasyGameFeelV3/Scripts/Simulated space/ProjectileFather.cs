using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFather : MonoBehaviour
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
    public AudioClip HitSound
    {
        get
        {
            return hitSound;
        }
        set
        {
            hitSound = value;
        }
    }

    ///<summary>
    ///Determina el daño que puede causar el proyectil.
    ///</summary>
    [SerializeField]
    private float damage;
    ///<summary>
    ///El AudioSource del proyectil.
    ///</summary>
    [SerializeField]
    private AudioSource audioSource;
    ///<summary>
    ///Este es un AudioClip que es reproducido cuando el proyectil colisiona.
    ///</summary>
    [SerializeField]
    private AudioClip hitSound;

    ///<summary>
    ///La posición inicial del objeto.
    ///</summary>
    protected Vector3 initialPosition;
    ///<summary>
    ///Referencia a la distancia entre dos puntos.
    ///</summary>
    protected float distance;

    ///<summary>
    ///calcula la distancia entre dos puntos.
    ///</summary>
    ///<param name="pos1">
    ///La primera posición de referencia.
    ///</param>
    ///<param name="pos2">
    ///La segunda posición de referencia.
    ///</param>
    ///<return>
    ///Regresa la distancia entre los dospuntos.
    ///</return>
    public float CalculateDistance(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos2.x - pos1.x, 2) + Mathf.Pow(pos2.y - pos1.y, 2));
    }
}
