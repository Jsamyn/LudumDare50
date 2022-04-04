using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target, Vector3.forward);
        // transform.RotateAround(new Vector3(transform.parent.gameObject.transform.position.x + 1, 
        //     transform.parent.gameObject.transform.position.y + 1, 0), 
        //     Vector3.forward, 45 * Time.deltaTime);
    }
}
