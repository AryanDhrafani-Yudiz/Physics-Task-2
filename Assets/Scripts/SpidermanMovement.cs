using UnityEngine;

public class SpidermanMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private DistanceJoint2D currentJoint2D;
    [SerializeField] private float distanceChange;
    [SerializeField] private Vector2 forceDirection;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentJoint2D.distance += distanceChange;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentJoint2D.distance -= distanceChange;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.AddForce(myJoint.connectedBody.position);
            //rb.AddForce(forceDirection);
            //rb.AddForce(transform.position);
            rb.velocity -= new Vector2(0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.AddForce(-myJoint.connectedBody.position);
            //rb.AddForce(-forceDirection);
            //rb.AddForce(-transform.position);
            rb.velocity += new Vector2(0.1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentJoint2D.connectedBody = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                currentJoint2D = hit.collider.gameObject.GetComponent<DistanceJoint2D>();
                currentJoint2D.connectedBody = rb;
            }
        }
    }

}
