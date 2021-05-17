using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTran;       //Ö÷½ÇµÄTransform
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY = new Vector2(-8, 8);
    // Start is called before the first frame update
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position .x)>maxDistanceX )
        
            bMove = true;
        
        else
            bMove = false;
        return bMove;
    }
    private bool NeedMoveY()
    {
        bool aMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > maxDistanceY)

            aMove = true;
        else
            aMove = false;
        return aMove;
    }
    void Start()
    {
        
    }
    private void Awake()
    {
        playerTran = GameObject.Find("Hero").transform;
        //playerTran = GameObject.FindGameObjectsWithTag("Player").trans
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        if (NeedMoveX())
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x,
                xSpeed * Time.deltaTime);
        newX = Mathf.Clamp(newX, minXandY.x, maxXandY.x);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
}
