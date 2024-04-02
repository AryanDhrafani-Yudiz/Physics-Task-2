using UnityEngine;

public class ObjectActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // When GameObject Or Camera Gets Out Of Camera's ViewPort , Doesnt Work If Scene View Is On or Shadows Are Being Casted
    {
        Debug.Log("Inside-OnBecameInvisible");
        if (gameObject.CompareTag("Building"))
        {
            gameObject.SetActive(false);
            BuildingPooling.Instance.SpawnBuilding(BuildingPooling.Instance.FindNextPosition("Building"));
        }
        else if (gameObject.CompareTag("GrapplePlatform"))
        {
            gameObject.SetActive(false);
            BuildingPooling.Instance.SpawnGrapplePlatform(BuildingPooling.Instance.FindNextPosition("GrapplingPlatform"));
        }
        else gameObject.SetActive(false);
    }
}