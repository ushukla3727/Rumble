using UnityEngine;
using System.Collections;

public class ResetBoundCamera : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.GetComponent<Player> () == null)
			return;
		
		FindObjectOfType<Camer> ()._min = transform.position;

		gameObject.SetActive (false);
	}
}
