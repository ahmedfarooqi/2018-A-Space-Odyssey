using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPath : MonoBehaviour
{
    public GameObject[] allPaths;

	//this is to randomly select a path to follow
	void Start ()
    {
        int num = Random.Range(0, allPaths.Length);
        transform.position = allPaths[num].transform.position;
        MoveOnEditorPath path = GetComponent<MoveOnEditorPath>();
        path.pathName = allPaths[num].name;
	}
}
