using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Queue : MonoBehaviour {

	//Properties
	public int[] q;
	public int qLimit;
	public GameObject[] groups;
	public List<int> history;
	public float TimeFrame = 1.0f;

	// initialization
	void Start () {
		history = new List<int>();
		qLimit = 3;
		q = new int[qLimit];
		fillQ ();
	}

	//Fill the Q from any element
	private void fillQ (int i = 0)
	{
		if( i < qLimit )
		{
			newPiece (i);
			addToQueueList (i);
			fillQ (++i);
		}
	}

	//Push a new piece as the newer element and pops the older
	private void newPiece (int i)
	{
		q[i] = Random.Range (0, groups.Length);
	}

	void increaseSpeed(){
		if(TimeFrame > 0.3f)
		{
			TimeFrame = TimeFrame - 0.2f;
		}
	}

	//Returns the current piece index in the queue and generate a new one, increase the speed after the following pieces spawned: 50, 100, 150, 200 and 250
	public int next ()
	{
		history.Add (q[0]);
		switch(history.Count)
		{
		case 50:
		case 100:
		case 150:
		case 200:
		case 250:
			increaseSpeed();
			break;
		}

		int currentPiece = q[0];
		flushQueue ();
		fillQ (qLimit-1);
		return currentPiece;
	}

	//Removes the newer piece in the queue and adds the new one
	private void flushQueue ()
	{
		GameObject[] currentPieces = GameObject.FindGameObjectsWithTag ("Previous");
		Destroy(currentPieces[0]);
		rotateQ ();
	}

	//Move all the elements in the Q one position up
	private void rotateQ (int i = 0)
	{
		if( i < qLimit - 1 )
		{
			q[i] = q[++i];
			GameObject[] previousPieces = GameObject.FindGameObjectsWithTag ("Previous");
			previousPieces[i].transform.position += new Vector3(0, 5f, 0);
			rotateQ (i);
		}
	}

	//Create and place a new instance of the current piece
	private void addToQueueList (int i)
	{
		Instantiate (groups[q[i]],
		             transform.position + new Vector3(0, i * -5f, -1f),
		             Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
