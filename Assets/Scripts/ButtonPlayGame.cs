using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPlayGame : MonoBehaviour
{
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(()=> {
            SceneManager.LoadScene(1);
        });
	}
	
}
