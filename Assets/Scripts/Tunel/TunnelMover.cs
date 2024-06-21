using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMover : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isMove = false;
    [SerializeField] private float _speed = 25;
    void Start()
    {
        
    }
    public void SpeedUp()
    {
        _speed += 0.005f;
    }
    public void StartMove()
    {
        _isMove = true;
    }
    private void Move()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 temp = transform.GetChild(i).position;
            temp.z -= (_speed ) * Time.deltaTime;
            transform.GetChild(i).position = temp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_isMove)
        {
            Move();

        }
    }
}
