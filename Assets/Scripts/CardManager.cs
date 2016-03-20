using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    GameManager gameManager;

    void Start ()
    {
        Init();
	}
	
    public void Init()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        SetColor();
        SetRandomIcon();
        SetClickListener();
    }

	void SetColor()
    {
        GetComponent<Image>().color = gameManager.colorManager.GenerateRandomColor();

        float h;
        float s;
        float v;

        Color.RGBToHSV(GetComponent<Image>().color, out h, out s, out v);

        s = 1f;
        v = 125f / 255f;

        Color iconColor = new Color();
        iconColor = Color.HSVToRGB(h, s, v);

        transform.Find("Icon").GetComponent<Image>().color = iconColor;
    }

    void SetRandomIcon()
    {
        transform.Find("Icon").GetComponent<Image>().sprite = gameManager.iconManager.GetRandomIcon();
    }

    public void SetSpecificIcon(Sprite icon)
    {
        transform.Find("Icon").GetComponent<Image>().sprite = icon;

    }

    void SetClickListener()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(()=> {
            if (transform.Find("Icon").GetComponent<Image>().sprite.name ==
                GameObject.Find("Main Card").transform.Find("Icon").GetComponent<Image>().sprite.name)
            {
                gameManager.Init();
            }
        });
    }
}
