using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KissDeath : MonoBehaviour
{
    public LifeIsLife _IsLife;
    public float KillYou;
    public int countKillYou;
    // Start is called before the first frame update
    void Start()
    {
        KillYou = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("KillYou"))
        {
            _IsLife.CurrentLife = -1;
        }
    }
}
