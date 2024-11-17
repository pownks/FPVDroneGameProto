using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVScript : MonoBehaviour
{
    public float flySpeed;
    public Rigidbody2D myRigidbody;
    private bool flying;
    private Animator animator;
    private bool isAlive = true;
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true && isAlive)
            flying = true;
        else flying = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            animator.SetTrigger("Death");
            isAlive = false;
        }
    }
    
    public void OnDeathAnimationFinished()
    {
        gameObject.SetActive(false);
        GameManager.Instance.GameOver();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            if (flying && myRigidbody.velocity.y <= 10)
            {
                myRigidbody.AddForce(Vector2.up * flySpeed);

                float angle = Mathf.Lerp(0, -20, (myRigidbody.velocity.y / 4f));
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else if (!flying && myRigidbody.velocity.y < 0)
            {
                float angle = Mathf.Lerp(-20, 0, (-(myRigidbody.velocity.y) / 4f));
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}
