using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateObject : MonoBehaviour
{
    public float Force
    {
        get
        {
            return force;
        }
        set
        {
            force = value;
        }
    }
    public float ShakeTime
    {
        get
        {
            return shakeTime;
        }
        set
        {
            shakeTime = value;
        }
    }
    public float ShakeMovementRange
    {
        get
        {
            return shakeMovementRange;
        }
        set
        {
            shakeMovementRange = value;
        }
    }
    public bool Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }

    ///<summary>
    ///Determina la fuerza con la que se vibrará la pantalla.
    ///</summary>
    [SerializeField]
    private float force;
    ///<summary>
    ///Determina cuánto tiempo durará la vibración.
    ///</summary>
    [SerializeField]
    private float shakeTime;
    ///<summary>
    ///Determina el área en que se puede mover el objeto, la distancia máxima que puede existir entre la posición inicial y la posición actual del objeto.
    ///</summary>
    [SerializeField]
    private float shakeMovementRange;
    ///<summary>
    ///Indica si el elemento puede realizar su funcionalidad, si puede hacer vibrar al objeto.
    ///</summary>
    [SerializeField]
    private bool active = false;

    ///<summary>
    ///Referencia al valor original de shakeTime.
    ///</summary>
    private float startShakeTime;
    ///<summary>
    ///Referencia al valor original de force.
    ///</summary>
    private float startForce;
    ///<summary>
    ///La fuerza con que se vibrara el objeto.
    ///</summary>
    private float diminishForce;
    ///<summary>
    ///La posición en x del objeto.
    ///</summary>
    private float posX;
    ///<summary>
    ///La posición en y del objeto.
    ///</summary>
    private float posY;
    ///<summary>
    ///Referencia a la pocicion inicial del objeto.
    ///</summary>
    private Vector3 startingPosition;

    ///<summary>
    ///Inicializa variables.
    ///</summary>
    private void Start()
    {
        startShakeTime = shakeTime;
        startForce = force;
    }
    ///<summary>
    ///Hace vibrar al objeto cuando active es verdadero y shakeTime es igual a startShakeTime.
    ///</summary>
    private void FixedUpdate()
    {
        if (active && shakeTime == startShakeTime)
        {
            startingPosition = transform.position;
            force = startForce;
            diminishForce = startForce / startShakeTime;
            posX = transform.position.x;
            posY = transform.position.y;
        }
        if (active && shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            transform.position = new Vector3(Random.Range(posX - shakeMovementRange, posX + shakeMovementRange) , 
                Random.Range(posY - shakeMovementRange, posY + shakeMovementRange), transform.position.z);
            force = Mathf.MoveTowards(force, 0, diminishForce * Time.deltaTime);
        }
        if (shakeTime <= 0)
        {
            active = false;
            shakeTime = startShakeTime;
            transform.position = startingPosition;
            force = startForce;
        }
    }
}
