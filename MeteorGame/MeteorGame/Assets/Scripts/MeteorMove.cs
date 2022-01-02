using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    [SerializeField] float Speed;
    void Update()
    {
        transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
    }
}
