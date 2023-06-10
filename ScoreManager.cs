using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    List<string> animalName = new List<string>();
    public static ScoreManager main;
    void Awake()
    {
         if (main != null && main != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        main = this; 
    } 
   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
public void addToList(string a)
{

  animalName.Add(a);

}
    // Update is called once per frame
    void Update()
    {
        
    }
}
