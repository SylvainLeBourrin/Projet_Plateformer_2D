using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJumpCount : MonoBehaviour
{

    // appel d'un autre script qui existe peut etre quelque part?

    public Mouveme _Me;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ici on vas detecter si le Foot Colider Touche le sol

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Floor"))
        {
            
            _Me.currentJumpCount = 0;
            
        }
    }
    
}
