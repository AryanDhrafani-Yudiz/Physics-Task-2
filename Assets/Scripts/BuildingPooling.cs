using UnityEngine;

public class BuildingPooling : MonoBehaviour
{
    public static BuildingPooling Instance; // Singleton

    [SerializeField] private Transform prefab3Position;
    private float xOffset;
    private float currPosition;
    private int count = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        currPosition = prefab3Position.position.x;
        SpawnStartingBuilding();
        SpawnBuilding(FindNextPosition());
        SpawnBuilding(FindNextPosition());
        SpawnBuilding(FindNextPosition());
    }
    public void SpawnStartingBuilding() // Spawns Starting 3 Buildings
    {
        while(count<3)
        {
            GameObject Building = ObjectPooling.Instance.BuildingObjectToPoolStarting();

            if (Building != null)
            {
                Building.SetActive(true);
            }
            count++;
        }
    }

    public void SpawnBuilding(float position1) // Spawn Building At Relative Position To RightMost Building Present
    {
        GameObject Building = ObjectPooling.Instance.BuildingObjectToPool();

        if (Building != null)
        {
            Building.transform.position = new Vector3(position1 , Building.transform.position.y , Building.transform.position.z);
            Building.SetActive(true);
            if (Random.Range(0,2) == 1)
            {
            SpawnCoin(Building.transform.position);
            }
        }
    }
    public float FindNextPosition() // Finds Position To Spawn Next Building At , After The Rightmost Building
    {
        xOffset = Random.Range(3.5f, 4.5f);
        currPosition = currPosition + xOffset;
        return currPosition;
    }
    public void SpawnCoin(Vector3 position) // Spawn Coin On Top Of Building
    {
        GameObject Coin = ObjectPooling.Instance.CoinsObjectToPool();

        if (Coin != null)
        {
            Coin.transform.position = new Vector3(position.x , position.y + 3f , position.z);
            Coin.SetActive(true);
        }
    }
}
