using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public ColorManager colorManager;
    public IconManager iconManager;

    public GameObject cardPrefab;
    public GameObject canvas;
    public Vector2[] cardsPositions;

    void Start ()
    {
	    for (int i = 0; i < cardsPositions.Length; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.transform.SetParent(canvas.transform);
            card.GetComponent<RectTransform>().anchoredPosition = cardsPositions[i];
            card.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }
	}
	
	void Update ()
    {
	
	}
}
