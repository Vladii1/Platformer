using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShadow : MonoBehaviour {
    
    public GameObject shadow;
    public LayerMask notToHit;

    public float minScaleRatio;
    public float maxDistance;

    float maxScaleX;
    float maxScaleY;

    float oneUnitScaleDifferenceX;
    float oneUnitScaleDifferenceY;
    // Use this for initialization
    void Start ()
    {
        maxScaleX = shadow.transform.localScale.x;
        maxScaleY = shadow.transform.localScale.y;

        float minScaleX =  (maxScaleX * minScaleRatio) / 1;
        float minScaleY = (maxScaleY * minScaleRatio / 1);

        float scaleDifX = maxScaleX - minScaleX;
        float scaleDifY = maxScaleY - minScaleY;

        oneUnitScaleDifferenceX = scaleDifX / maxDistance;
        oneUnitScaleDifferenceY = scaleDifY / maxDistance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 250f, notToHit);
        shadow.transform.localPosition = hit.point;

        //print("Hit Distance: " + hit.distance);
        //print("Scale diff per unit: " + oneUnitScaleDifferenceX + ", " + oneUnitScaleDifferenceY);

        if (hit.distance < maxDistance)
        {
            shadow.transform.localScale = new Vector3(maxScaleX - (oneUnitScaleDifferenceX * hit.distance), maxScaleY - (oneUnitScaleDifferenceY * hit.distance), 0);
        }
        else
        {
            shadow.transform.localScale = new Vector3(maxScaleX - (oneUnitScaleDifferenceX * maxDistance), maxScaleY - (oneUnitScaleDifferenceY * maxDistance), 0);

        }

        if (hit.collider != null)
        {
            print("Hit object: " + hit.collider.transform.position);
            

        }
        else print("collider is null");

        
        Debug.DrawRay(transform.position, Vector2.down);
	}
}
