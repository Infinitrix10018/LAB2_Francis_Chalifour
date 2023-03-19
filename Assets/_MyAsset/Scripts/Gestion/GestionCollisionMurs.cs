using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollisionMurs : MonoBehaviour
{
    private bool _touche;

    private float _tempsTouche = 0;

    private GestionJeu _gestionJeu;


    // Start is called before the first frame update
    void Start()
    {
        _touche = false;

        _gestionJeu = FindObjectOfType<GestionJeu>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!_touche)
            {
                _gestionJeu.AugmenterPointage();

                _tempsTouche = Time.time;
                _tempsTouche += 4;
                _touche = true;
                GetComponent<MeshRenderer>().material.color= Color.red;


            }
        }
    }


    private void FixedUpdate()
    {
        //remet l'obstacle en jeu après 4 secondes
        if(_touche )
        {
            if ( _tempsTouche == Time.time)
            {   
                //Debug.Log("test");
                _touche= false;
                GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }
    }
}
