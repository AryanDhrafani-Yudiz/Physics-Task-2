using UnityEngine;

public class ObjectActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // When GameObject Or Camera Gets Out Of Camera's ViewPort , Doesnt Work If Scene View Is On or Shadows Are Being Casted
    {
        if (gameObject.CompareTag("Building"))
        {
            gameObject.SetActive(false);
            BuildingPooling.Instance.SpawnBuilding(BuildingPooling.Instance.FindNextPosition("Building"));
        }
        else gameObject.SetActive(false);
    }
}