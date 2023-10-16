using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameFinishFlag : MonoBehaviour {

	public int loadNextLevel;
    private void Start()
    {
        loadNextLevel = SceneManager.GetActiveScene().buildIndex + 1;

    }
    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<Player> () == null)
			return;
		GameManager.Instance.GameFinish ();
        SceneManager.LoadScene(loadNextLevel);
        if (loadNextLevel>PlayerPrefs.GetInt("currentLevel"))
        {
            PlayerPrefs.SetInt("currentLevel", loadNextLevel);
        }
	}
}
