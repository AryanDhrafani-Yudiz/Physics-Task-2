using UnityEngine;

public class BuildingCoinActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // When GameObject Or Camera Gets Out Of Camera's ViewPort , Doesnt Work If Scene View Is On or Shadows Are Being Casted
    {
        if (gameObject.CompareTag("Building"))
        {
            gameObject.SetActive(false);
            BuildingPooling.Instance.SpawnBuilding(BuildingPooling.Instance.FindNextPosition());
        }
        if (gameObject.CompareTag("Coin"))
        {
            gameObject.SetActive(false);
        }
    }
}