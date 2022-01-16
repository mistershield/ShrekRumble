using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    //Este codigo esta vasado en: https://www.youtube.com/watch?v=8PXPyyVu_6I&t=499s
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
    public Transform PositionToReturn
    {
        get
        {
            return positionToReturn;
        }
        set
        {
            positionToReturn = value;
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
    ///Indica si el elemento puede realizar su funcionalidad, si puede hacer vibrar la pantalla.
    ///</summary>
    [SerializeField]
    private bool active = false;
    ///<summary>
    ///Esta es un TRANSFORM que se utiliza como referencia a la posición inicial del objeto, el objeto después de hacer vibrar la pantalla regresará a esta posición.
    ///</summary>
    [SerializeField]
    private Transform positionToReturn;

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
    private float y;
    ///<summary>
    ///Referencia al valor original de la pocicion z del objeto.
    ///</summary>
    private float initialPosZ;
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
        initialPosZ = transform.localPosition.z;
        transform.position = new Vector3(positionToReturn.position.x, positionToReturn.position.y, initialPosZ);
    }
    ///<summary>
    ///Hace vibrar al objeto cuando active es verdadero y shakeTime es igual a startShakeTime.
    ///</summary>
    private void FixedUpdate()
    {
        if (active && shakeTime == startShakeTime)
        {
            force = startForce;
            y = startForce / startShakeTime;
        }
        if (active && shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            transform.localPosition = new Vector3(Random.Range(-shakeMovementRange, shakeMovementRange) * force, Random.Range(-shakeMovementRange, shakeMovementRange) * force, initialPosZ);
            force = Mathf.MoveTowards(force, 0, y * Time.deltaTime);
        }
        if (shakeTime <= 0)
        {
            active = false;
            shakeTime = startShakeTime;
            transform.position = new Vector3(positionToReturn.position.x, positionToReturn.position.y, initialPosZ);
            force = startForce;
        }
    }
}
