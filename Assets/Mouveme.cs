using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouveme : MonoBehaviour
{
    public Rigidbody2D _rb2d; // je déclare mon Rigidbody
    public float _moveSpeedHorizon = 20f; // je declare ma vitesse de déplacement
    public float _moveSpeedVertical = 20f; // je déclare ma vitesse de monté descendre.
    public float _jumpSpeedVertical = 100f; // je déclare ma vitesse de saut
    public Vector2 _direction; //je déclare ma variable pour le déplacement.
    public float _maxspeed = 15f; //bloque la vitesse a une vitesse
    public Animator _déplacement; // je déclare mon animation dans le script

    [Header("JumpInfo")]
    public byte MaxJumpcount = 3; // limite de saut ( penser a le remetre a zero au toucher du sol)
    private bool WannaJump = false; // Par defaut je ne saute pas.
    public int currentJumpCount = 0; //  allons compté fleurette 

    [Header("LifeInfo")]
    public int currentLife = 0; // allons compté les vies du joueur.
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>(); // J'affecte mon Rigidbody2D à _rb2d
        WannaJump = false; // initialisation du jeux


        _déplacement = GetComponent<Animator>(); // jj'affect mon animation dans le script


    }


// Update is called once per frame
void Update()
    {
        // Je déclare les commandes de déplacement :
        _direction.x = Input.GetAxis("Horizontal") * _moveSpeedHorizon;
       if  ( Input.GetKeyDown(KeyCode.Space)) //& //contacte du sol)
        {
             WannaJump = true;
               
            
        } 
       
     
    }
    void FixedUpdate()
    {
        // A LA REPRISE POUR DEMAIN !!

        // par defaut mon Animation est sur IDLE, si mouvement elle doit etre sur Movin
       /* if (_rb2d.velocity.x != 0)
        {
            //_déplacement.geta
        }*/

        // action sur le rigidbody attendu :
        _rb2d.AddForce(_direction);
        _direction.y = 0f;

        //Je bloque la vitesse maximum en x Positif
            if (_rb2d.velocity.x > _maxspeed)
            {
                _rb2d.velocity = new Vector2(_maxspeed, _rb2d.velocity.y);
            }
            // Je bloque la Vitesse maximum en x Negatif ( pas le déplacement)
         /*   if (_rb2d.velocity.x > (_maxspeed* -1))
            {
            _rb2d.velocity = new Vector2(_maxspeed, _rb2d.velocity.y);
            }*/
        // Action du saut sur le personnage , avec Velocity
           if (_rb2d.velocity.y > (_maxspeed))
            {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _maxspeed);            
            }
        // Faire une chute plus rapide que le saut (pour la distance)
        if (_rb2d.velocity.y < 0)
        {
            _rb2d.gravityScale = 2f;
        }
        else
        {
            _rb2d.gravityScale = 1f;
        }
        if (WannaJump)
        {

            
            if (currentJumpCount < MaxJumpcount)
            {
                currentJumpCount++;
                _direction.y = _jumpSpeedVertical;
            
            }
            WannaJump = false;
        }

        // Mise en place du retournement de personnage lorsque l'on se déplace.
        if (_rb2d.velocity.x < 0)
        {
            
           Quaternion q = Quaternion.Euler(0, 180, 0);

            transform.rotation = q;
        }
        
    }






}
