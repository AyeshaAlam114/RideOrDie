using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePositionFixer : MonoBehaviour
{
    //public Transform ground;
    public List<GameObject> vehiclesInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, 0.06000018f, this.transform.position.z);
    }
}
