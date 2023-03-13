using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement_obstacle : MonoBehaviour
{

    [serializedField] private float _direction_x;
    [serializedField] private float _direction_y;
    [serializedField] private float _direction_z;

    Vector3 direction = new Vector3(_direction_x, _direction_y, _direction_z); 


    private void FixedUpdate()
    {
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }

    public void ChangeDirection()
    {
        direction *= -1;
    }

    


}
