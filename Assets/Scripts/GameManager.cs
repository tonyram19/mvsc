using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public ColorManager colorManager;
    public IconManager iconManager;

    [Header("Time")]
    public float totalTime;
    public float currentTime;
    public Image timerBar;

    [Header("Cards")]
    public GameObject mainCard;
    public GameObject cardPrefab;
    public GameObject canvas;
    public List<GameObject> activeCards;
    public Vector2[] cardsPositions;

    void Start ()
    {
        Init();
    }

    public void Init()
    {
        if (activeCards.Count > 0)
        {
            foreach (GameObject card in activeCards)
                Destroy(card);

            activeCards.Clear();
        }

        for (int i = 0; i < cardsPositions.Length; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.transform.SetParent(canvas.transform);
            card.GetComponent<RectTransform>().anchoredPosition = cardsPositions[i];
            card.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            activeCards.Add(card);
        }

        mainCard.GetComponent<CardManager>().Init();

        int randomCard = Random.Range(0, 3);
        string mainCardIconName = mainCard.transform.FindChild("Icon").GetComponent<Image>().sprite.name;
        Image iconToChange = activeCards[randomCard].transform.Find("Icon").GetComponent<Image>();

        iconToChange.overrideSprite = iconManager.GetIconByName(mainCardIconName);
        iconToChange.overrideSprite.name = iconManager.GetIconByName(mainCardIconName).name;

        currentTime = totalTime;

    }
	
	void Update ()
    {
        currentTime -= Time.deltaTime;
        timerBar.fillAmount = currentTime / totalTime;
	}
}
