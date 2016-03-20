﻿using UnityEngine;
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
    public GameObject mainCardPrefab;
    public GameObject cardPrefab;
    public GameObject canvas;
    public List<GameObject> activeCards;
    public Vector2 mainCardPosition;
    public Vector2[] cardsPositions;

    void Start ()
    {
        activeCards = new List<GameObject>();
        Init();
    }

    public void Init()
    {
        if (activeCards.Count > 0)
        {
            foreach (GameObject card in activeCards)
                Destroy(card);

            activeCards.Clear();
            activeCards = new List<GameObject>();
        }

        Destroy(mainCard);

        for (int i = 0; i < cardsPositions.Length; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.GetComponent<Card>().Init();
            card.transform.SetParent(canvas.transform);
            card.GetComponent<RectTransform>().anchoredPosition = cardsPositions[i];
            card.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            activeCards.Add(card);
        }

        int randomCard = Random.Range(0, 3);
        mainCard = Instantiate(mainCardPrefab);
        mainCard.transform.SetParent(canvas.transform);
        mainCard.GetComponent<RectTransform>().anchoredPosition = mainCardPosition;
        mainCard.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        mainCard.GetComponent<MainCard>().Init();
        mainCard.GetComponent<MainCard>().transform.Find("Icon").GetComponent<Image>().sprite = activeCards[randomCard].GetComponent<Card>().icon;

        currentTime = totalTime;

    }
	
	void Update ()
    {
        currentTime -= Time.deltaTime;
        timerBar.fillAmount = currentTime / totalTime;
	}
}
