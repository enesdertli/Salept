using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D rigidbody;
    float velocity = 5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
        
    
    void Update()
    {
        rigidbody.velocity = new Vector2(velocity, rigidbody.velocity.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody.velocity.x)), 1);
        velocity = -velocity;
    }
}
