using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private SpringJoint2D playerSpringJoint2D;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerSpringJoint2D = GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        if (playerSpringJoint2D.connectedBody != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, playerSpringJoint2D.connectedBody.position);
        }
    }
}
