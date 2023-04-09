using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Character
{

    private int startDelay = 1;
    private int repeatTime = 2;
    private Rigidbody enemyRB;
    private float hitForce = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();

        InvokeRepeating("EnemyMovement", startDelay, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            enemyRB.AddForce(Vector3.right * hitForce, ForceMode.Impulse);
            Destroy(collision.gameObject);
        }
    }

    void EnemyMovement()
    {
        Jump(enemyRB, hitForce);   
    }
}
