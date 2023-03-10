using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollisionMurs : MonoBehaviour
{
    private bool _touche;

    private float _tempsTouche = 0;


    // Start is called before the first frame update
    void Start()
    {
        _touche = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!_touche)
            {
                _tempsTouche = Time.time;
                _tempsTouche += 4;
                _touche = true;
                GetComponent<MeshRenderer>().material.color= Color.red;


            }
        }
    }

    // Update is called once per frame
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
