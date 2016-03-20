using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonQuitGame : MonoBehaviour
{

	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(()=> {
            Application.Quit();
        });
	}
	
}
