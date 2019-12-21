using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
       if (other.gameObject.GetComponent<Food>().HealthEffect > 0) 
        {
           GameManager.CurrentScore -= GameManager.MissDecrease; 
           StartCoroutine(GameManager.S.FlashScore(-GameManager.MissDecrease));
        }
       else 
        {
            GameManager.CurrentScore += GameManager.MissIncrease;
            StartCoroutine(GameManager.S.FlashScore(GameManager.MissIncrease));
        }

       Destroy(other.gameObject);
       FoodSpawner.foodCount--;
   }
}
