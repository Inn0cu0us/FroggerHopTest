using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SnapToMe : MonoBehaviour {
    
    public float speed = 0.5f;
    public Vector3 direction = -Vector3.right;
    public int NumberOfSegments = 5;
    public BoxCollider2D target; 

    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {

	}


    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3[] snapPoints = CalculateSnapPoints(NumberOfSegments, target);
        Vector3 nearestSnapPoint = FindNearest(other.transform.position, snapPoints);
        other.transform.position = nearestSnapPoint;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        other.gameObject.transform.position += movement;
    }

    Vector3[] CalculateSnapPoints(int numberOfSegments, BoxCollider2D target)
    {
        if (numberOfSegments > 0)
        {
            Vector3[] calculatedSnapPoints = new Vector3[numberOfSegments];
            float segmentWidth = target.bounds.size.x / numberOfSegments;

            for (int i = 0; i < numberOfSegments; i++)
            {
                calculatedSnapPoints[i] = new Vector3(target.bounds.min.x + (i * segmentWidth + segmentWidth / 2), target.bounds.center.y, target.bounds.center.z);                
            }
            return calculatedSnapPoints;
        }
        else
        {
            Vector3[] singleSnapPoint = new Vector3[1];
            singleSnapPoint[0] = target.bounds.center;
            return singleSnapPoint;
        }        
    }

    Vector3 FindNearest(Vector3 target, Vector3[] candidates)
    {
        Vector3 closest = new Vector3(float.MaxValue, 0.0f, 0.0f);
        float minDistanceFound = float.MaxValue;
        foreach (Vector3 candidate in candidates)
        {
            float xDistance =(target - candidate).sqrMagnitude;
            if (xDistance < minDistanceFound)
            {
                minDistanceFound = xDistance;
                closest = candidate;
            }
        }
        return closest;
    }
}
