using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* Public Properties */
    public GameObject Sprite;
    public float FollowSpeed;

    /* Private Properties */
    private Vector3 _delta;

    // Start is called before the first frame update
    void Start()
    {
        _delta = transform.position - Sprite.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ran at the end of the frame
    /// </summary>
    void FixedUpdate()
    {
        float xTarget = Sprite.transform.position.x + _delta.x;
        float yTarget = Sprite.transform.position.y + _delta.y;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * FollowSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * FollowSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
