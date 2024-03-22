using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    // Buildings
    [SerializeField] private int numberOfBuildingObject;
    [SerializeField] private List<GameObject> buildingPrefabsList;
    [SerializeField] private Transform buildingParentTransform;
    // Coins
    [SerializeField] private int numberOfCoinObject;
    [SerializeField] private List<GameObject> coinPrefabsList;
    [SerializeField] private Transform coinParentTransform;
    // Grappling Platforms
    [SerializeField] private int numberOfGrappleObject;
    [SerializeField] private List<GameObject> grapplePrefabsList;
    [SerializeField] private Transform grappleParentTransform;

    private int getRandomItem = 0;

    public List<GameObject> ListOfAllBuildingObjects;
    public List<GameObject> ListOfAllCoinObjects;
    public List<GameObject> ListOfAllGrappleObjects;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        CreateBuildingObjects();
        CreateCoinObjects();
        CreateGrappleObjects();
    }
    private void CreateObjects(int numberOfObject, List<GameObject> PrefabsList, Transform objectParentTransform, List<GameObject> ListOfAllCurrentObjects)
    {
        GameObject temp;

        for (int count = 0; count < numberOfObject;)

        {
            foreach (GameObject prefab in PrefabsList)
            {
                temp = Instantiate(prefab, objectParentTransform, true);
                temp.SetActive(false);
                ListOfAllCurrentObjects.Add(temp);
                count++;
                if (count == numberOfObject) break;
            }
        }
    }
    public void CreateBuildingObjects() // Instantiating And Deactivating Building Objects and Adding Them To Building's List
    {
        CreateObjects(numberOfBuildingObject, buildingPrefabsList, buildingParentTransform, ListOfAllBuildingObjects);
    }
    public void CreateCoinObjects() // Instantiating And Deactivating Coin Objects and Adding Them To Coin's List
    {
        CreateObjects(numberOfCoinObject, coinPrefabsList, coinParentTransform, ListOfAllCoinObjects);
    }
    public void CreateGrappleObjects() // Instantiating And Deactivating Grapple Platform Objects and Adding Them To Grapple Platform's List
    {
        CreateObjects(numberOfGrappleObject, grapplePrefabsList, grappleParentTransform, ListOfAllGrappleObjects);
    }
    private GameObject ObjectsToPool(List<GameObject> ListOfAllCurrentObjects)
    {
        List<GameObject> inactiveObjectsList = new();

        for (int i = 0; i < ListOfAllCurrentObjects.Count; i++)
        {
            if (!ListOfAllCurrentObjects[i].activeInHierarchy)
            {
                inactiveObjectsList.Add(ListOfAllCurrentObjects[i]);
            }
        }
        getRandomItem = Random.Range(0, inactiveObjectsList.Count);
        return inactiveObjectsList[getRandomItem];
    }
    public GameObject BuildingObjectToPool() // Selects A Random Building Object Which Isnt Active From Heirarchy
    {
        return ObjectsToPool(ListOfAllBuildingObjects);
    }
    public GameObject CoinsObjectToPool() // Selects Inactive Coin Game Objects To Spawn
    {
        return ObjectsToPool(ListOfAllCoinObjects);
    }
    public GameObject GrappleObjectToPool() // Selects Inactive Coin Game Objects To Spawn
    {
        return ObjectsToPool(ListOfAllGrappleObjects);
    }
    public GameObject BuildingObjectToPoolStarting() // Selects Starting 3 Buildings To Spawn
    {
        for (int i = 0; i < 3; i++)
        {
            if (!ListOfAllBuildingObjects[i].activeInHierarchy)
            {
                return ListOfAllBuildingObjects[i];
            }
        }
        return null;
    }
}