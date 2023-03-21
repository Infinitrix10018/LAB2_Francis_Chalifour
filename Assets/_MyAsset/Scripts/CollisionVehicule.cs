using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVehicule : MonoBehaviour
{

    [SerializeField] private List<GameObject> _listeComposant = new List<GameObject>();
    [SerializeField] private List<MeshRenderer> _listeMeshRenderer = new List<MeshRenderer>();

    private bool _touche;
    private float _tempsTouche = 0;
    private GestionJeu _gestionJeu;


    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        // permettre que chaques piège soit ajouté a la liste des pièges. 
        foreach (var piege in _listeComposant)
        {
            _listeMeshRenderer.Add(piege.GetComponent<MeshRenderer>());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_touche)
            {
                _gestionJeu.AugmenterPointage();

                _tempsTouche = Time.time;
                _tempsTouche += 4;
                _touche = true;

                foreach (var mesh in _listeComposant)
                {
                    mesh.GetComponent<MeshRenderer>().material.color = Color.red;
                    //GetComponent<MeshRenderer>().material.color = Color.red;
                }

            }
        }
    }

    private void FixedUpdate()
    {
        //remet l'obstacle en jeu après 4 secondes
        if (_touche)
        {
            if (_tempsTouche == Time.time)
            {
                //Debug.Log("test");
                _touche = false;
                foreach (var mesh in _listeComposant)
                {
                    mesh.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    //GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }
    }
