using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    
    Rigidbody2D rb;
    GameObject player;
    public GameObject enemyBullet;
    [SerializeField] float coolDownTimer = Mathf.Infinity;
    bool canAttack = true;
    [SerializeField] private float attackCoolDown;
    [SerializeField] float hotDist;
    [SerializeField] float angerDist;
    [SerializeField] float shootForce;

    // Start is called before the first frame update
    void Start()
    {
        //hotZone = GetComponentInChildren<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < angerDist)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * shootForce;

        }
        else if (distance < hotDist)
        {
            if (canAttack && coolDownTimer > attackCoolDown)
            {
                Attack();
            }
        }




        coolDownTimer += Time.deltaTime;

        //Destroy(gameObject, 20f);
    }

    private void Attack()
    {
        GameObject clone = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        Destroy(clone, 4f);
        coolDownTimer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}


