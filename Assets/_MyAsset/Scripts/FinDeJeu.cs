using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeJeu : MonoBehaviour
{

    private int _pointage;

    public bool _fin;

    private float _tempsTotal;

    private int _numeroScene;


    // Start is called before the first frame update
    void Start()
    {
        float _numeroScene = SceneManager.sceneCount;
    }

    // Update is called once per frame
    void Update()
    {
        //if (_fin)
        //{
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        //}

    }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {

                // récupére l'index de la scene
                int noScene = SceneManager.GetActiveScene().buildIndex;
                float _numeroScene = SceneManager.sceneCount;

                //debug de test.
                Debug.Log(--_numeroScene);

                if (noScene == _numeroScene)
                {
                // message de fin basique
                    Debug.Log("Bravo! Vous avez reussi! Vous avez pris " + Time.time + " secondes pour compléter la course et vous avez accrocher " + _pointage + " obstacle(s), pour un temps total de " + _tempsTotal + "secondes");


                    Debug.Log("fin de partie");
                }
                else
                {
                    SceneManager.LoadScene(noScene + 1);
                }

            }

        }
    
}
