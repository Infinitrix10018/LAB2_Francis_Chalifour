using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   [SerializeField] private float _rotation = 1f; //vitesse de rotation de base

   public bool _active = false;

    void FixedUpdate()
    {
        if(_active)
        {
            transform.Rotate(0f, _rotation, 0f); // permet de faire la rotation sur l'ace des "y".
        }
        
    }

}
