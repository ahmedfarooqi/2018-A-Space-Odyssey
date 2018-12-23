using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEditorPath : MonoBehaviour
{
    public EditorPathScript path;
    private int currentWayPointIndex = 0;
    public float maxSpeed;
    public float decceleration = 0.25f;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    public float loiterTimeMin = 5.0f;
    public float loiterTimeMax = 5.0f;
    private float loiterTime;
    private float remainingWaitTime;
    private bool isWaiting = false;
    private bool goingForwards = true;

	// Use this for initialization
	void Start ()
    {
        //path = GameObject.Find(pathName).GetComponent<EditorPathScript>();
        loiterTime = Random.Range(loiterTimeMin, loiterTimeMax);
        remainingWaitTime = loiterTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!isWaiting)
        {
            var rotation = Quaternion.LookRotation(-(path.pathObjs[currentWayPointIndex].position - transform.position));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            if(Quaternion.Angle(transform.rotation,rotation) < 15)
            {
                float distance = Vector3.Distance(path.pathObjs[currentWayPointIndex].position, transform.position);
                float speed = distance * decceleration + 0.5f;
                if (speed > maxSpeed)
                    speed = maxSpeed;
                transform.position = Vector3.MoveTowards(transform.position, path.pathObjs[currentWayPointIndex].position, Time.deltaTime * speed);
                if (distance <= reachDistance)
                {
                    if (goingForwards)
                        currentWayPointIndex++;
                    else
                        currentWayPointIndex--;
                }

                if ((goingForwards && (currentWayPointIndex >= path.pathObjs.Count)) || (!goingForwards && (currentWayPointIndex < 0)))
                {
                    isWaiting = true;
                }
            }
            
        }
        
        if(isWaiting)
        {
            remainingWaitTime -= Time.deltaTime;
            if (remainingWaitTime <= 0.0)
            {
                remainingWaitTime = loiterTime;
                currentWayPointIndex = goingForwards ? path.pathObjs.Count-1 : 0;
                goingForwards = !goingForwards;
                isWaiting = false;
            }
        }     
	}
}
