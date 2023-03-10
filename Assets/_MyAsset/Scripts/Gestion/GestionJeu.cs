using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{   
    // tableau qui va avoir le temps, les points et le temps total.
    public float[,] _tableauPoint = new float[3,3]; 


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
        // montre l'augmentation de points.
        Debug.Log("nombre d'accrochage : " + _pointage);
    }

    private static void InstructionsDepart()
    {
        Debug.Log("*** Course a obstacle ***");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque obstacle qui sera touché donnera une pénalité au joueur");
    }

}
