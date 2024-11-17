using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float flapStrength;
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public bool playerIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && playerIsAlive == true) 
            myRigidbody.velocity = Vector2.up * flapStrength;
        if (transform.position.y > 9 || transform.position.y < -9)
            killPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        killPlayer();
    }

    private void killPlayer()
    {
        logic.gameOver();
        playerIsAlive = false;
    }
}
