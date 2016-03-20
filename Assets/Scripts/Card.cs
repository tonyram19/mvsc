using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    GameManager gameManager;
    public Sprite icon;

    void Start ()
    {
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
        icon = transform.Find("Icon").GetComponent<Image>().sprite;
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
                gameManager.mainCard.transform.Find("Icon").GetComponent<Image>().sprite.name)
            {
                gameManager.Init();
            }
        });
    }
}
