using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadlevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Enable()
    {
        
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("You are here");
        SceneManager.LoadScene(1);
    }
}
