using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed = 5;
    private static bool playerExists = false;
    // Use this for initialization
    void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        return;
        Vector3 pos = followTarget.transform.position;
        targetPos = new Vector3(pos.x, pos.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos,
            moveSpeed * Time.deltaTime);
    }
}
