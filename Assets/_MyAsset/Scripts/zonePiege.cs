using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonePiege : MonoBehaviour
{

    private bool _activated = false;

    [SerializeField] private float _intensiteForce = 5;

    [SerializeField] private List<GameObject> _listePiege = new List<GameObject>();

    [SerializeField] private List<Rigidbody> _listeRigidBody = new List<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        // permettre que chaques pi�ge soit ajout� a la liste des pi�ges. 
        foreach(var piege in _listePiege)
        {
            _listeRigidBody.Add(piege.GetComponent<Rigidbody>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // permet d'activ� la gratit� des pi�ges si le joueur va dans la zone et que la zone n'est pas d�ja activ�e.
        if (other.gameObject.tag == "Player" && !_activated)
        {
            Vector3 direction = new Vector3(-3f, 0f, 0f);

            foreach (var rb in _listeRigidBody)
            {
                rb.useGravity = true;
                rb.AddForce(direction * _intensiteForce);
            }

            _activated = true;
        }

    }
}