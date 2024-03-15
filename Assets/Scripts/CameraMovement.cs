using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speedForCameraMovement;
    [SerializeField] private float xOffset;

    public IEnumerator LerpFunction(float duration) 
    {
        float time = 0;
        Vector3 startValue = transform.position;
        Vector3 endValue = new Vector3(playerTransform.position.x + xOffset, transform.position.y, -10f);
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startValue, endValue,speedForCameraMovement * (time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = endValue;
    }
}
