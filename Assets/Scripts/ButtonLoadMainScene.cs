using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonLoadMainScene : MonoBehaviour
{ 
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.LoadScene(1);
        });
    }
}
