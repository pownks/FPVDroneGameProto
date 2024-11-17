using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float deadZone = -15f;
    [SerializeField] private string enemyType;
    GameManager gameManager;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetTrigger("Death");
            if (enemyType == "chmonya") gameManager.currentScore += 100f;
            if (enemyType == "Tank") gameManager.currentScore += 200f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
