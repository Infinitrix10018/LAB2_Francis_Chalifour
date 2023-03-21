using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{   
    // tableau qui va avoir le temps, les points et le temps total.
    public float[,] _tableauPoint = new float[4,3];

    private int _pointage;


    private void Awake()
    {
        int nbrGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbrGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _pointage = 0;

        InstructionsDepart();
    }


    public void AugmenterPointage()
    {
        _pointage++;
    }

    public void setPoinage(int noScene)
    {
        int noDerniereScene = SceneManager.sceneCountInBuildSettings;

       if (noScene != 0) 
        {
            _tableauPoint[noScene, 0] = Time.time - _tableauPoint[noScene -1, 0];
            _tableauPoint[noScene, 1] = _pointage;
            _tableauPoint[noScene, 2] = _tableauPoint[noScene, 0] + _pointage;
            _pointage = 0;
        }
        else
        {
            _tableauPoint[noScene, 0] = Time.time;
            _tableauPoint[noScene, 1] = _pointage;
            _tableauPoint[noScene, 2] = _tableauPoint[noScene, 0] + _pointage;
            _pointage = 0;
        }

        _tableauPoint[noDerniereScene, 0] += _tableauPoint[noScene, 0];
        _tableauPoint[noDerniereScene, 1] += _tableauPoint[noScene, 1];
        _tableauPoint[noDerniereScene, 2] += _tableauPoint[noScene, 2];

    }



    private static void InstructionsDepart()
    {
        Debug.Log("*** Course a obstacle ***");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque obstacle qui sera touché donnera une pénalité au joueur");
    }

}
