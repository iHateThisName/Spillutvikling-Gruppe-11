using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class acts like a controller for the tower.
/// It should extend the walls and generate new floors the higher the player comes.
/// </summary>
public class TowerManager : MonoBehaviour {
	[Tooltip("The players transform")]
	public Transform player;

	[Header("Tower Walls")]
    [Tooltip("The wall prefab object to be used as walls")]
    public GameObject wallPrefab;
    [Tooltip("The current height of the wall")]
    public float currentWallHeight;
    [Tooltip("The height to extend the wall with.")]
    public float wallHeight = 11.5f;
    [Tooltip("The distance from the top of the walls to the player before extending")]
    public float distanceBeforeWallSpawn = 10f;
    [Tooltip("The amount of walls to generate per extend")]
    public int amountOfWalls = 10;
    [Tooltip("The list of walls")]
    public List<GameObject> wallList;

	[Header("Floors")]
    [Tooltip("The floor prefab object to be used as floors to be jumped on")]
    public GameObject floorPrefab;
    [Tooltip("The current height of the floor")]
    public float currentFloorHeight;
    [Tooltip("The distance per floor generated.")]
    public float distanceBetweenBlocks = 4f;
    [Tooltip("The distance that is required before the floor spawns")]
    public float distanceBeforeFloorSpawn = 10f;
    [Tooltip("The amount of floors to generate")]
    public int amountOfFloors = 20;
    [Tooltip("The list of floors")]
    public List<GameObject> floorList;

	/// <summary>
	/// This method is called when the script instance is being loaded.
	/// </summary>
	private void Awake()
	{
		AmountOfWalls();
		AmountOfFloors();	
	}
	/// <summary>
	/// This method is called for every frame, as long as MonoBehaviour is being used.
	/// </summary>
	private void Update()
	{
		if (currentWallHeight - player.position.y < distanceBeforeWallSpawn)
		{
			SpawnTowerWalls();
		}

		if(currentFloorHeight - player.position.y < distanceBeforeFloorSpawn)
		{
			SpawnFloors();
		}
	}
	/// <summary>
	/// This method is called when the walls shall be extended.
	/// </summary>
	private void AmountOfWalls()
	{
		for (int i = 0; i < amountOfWalls; ++i)
		{
			Vector2 pos = new Vector2(0, currentWallHeight);
			GameObject go = Instantiate(wallPrefab, pos, Quaternion.identity, transform);
			wallList.Add(go);
			currentWallHeight += wallHeight;
		}
	}

    /// <summary>
    /// This method is called to determine when the walls should be extended.
    /// </summary>
    private void SpawnTowerWalls()
	{
		wallList[0].transform.position = new Vector2(0, currentWallHeight);
		currentWallHeight += wallHeight;

		GameObject temp = wallList[0];
		wallList.RemoveAt(0);
		wallList.Add(temp);
    }

    /// <summary>
    /// This method is called when the player are close to reaching the top of the floors.
    /// This method will generate more floors to be jumped on.
    /// </summary>
    private void AmountOfFloors()
    {
        for (int i = 0; i < amountOfFloors; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-5, 5), currentFloorHeight);
            GameObject go = Instantiate(floorPrefab, pos, Quaternion.identity, transform);
            floorList.Add(go);
            currentFloorHeight += distanceBetweenBlocks;
        }
    }

    /// <summary>
    /// This method is called to determine when the floors should be generated.
    /// </summary>
    private void SpawnFloors()
	{
		floorList[0].transform.position = new Vector2(Random.Range(-5, 5), currentFloorHeight);
		currentFloorHeight += distanceBetweenBlocks;

		GameObject temp = floorList[0];
		floorList.RemoveAt(0);
		floorList.Add(temp);
	}

}
