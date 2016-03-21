using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;


public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public ColorManager colorManager;
    public IconManager iconManager;
    public AudioManager audioManager;

    [Header("Life")]
    public GameObject[] heartsArray;
    public List<GameObject> hearts;

    [Header("Time")]
    public float totalTime;
    public float currentTime;
    public Image timerBar;

    [Header("Score")]
    public int score = 0;

    [Header("Cards")]
    public GameObject mainCard;
    public GameObject mainCardPrefab;
    public GameObject cardPrefab;
    public GameObject canvas;
    public List<GameObject> activeCards;
    public Vector2 mainCardPosition;
    public Vector2[] cardsPositions;

    [Header("Other")]
    public GameObject quitGameDialog;
    public GameObject gameOverDialog;
    public Text gameOverText;

    void Start ()
    {
        activeCards = new List<GameObject>();
        RestartGame();
    }

    void RestartGame()
    {
        ResetCards();
        score = 0;

        if (hearts.Count > 0)
        {
            foreach (GameObject heart in hearts)
                Destroy(heart);

            hearts.Clear();
            hearts = new List<GameObject>();
        }

        for (int i = 0; i < heartsArray.Length; i++)
        {
            hearts.Add(heartsArray[i]);
        }
    }

    public void ResetCards()
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
            card.transform.SetAsFirstSibling();
            activeCards.Add(card);
        }

        int randomCard = Random.Range(0, 3);
        mainCard = Instantiate(mainCardPrefab);
        mainCard.transform.SetParent(canvas.transform);
        mainCard.GetComponent<RectTransform>().anchoredPosition = mainCardPosition;
        mainCard.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        mainCard.GetComponent<MainCard>().Init();
        mainCard.GetComponent<MainCard>().transform.Find("Icon").GetComponent<Image>().sprite = activeCards[randomCard].GetComponent<Card>().icon;
        mainCard.transform.SetAsFirstSibling();

        currentTime = totalTime;

    }

    public void LoseAHeart()
    {
        if (hearts.Count >= 1)
        {
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
            audioManager.PlayLoseLifeSFX();
            ResetCards();
        }
        else
        {
            gameOverDialog.SetActive(true);
            gameOverText.text = "score: " + score;
            //Advertisement.Show();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGameDialog.SetActive(true);
        }

        if (!quitGameDialog.activeInHierarchy && !quitGameDialog.activeInHierarchy)
        {
            currentTime -= Time.deltaTime;
            timerBar.fillAmount = currentTime / totalTime;
        }


        if (currentTime <= 0)
        {
            LoseAHeart();
        }

	}
}
