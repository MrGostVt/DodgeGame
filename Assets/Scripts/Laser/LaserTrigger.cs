using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            other.GetComponent<Dying>().Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
