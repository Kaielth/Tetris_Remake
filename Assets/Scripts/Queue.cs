using UnityEngine;
using System.Collections;

public class Queue : MonoBehaviour {

	//Properties
	public int[] q;
	public int qLimit;
	public GameObject[] groups;

	// initialization
	void Start () {
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

	//Returns the current piece index in the queue and generate a new one
	public int next ()
	{
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
