using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionChecker : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                player.TakeDamage(10f, Vector2.right, gameObject);
        }
    }
}
