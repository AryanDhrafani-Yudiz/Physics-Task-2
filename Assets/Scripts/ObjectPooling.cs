using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [SerializeField] private int numberOfBuildingObject;
    [SerializeField] private List<GameObject> buildingPrefabsList;
    [SerializeField] private Transform buildingParentObject;
    [SerializeField] private int numberOfCoinObject;
    [SerializeField] private List<GameObject> coinPrefabsList;
    [SerializeField] private Transform coinParentObject;

    private int getRandomItem = 0;

    public List<GameObject> ListOfBuildingObjects;
    public List<GameObject> ListOfCoinObjects;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        CreateBuildingObjects();
        CreateCoinObjects();
    }

    public void CreateBuildingObjects() // Instantiating And Deactivating Building Objects and Adding Them To Building's List
    {
        //ListOfBuildingObjects = new();
        GameObject temp;

        for (int count = 0; count < numberOfBuildingObject;)
        {
            foreach (GameObject prefab in buildingPrefabsList)
            {
                temp = Instantiate(prefab, buildingParentObject, true);
                temp.SetActive(false);
                ListOfBuildingObjects.Add(temp);
                count++;
                if (count == numberOfBuildingObject) break;
            }
        }
    }
    public void CreateCoinObjects() // Instantiating And Deactivating Coin Objects and Adding Them To Coin's List
    {
        //ListOfCoinObjects = new();
        GameObject temp;

        for (int count = 0; count < numberOfCoinObject;)
        {
            foreach (GameObject prefab in coinPrefabsList)
            {
                temp = Instantiate(prefab, coinParentObject, true);
                temp.SetActive(false);
                ListOfCoinObjects.Add(temp);
                count++;
                if (count == numberOfCoinObject) break;
            }
        }
    }
    public GameObject BuildingObjectToPool() // Selects A Random Building Object Which Isnt Active From Heirarchy
    {
        List<GameObject> inactiveBuildingsList = new();

        for (int i = 0; i < ListOfBuildingObjects.Count; i++)
        {
            if (!ListOfBuildingObjects[i].activeInHierarchy)
            {
                inactiveBuildingsList.Add(ListOfBuildingObjects[i]);
            }
        }
        getRandomItem = Random.Range(0, inactiveBuildingsList.Count);
        return inactiveBuildingsList[getRandomItem];

    }
    public GameObject BuildingObjectToPoolStarting() // Selects Starting 3 Buildings To Spawn
    {
        for (int i = 0; i < 3; i++)
        {
            if (!ListOfBuildingObjects[i].activeInHierarchy)
            {
                return ListOfBuildingObjects[i];
            }
        }
        return null;
    }
    public GameObject CoinsObjectToPool() // Selects Inactive Coin Game Objects To Spawn
    {
        List<GameObject> inactiveCoinsList = new();

        for (int i = 0; i < ListOfCoinObjects.Count; i++)
        {
            if (!ListOfCoinObjects[i].activeInHierarchy)
            {
                inactiveCoinsList.Add(ListOfCoinObjects[i]);
            }
        }
        getRandomItem = Random.Range(0, inactiveCoinsList.Count);
        return inactiveCoinsList[getRandomItem];
    }
}