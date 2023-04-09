using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Character : MonoBehaviour
{

    protected static void Jump(Rigidbody rigidbody, float jumpSpeed)
    {
        rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }
}
