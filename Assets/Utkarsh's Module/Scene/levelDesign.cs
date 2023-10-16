using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelDesign : MonoBehaviour
{
    public Button[] levelButton;

    private void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 2);

        for (int i = 0; i<levelButton.Length;i++)
        {
            if (i + 2 > currentLevel)
            {
                levelButton[i].interactable = false;
            }
        }
    }

    public void ChangeLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
