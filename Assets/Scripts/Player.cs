using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health {get{return health;}set{health = value;}}
    private float health;
    public int Lives {get{return lives;}set{lives = value;}}
    private int lives; 
    private float munchTotalTranslate;
    [SerializeField] int munchDivisions = 10;
    [SerializeField] private float returnTime = 0.0f; 
    public float speed = 1.0f;
    private bool MunchFlag = false; 
    private AudioSource source; 
    [SerializeField] private AudioClip healthyClip; 
    [SerializeField] private AudioClip junkClip; 
    public static int healthyFoodCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        Health = 100.0f;
        munchTotalTranslate = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameOver)
        {
            if (Input.GetKeyDown("space") && !MunchFlag)
            {
                MunchFlag = true;
                StartCoroutine(MunchRoutine());
            }
            MovePlayer(speed);
        }
            

    }
    private void MovePlayer(float moveSpeed)
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        GameManager.CurrentScore += GameManager.S.MovingScoreIncrement * GameManager.ScoreMultiplier;
    }
    private IEnumerator MunchRoutine(){
        float munchTranslate = munchTotalTranslate/munchDivisions;
        for (int i = 0; i < munchDivisions; i++)
        {
            transform.Translate(new Vector3(0,-munchTranslate,0));
            yield return null; 
        }
        for (int i = 0; i < munchDivisions; i++)
        {
            transform.Translate(new Vector3(0,munchTranslate,0));
            yield return null; 
        }
        MunchFlag = false; 

        // yield return new WaitForSeconds(returnTime);
        // transform.Translate(new Vector3(0,munchTotalTranslate,0));
        // yield return null;
    }
    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log("COLLIDEE");
    //     Health += other.gameObject.GetComponent<Food>().HealthEffect;
    //     Object.Destroy(other.gameObject);
    // }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("COLLIDEE");
        Health += other.gameObject.GetComponent<Food>().HealthEffect;
        GameManager.S.FlashHealth(other.gameObject.GetComponent<Food>().HealthEffect);

        if (other.gameObject.GetComponent<Food>().HealthEffect>0) 
        {
            healthyFoodCount++;
            source.clip = healthyClip;
        }
        else 
        {
            healthyFoodCount = 0;
            source.clip = junkClip;
        }
        source.Play();
        
        GameManager.CurrentScore += other.gameObject.GetComponent<Food>().ScoreEffect * GameManager.ScoreMultiplier;
        GameManager.S.FlashScore(other.gameObject.GetComponent<Food>().ScoreEffect * GameManager.ScoreMultiplier);
        
        Object.Destroy(other.gameObject);
        FoodSpawner.foodCount--;
    }
}
