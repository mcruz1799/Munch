using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player; 
    [SerializeField] private GameObject PlayerObj; 
    public Text HealthText;
    public Text ScoreText;
    public static bool GameOver; 
    public static int CurrentScore;
    public int MovingScoreIncrement = 10;
    public int MunchingScoreIncrement = 50;


    // Start is called before the first frame update
    void Awake() {
        GameOver = false;
        CurrentScore = 0;
        player = PlayerObj.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        HealthText.text = "HEALTH: " + player.Health.ToString();
        ScoreText.text = "SCORE: " + CurrentScore.ToString();
    }
}
