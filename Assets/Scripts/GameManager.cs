using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public ColorManager colorManager;
    public IconManager iconManager;
    public AudioManager audioManager;
    public AdManager adManager;

    [Header("Life")]
    public GameObject[] heartsArray;
    public List<GameObject> hearts;

    [Header("Time")]
    public float totalTime;
    public float currentTime;
    public Image timerBar;

    [Header("Score")]
    public int score = 0;
    public int highScore;

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
    public Text scoreText;
    public Text highscoreText;

    void Start()
    {
        activeCards = new List<GameObject>();
        RestartGame();
    }

    void RestartGame()
    {
        ResetCards();
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore");

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

        adManager.CreateAdBanner();

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


        if (score > 10 && score <= 15)
            currentTime = totalTime - 0.2f;
        else if (score > 15 && score <= 20)
            currentTime = totalTime - 0.3f;
        else if (score > 20 && score <= 25)
            currentTime = totalTime - 0.4f;
        else if (score > 25 && score <= 30)
            currentTime = totalTime - 0.5f;
        else if (score > 30 && score <= 35)
            currentTime = totalTime - 0.6f;
        else if (score > 35 && score <= 40)
            currentTime = totalTime - 0.7f;
        else if (score > 40 && score <= 45)
            currentTime = totalTime - 0.8f;
        else if (score > 45 && score <= 50)
            currentTime = totalTime - 0.9f;
        else if (score > 50 && score <= 55)
            currentTime = totalTime - 1f;
        else if (score > 55 && score <= 60)
            currentTime = totalTime - 1.1f;
        else if (score > 60 && score <= 65)
            currentTime = totalTime - 1.2f;
        else if (score > 65 && score <= 70)
            currentTime = totalTime - 1.3f;
        else if (score > 70 && score <= 75)
            currentTime = totalTime - 1.4f;
        else if (score > 75 && score <= 80)
            currentTime = totalTime - 1.5f;
        else if (score > 80 && score <= 85)
            currentTime = totalTime - 1.6f;
        else if (score > 85 && score <= 90)
            currentTime = totalTime - 1.7f;
        else if (score > 90)
            currentTime = totalTime - 1.8f;
        else
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

            if (score > highScore)
                PlayerPrefs.SetInt("highScore", score);

            gameOverDialog.SetActive(true);
            scoreText.text = "score: " + score;
            highscoreText.text = "high score: " + PlayerPrefs.GetInt("highScore");
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
