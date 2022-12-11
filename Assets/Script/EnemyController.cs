using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float giddyTime = 3f;
    Rigidbody2D rigidbody;
    float velocity = 5f;
    CapsuleCollider2D capsuleCollider2D;
    bool isGiddy = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
        
    
    void Update()
    {

        if (capsuleCollider2D.IsTouching(FindObjectOfType<PlayerMovement>().GetFeetColliderOfPlayer())) {
            StartCoroutine(BeGiddy());
        }

        if (isGiddy) {
            return;
        }

        rigidbody.velocity = new Vector2(velocity, rigidbody.velocity.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody.velocity.x)), 1);
        velocity = -velocity;
    }

    IEnumerator BeGiddy() {
        rigidbody.velocity = new Vector2(0, 0);
        isGiddy = true;
        GetComponent<Animator>().SetBool("isGiddy", true);
        yield return new WaitForSeconds(giddyTime);

        if (velocity > 0) {
            transform.localScale = new Vector2(1, 1);
        }
        GetComponent<Animator>().SetBool("isGiddy", false);
        isGiddy = false;

        
    }
}
