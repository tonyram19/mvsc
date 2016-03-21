using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPlayGame : MonoBehaviour
{
    public GameObject tutorial;

    void Start ()
    {
        GetComponent<Button>().onClick.AddListener(()=> {
            if (PlayerPrefs.GetInt("tutorialWasCompleted") == 1)
            { 
                SceneManager.LoadScene(1);
            }
            else
            {
                PlayerPrefs.SetInt("tutorialWasCompleted", 1);
                tutorial.SetActive(true);
            }

        });
	}
	
}
