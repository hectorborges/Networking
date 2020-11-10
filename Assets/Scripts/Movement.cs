using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = move.normalized * speed * Time.deltaTime;
        cc.Move(move);
    }
}
