using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIsLife : MonoBehaviour
{
    public float LifeN;
    public float CurrentLife;
    // Start is called before the first frame update
    void Start()
    {
        LifeN = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void FixUpdate()
    {
        CurrentLife = LifeN;
    }
}
