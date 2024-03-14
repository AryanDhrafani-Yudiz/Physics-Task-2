using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Joint2D joint2D;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForceAtPosition()
            rb.AddForce(joint2D.connectedBody.position);
        }
    }

}
