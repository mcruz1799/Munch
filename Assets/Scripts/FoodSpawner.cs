using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private int maxFood = 10; 
    [SerializeField] private float foodDistance = 5.0f;
    [SerializeField] private float yPosition = 2.0f;
    [SerializeField] private float probability = .5f;
    // private List<GameObject> foods;
    public static int foodCount = 0;
    public GameObject healthyFood;
    public GameObject junkFood;
    private float lastFoodZ;
    // Start is called before the first frame update
    void Awake()
    {
        if (healthyFood == null || junkFood==null) Debug.Log("NULLL");
        for (int i = 1; i <maxFood+1; i++)
        {
            Vector3 position = new Vector3(0,yPosition,i*foodDistance);
            float rand = Random.Range(1,100);
            if (rand <= probability*100) Instantiate(healthyFood,position,Quaternion.identity);
            else Instantiate(junkFood,position,Quaternion.identity);
            foodCount++;
        }
        lastFoodZ = maxFood * foodDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (foodCount < maxFood)
        {
            Debug.Log("NEW FOOD");
            Vector3 position = new Vector3(0,yPosition,lastFoodZ+foodDistance);
            lastFoodZ+=foodDistance;
            float rand = Random.Range(1,100);
            if (rand <= probability*100) Instantiate(healthyFood,position,Quaternion.identity);
            else Instantiate(junkFood,position,Quaternion.identity);
            foodCount++;
        }
    }
    IEnumerator SpawnRoutine(){
        yield return null;
    }
}
