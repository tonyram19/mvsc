using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardInitializer : MonoBehaviour
{
    public GameManager gameManager;

	void Start ()
    {
        SetColor();
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
}
