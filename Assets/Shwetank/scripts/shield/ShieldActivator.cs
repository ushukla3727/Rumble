using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivator : MonoBehaviour
{
    GameObject cc;
    private void Start()
    {
        cc = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (cc != null)
            {
                cc.gameObject.GetComponent<Shields>().ActivateShield();
            }

            Destroy(gameObject);
            Debug.Log(gameObject.name);
        }


    }
}
