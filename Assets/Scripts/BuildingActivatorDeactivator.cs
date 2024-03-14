using UnityEngine;

public class BuildingActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // When GameObject Gets Out Of Camera's ViewPort , Doesnt Work If Scene View Is On or Shadows Are Being Casted
        {
            gameObject.SetActive(false);
            BuildingPooling.Instance.SpawnBuilding(BuildingPooling.Instance.FindNextPosition());
        }
}
