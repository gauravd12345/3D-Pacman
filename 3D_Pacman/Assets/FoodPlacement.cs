using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    // Initializes food positions using pathfinder algorithm
 
    void Start()
    {
       
    }

    // Update is called once per frame
    // This is called upon contact with player
    void Update()
    {
        if (Physics.OverlapSphere(transform.position, 1f) != null) {
            Destroy(this);
            Scoring.score += 10;
        }
    }
}
