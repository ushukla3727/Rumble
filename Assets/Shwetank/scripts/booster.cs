using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    //this script is attached to booster

    //float boostTime = 6f;
    public float waitTime = 9f; //after this time the player returns to its original speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Player player = collision.GetComponent<Player>();

            StartCoroutine(Boost(player));
        }
    }


    IEnumerator Boost(Player player)
    {
        player.moveSpeed = 20;  //boosted speed
        //Instantiate(player.boostEffect, player.transform.position, Quaternion.EulerAngles(0,0,-90));  //boostparticle
        player.PlayBoosterEffect();
        yield return new WaitForSeconds(waitTime);
        player.StopBoostEffect();
        player.moveSpeed = 4; //original speed


    }

    
}
