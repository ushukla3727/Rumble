using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    public float shieldDuration = 5f; // How long the shield lasts in seconds
    public GameObject shieldVisuals; // The shield's visual representation
    private bool isShieldActive = false;

    private void Start()
    {
        shieldVisuals.SetActive(false);
    }

    public void ActivateShield()
    {
        if (!isShieldActive)
        {
            //GameManager.Instance.isProtected = true;
            isShieldActive = true;
            shieldVisuals.SetActive(true);
            StartCoroutine(DeactivateShieldAfterDuration());
        }
    }

    private IEnumerator DeactivateShieldAfterDuration()
    {
        yield return new WaitForSeconds(shieldDuration);
        isShieldActive = false;
        //GameManager.Instance.isProtected = false;
        shieldVisuals.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isShieldActive)
        {
            // Handle collision with the shield active
            // For example, you could negate damage or deflect objects
            // based on your game's mechanics
        }
    }
}
    

