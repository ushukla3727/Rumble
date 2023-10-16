using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawner : MonoBehaviour
{
    public GameObject[] ground;
    public bool hasGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }

    public void SpawnGround()
    {
        int randomIndex = Random.Range(0,ground.Length);
        int randomNum = Random.Range(0, ground.Length);
        float offset = 2f;
        if (randomIndex == 0)
        {
             offset = 3f;
        }
        else if (randomIndex == 1)
        {
            offset = 1f;
        }

        //float offset = ground[randomIndex].gameObject.GetComponentInChildren<BoxCollider2D>().bounds.size.x + ground[randomIndex].gameObject.GetComponentInChildren<BoxCollider2D>().bounds.size.x;
        //Debug.Log(transform.position.x + offset);
        Debug.Log("offset" + offset);



        GameObject clone = Instantiate(ground[randomIndex], new Vector3(transform.position.x + offset,randomNum,0),Quaternion.identity);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("entering");
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Exiting");
            hasGround = false;
        }
    }
}
