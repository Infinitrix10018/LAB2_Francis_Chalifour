using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule : MonoBehaviour
{
    [SerializeField] private float _vitesse = 400.0f;
    [SerializeField] private float _direction_x = 4.0f;
    [SerializeField] private float _direction_y = 0f;
    [SerializeField] private float _direction_z = 0f;
    private Rigidbody _rb;
    private bool _positif;


    public bool _active = false;

    private void Start()
    {

        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Walls")
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate()
    {

        Vector3 mouvement = new Vector3(_direction_x, _direction_y, _direction_z);

        // le mouvement des véhicules si le vehicule est activé.
        if (_active && _positif)
        {
            _rb.velocity = mouvement * Time.fixedDeltaTime * _vitesse;
        }
        else if (_active && !_positif)
        {
            _rb.velocity = mouvement * Time.fixedDeltaTime * _vitesse * -1;
        }

    }

    // methode pour les faire changer de direction de mouvement.
    public void ChangeDirection()
    {
        if (_positif)
        {
            _positif = false;
        }
        else
            _positif = true;
    }

    public void Active()
    {
        _active = true;
    }

}
