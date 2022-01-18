using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public void Jump()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("jump");
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
