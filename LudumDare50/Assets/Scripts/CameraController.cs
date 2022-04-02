using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* Public Properties */
    public GameObject Sprite;
    public float FollowSpeed;

    /* Private Properties */
    private Vector3 delta;

    // Start is called before the first frame update
    void Start()
    {
        delta = transform.position - Sprite.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ran at the end of the frame
    /// </summary>
    void LateUpdate()
    {
        float xTarget = Sprite.transform.position.x + delta.x;
        float yTarget = Sprite.transform.position.y + delta.y;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * FollowSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * FollowSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
