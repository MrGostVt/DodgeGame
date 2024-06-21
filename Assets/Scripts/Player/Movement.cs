using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _player;
    private Animator _animator;
    private string[] animations = { "IsRight", "IsLeft" };
    private bool[] directions  = { false, false };



    private void Start()
    {

        _player = transform.gameObject;
        _animator = _player.GetComponent<Animator>();

    }
    private void SetAnimation(int id)
    {

        Debug.Log("Animation" + id + " " + directions[id]);
 

        _animator.SetBool(animations[id], directions[id] == true ? false : true); ;
        directions[id] = !directions[id];
        //_animator.SetBool(animations[1], isIdle == true ? true : false);
        //isIdle = !isIdle;

    }
    public void OnAnimationEnd()
    {
        Vector3 tempPos = transform.position;
        Quaternion tempRot = transform.rotation;
        SetAnimation(directions[0] == true? 0: 1);



        //_animator.transform.position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetAnimation(0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetAnimation(1);
        }
    }
}
