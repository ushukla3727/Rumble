using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coin; 
    BoxCollider2D cc;

    private void Awake()
    {
        cc = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        float minRange = cc.bounds.min.x;
        float maxRange = cc.bounds.max.x;
        float randomRange = Random.Range(minRange, maxRange);
        int random= Random.Range(1, 10);
        int randomIndex = Random.Range(0,coin.Length);

        if(random == 2 || random == 4 || random==6 || random == 8)
        {
            Instantiate(coin[randomIndex], new Vector3(randomRange, transform.position.y + 3, 0), Quaternion.identity);
        }
        
    }

   
}
