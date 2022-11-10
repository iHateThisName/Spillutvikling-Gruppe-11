using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

	public Transform player;

	[Header("Tower Walls")]
	public GameObject wallPrefab;
	public float currentWallHeight;
	public float wallHeight = 11.5f;
	public float distanceBeforeWallSpawn = 10f;
	public int amountOfWalls = 10;
	public List<GameObject> wallList;

	[Header("Floors")]
	public GameObject floorPrefab;
	public float currentFloorHeight;
	public float distanceBetweenBlocks = 4f;
	public float distanceBeforeFloorSpawn = 10f;
	public int amountOfFloors = 20;
	public List<GameObject> floorList;

	private void Awake()
	{
		AmountOfWalls();
		AmountOfFloors();	
	}

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

	private void SpawnTowerWalls()
	{
		wallList[0].transform.position = new Vector2(0, currentWallHeight);
		currentWallHeight += wallHeight;

		GameObject temp = wallList[0];
		wallList.RemoveAt(0);
		wallList.Add(temp);
	}

	private void SpawnFloors()
	{
		floorList[0].transform.position = new Vector2(Random.Range(-5, 5), currentFloorHeight);
		currentFloorHeight += distanceBetweenBlocks;

		GameObject temp = floorList[0];
		floorList.RemoveAt(0);
		floorList.Add(temp);
	}

}
