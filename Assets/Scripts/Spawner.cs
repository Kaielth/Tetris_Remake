using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//Groups
	public GameObject[] groups;

	public void spawnNext ()
	{
		//Spawn Group at the current Position
		Instantiate (groups[FindObjectOfType<Queue>().next()],
		             transform.position,
		             Quaternion.identity);
	}

	void Start()
	{
		// Initial spawn group
		spawnNext ();
	}


}
