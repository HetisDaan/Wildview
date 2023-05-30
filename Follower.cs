using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation; 

public class Follower : MonoBehaviour{
    public PathCreator PathCreator;
    public float speed = 5;
    float distanceTravelled;

    void Update(){
        distanceTravelled += speed * Time.deltaTime;
        transform.position = PathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = PathCreator.path.GetRotationAtDistance(distanceTravelled);
    }

    
}

