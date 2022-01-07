using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    [SerializeField] float Speed;
    void Update()
    {
        // I just made meteor fall in 'y' axis
        transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
    }
}
