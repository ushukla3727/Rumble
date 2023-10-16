using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingSreen : MonoBehaviour {
	
    private void Enable()
    {
		StartCoroutine(LoadScene());
    }
	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(5f);
		Debug.Log("You are here");
		SceneManager.LoadScene(1);
	}

}
