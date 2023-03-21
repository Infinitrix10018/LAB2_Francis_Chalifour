using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeJeu : MonoBehaviour
{

    private int _pointage;
    public bool _fin;
    private float _tempsTotal;
    private Player _player;
    private GestionJeu _gestionJeu;



    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>(); 
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player" && !_fin)
            {
               
                // récupére l'index de la scene
                int noScene = SceneManager.GetActiveScene().buildIndex;
            int noSceneFinale = SceneManager.sceneCountInBuildSettings;
          

                if (noScene == (SceneManager.sceneCountInBuildSettings -1)) // si au dernier niveau
                {
                _gestionJeu.setPoinage(noScene);

                // message de fin basique
                Debug.Log("Bravo! Vous avez reussi!");
                    Debug.Log("Pour finir le premier niveau vous avez pris " + _gestionJeu._tableauPoint[0,0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[0, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[0, 2] + "secondes");
                    Debug.Log("Pour finir le deuxième niveau vous avez pris " + _gestionJeu._tableauPoint[1, 0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[1, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[1, 2] + "secondes");
                    Debug.Log("Pour finir le troisième niveau vous avez pris " + _gestionJeu._tableauPoint[2, 0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[2, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[2, 2] + "secondes");
                    Debug.Log("Pour finir le jeu vous avez pris " + _gestionJeu._tableauPoint[3, 0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[3, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[3, 2] + "secondes");

                Debug.Log("fin de partie");

                    _fin = true; //fini la partie

                    _player.finPartieJoueur();
                }
                else
                {
                    _gestionJeu.setPoinage(noScene);

                    SceneManager.LoadScene(noScene + 1);
                    
                }

            }

        }
    
}
