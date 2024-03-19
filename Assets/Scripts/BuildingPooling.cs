using UnityEngine;

public class BuildingPooling : MonoBehaviour
{
    public static BuildingPooling Instance;

    [SerializeField] private Transform prefab3Position;
    [SerializeField] private Transform grapplePrefabPosition;
    private float xOffset;
    private float currBuildingPosition;
    private float currGrapplePlatformPosition;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        currBuildingPosition = prefab3Position.position.x;
        currGrapplePlatformPosition = grapplePrefabPosition.position.x;
        SpawnStartingBuilding();
        SpawnBuilding(FindNextPosition("Building"));
        SpawnGrapplePlatform(FindNextPosition("GrapplingPlatform"));
    }
    public void SpawnStartingBuilding() // Spawns Starting 5 Buildings
    {
        for (int count = 0; count < 3; count++)
        {
            GameObject Building = ObjectPooling.Instance.BuildingObjectToPoolStarting();

            if (Building != null)
            {
                Building.SetActive(true);
            }
        }
        SpawnBuilding(FindNextPosition("Building"));
        SpawnBuilding(FindNextPosition("Building"));
        SpawnGrapplePlatform(FindNextPosition("GrapplingPlatform"));
        SpawnGrapplePlatform(FindNextPosition("GrapplingPlatform"));
    }

    public void SpawnBuilding(float position) // Spawn Building At Relative Position To RightMost Building Present
    {
        GameObject Building = ObjectPooling.Instance.BuildingObjectToPool();

        if (Building != null)
        {
            Building.transform.position = new Vector3(position, Building.transform.position.y, Building.transform.position.z);
            Building.SetActive(true);
            if (Random.Range(0, 2) == 1)
            {
                SpawnCoin(Building.transform.position);
            }
        }
    }
    public float FindNextPosition(string positionForObject) // Finds Position To Spawn Next Building At , After The Rightmost Building
    {
        if (positionForObject == "Building")
        {
            xOffset = Random.Range(3.5f, 4.5f);
            currBuildingPosition = currBuildingPosition + xOffset;
            return currBuildingPosition;
        }
        else if (positionForObject == "GrapplingPlatform")
        {
            xOffset = Random.Range(5, 7);
            currGrapplePlatformPosition = currGrapplePlatformPosition + xOffset;
            return currGrapplePlatformPosition;
        }
        else return 0f;
    }
    public void SpawnCoin(Vector3 position) // Spawn Coin On Top Of Building
    {
        GameObject Coin = ObjectPooling.Instance.CoinsObjectToPool();

        if (Coin != null)
        {
            Coin.transform.position = new Vector3(position.x, position.y + 3f, position.z);
            Coin.SetActive(true);
        }
    }
    public void SpawnGrapplePlatform(float position)
    {
        GameObject GrapplingPlatform = ObjectPooling.Instance.GrappleObjectToPool();

        if (GrapplingPlatform != null)
        {
            GrapplingPlatform.transform.position = new Vector3(position, GrapplingPlatform.transform.position.y, GrapplingPlatform.transform.position.z);
            GrapplingPlatform.SetActive(true);
        }
    }
}
