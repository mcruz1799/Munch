using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private AudioSource source; 
    public GameObject backgroundMusicObj;
    private AudioSource backgroundMusic;
    [SerializeField] private AudioClip death; 
    private Player player; 
    [SerializeField] private GameObject PlayerObj; 
    public Text HealthText;
    public Text ScoreText;
    public Text MultiplierText;
    [SerializeField] private Image GameOverBackground;
    [SerializeField] private Text GameOverText;
    [SerializeField] private Text FlashScoreText;
    [SerializeField] private Text FlashHealthText;
    public static bool GameOver; 
    public static int CurrentScore;
    public static int ScoreMultiplier;
    public int ScoreMultiplierIncrease;
    public static int MissDecrease; 
    public int missDecrease = 10;
    public static int MissIncrease;
    public int missIncrease;
    public int MovingScoreIncrement = 10;
    // public int MunchingScoreIncrement = 50;
    [SerializeField] private int levelUpThreshold = 10;
    private static bool sameNumberFlag;
    public float speedMultiplier = 2.0f;
    public float flashTime = 1.0f;
    public static GameManager S; 


    // Start is called before the first frame update
    void Awake() {
        S = this.GetComponent<GameManager>();
        backgroundMusic = backgroundMusicObj.GetComponent<AudioSource>();
        sameNumberFlag = false;
        source = GetComponent<AudioSource>();
        GameOver = false;
        CurrentScore = 0;
        player = PlayerObj.GetComponent<Player>();
        ScoreMultiplier = 1;
        GameOverText.gameObject.SetActive(false);
        GameOverBackground.gameObject.SetActive(false);
        FlashHealthText.gameObject.SetActive(false);
        FlashScoreText.gameObject.SetActive(false);
        MissDecrease = missDecrease;
        MissIncrease = missIncrease;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameOverCheck())
        {
            HealthText.text = "HEALTH: " + player.Health.ToString();
            backgroundMusic.Stop();
            source.clip = death;
            source.Play();
            GameOver = true;
            GameOverBackground.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);
        }
        else
        {
            HealthText.text = "HEALTH: " + player.Health.ToString();
            ScoreText.text = "SCORE: " + CurrentScore.ToString();
            MultiplierText.text = ScoreMultiplier.ToString() + "x";
        }
        if (Player.healthyFoodCount % levelUpThreshold == 0 && Player.healthyFoodCount != 0 && !sameNumberFlag)
        {
            sameNumberFlag = true;
            levelUp();
        }
        if (Player.healthyFoodCount % levelUpThreshold != 0) sameNumberFlag = false;
    }
    void levelUp()
    {
        ScoreMultiplier += ScoreMultiplierIncrease;
        player.speed *= speedMultiplier;
    }
    bool GameOverCheck()
    {
        if (player.Health <= 0){player.Health = 0; return true;};
        return false;
    }

    public IEnumerator FlashScore(int change)
    {
        // FlashScoreText.text = change.ToString();
        // FlashScoreText.gameObject.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        // FlashScoreText.gameObject.SetActive(false);

    }
    public IEnumerator FlashHealth(int change)
    {
        // FlashHealthText.text = change.ToString();
        // FlashHealthText.gameObject.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        // FlashHealthText.gameObject.SetActive(false);
    }
}
