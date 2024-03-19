using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    // Buildings
    [SerializeField] private int numberOfBuildingObject;
    [SerializeField] private List<GameObject> buildingPrefabsList;
    [SerializeField] private Transform buildingParentObject;
    // Coins
    [SerializeField] private int numberOfCoinObject;
    [SerializeField] private List<GameObject> coinPrefabsList;
    [SerializeField] private Transform coinParentObject;
    // Grappling Platforms
    [SerializeField] private int numberOfGrappleObject;
    [SerializeField] private List<GameObject> grapplePrefabsList;
    [SerializeField] private Transform grappleParentObject;

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
    public void CreateBuildingObjects() // Instantiating And Deactivating Building Objects and Adding Them To Building's List
    {
        GameObject temp;

        for (int count = 0; count < numberOfBuildingObject;)
        {
            foreach (GameObject prefab in buildingPrefabsList)
            {
                temp = Instantiate(prefab, buildingParentObject, true);
                temp.SetActive(false);
                ListOfAllBuildingObjects.Add(temp);
                count++;
                if (count == numberOfBuildingObject) break;
            }
        }
    }
    public void CreateCoinObjects() // Instantiating And Deactivating Coin Objects and Adding Them To Coin's List
    {
        GameObject temp;

        for (int count = 0; count < numberOfCoinObject;)
        {
            foreach (GameObject prefab in coinPrefabsList)
            {
                temp = Instantiate(prefab, coinParentObject, true);
                temp.SetActive(false);
                ListOfAllCoinObjects.Add(temp);
                count++;
                if (count == numberOfCoinObject) break;
            }
        }
    }
    public void CreateGrappleObjects() // Instantiating And Deactivating Grapple Platform Objects and Adding Them To Grapple Platform's List
    {
        GameObject temp;

        for (int count = 0; count < numberOfGrappleObject;)
        {
            foreach (GameObject prefab in grapplePrefabsList)
            {
                temp = Instantiate(prefab, grappleParentObject, true);
                temp.SetActive(false);
                ListOfAllGrappleObjects.Add(temp);
                count++;
                if (count == numberOfGrappleObject) break;
            }
        }
    }

    public GameObject BuildingObjectToPool() // Selects A Random Building Object Which Isnt Active From Heirarchy
    {
        List<GameObject> inactiveBuildingsList = new();

        for (int i = 0; i < ListOfAllBuildingObjects.Count; i++)
        {
            if (!ListOfAllBuildingObjects[i].activeInHierarchy)
            {
                inactiveBuildingsList.Add(ListOfAllBuildingObjects[i]);
            }
        }
        getRandomItem = Random.Range(0, inactiveBuildingsList.Count);
        return inactiveBuildingsList[getRandomItem];

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
    public GameObject CoinsObjectToPool() // Selects Inactive Coin Game Objects To Spawn
    {
        List<GameObject> inactiveCoinsList = new();

        for (int i = 0; i < ListOfAllCoinObjects.Count; i++)
        {
            if (!ListOfAllCoinObjects[i].activeInHierarchy)
            {
                inactiveCoinsList.Add(ListOfAllCoinObjects[i]);
            }
        }
        getRandomItem = Random.Range(0, inactiveCoinsList.Count);
        return inactiveCoinsList[getRandomItem];
    }
    public GameObject GrappleObjectToPool() // Selects Inactive Coin Game Objects To Spawn
    {
        List<GameObject> inactiveGrappleList = new();

        for (int i = 0; i < ListOfAllGrappleObjects.Count; i++)
        {
            if (ListOfAllGrappleObjects[i] != null)
            {
                if (!ListOfAllGrappleObjects[i].activeInHierarchy)
                {
                    inactiveGrappleList.Add(ListOfAllGrappleObjects[i]);
                }
            }
        }
        getRandomItem = Random.Range(0, inactiveGrappleList.Count);
        return inactiveGrappleList[getRandomItem];
    }
}