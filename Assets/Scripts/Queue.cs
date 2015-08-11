using UnityEngine;
using System.Collections;

public class Queue : MonoBehaviour {

	//
	public int q;
	public GameObject[] groups;

	// Use this for initialization
	void Start () {
		newPiece ();
		addToQueueList ();
	}

	//Returns the current piece index in the queue and generate a new one
	public int next ()
	{
		int currentPiece = q;
		newPiece ();
		flushQueue ();
		return currentPiece;
	}

	private void newPiece ()
	{
		q = Random.Range (0, groups.Length);
	}

	private void flushQueue ()
	{
		GameObject[] previousPieces = GameObject.FindGameObjectsWithTag ("Previous");
		Destroy(previousPieces[0]);
		addToQueueList ();
	}

	private void addToQueueList ()
	{
		Instantiate (groups[q],
		             transform.position + new Vector3(0, 0, -1f),
		             Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
