using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _base;
    private TunnelCreater _creater;
    private TunnelMover _mover;
    private bool isStarted = false;
    private Vector3 _startPosition;
    void Start()
    {
        _base = transform.gameObject;
        _creater = transform.GetComponent<TunnelCreater>();
        _mover = transform.GetComponent<TunnelMover>();
        _startPosition = transform.GetChild(0).position;
        _creater.CreateNext(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStarted && Input.GetKeyDown(KeyCode.Space))
        {
            _mover.StartMove();
            isStarted = true;

        }
        if (isStarted)
        {
            Transform child = transform.GetChild(0);
            if(child.position.z + child.GetChild(0).localScale.x <= _startPosition.z)
            {
                _creater.DestroyOld();
                
            }
        }
    }
}
