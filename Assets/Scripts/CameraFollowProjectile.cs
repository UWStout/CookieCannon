using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowProjectile : MonoBehaviour
{
    public List<GameObject> cookies;

    private GameObject projectile;
    private bool following, isCameraSet;
    private float xOffset;
    private float timer, resetDelay = 2;
    private Vector3 startPos, secondPos;
    // Start is called before the first frame update
    void Start()
    {
        following = false;
        timer = resetDelay;
        startPos = transform.position;
        secondPos = new Vector3(GameObject.Find("Cannon2").transform.position.x - (startPos.x - GameObject.Find("Cannon").transform.position.x), 0, -10);

        isCameraSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            if (projectile == null)
            {
                following = false;
            }
            /*else if (projectile.transform.position.y <= -3)
            {
                following = false;
                timer = 0;
            }*/
            else
            {
                transform.position = new Vector3(projectile.transform.position.x + xOffset, transform.position.y, transform.position.z);
            }
        }
        else if (projectile == null && !isCameraSet)
        {
            timer = resetDelay;
            SwitchSides();
        }
        else if(timer < resetDelay)
        {
            timer += Time.deltaTime;
            if (Camera.main.orthographicSize < 6)
            {
                Camera.main.orthographicSize += 0.1f;
            }
        }
        else if(timer >= resetDelay && transform.position != startPos)
        {
            //transform.position = startPos;
            //GetComponent<Launch>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            isCameraSet = false;
            projectile = collision.gameObject;
            following = true;
            xOffset = transform.position.x - projectile.transform.position.x;
        }
    }

    public void SwitchSides()
    {
        if (GetComponent<Launch>().NextTurn() == 0)
        {
            ResetCamera();
        }
        else
        {
            SetCamera(secondPos);
        }
        isCameraSet = true;
        GetComponent<Launch>().ResetTarget();
    }

    private void ResetCamera()
    {
        transform.position = startPos;
        Camera.main.orthographicSize = 12.6f;
    }

    private void SetCamera(Vector3 position)
    {
        transform.position = position;
        Camera.main.orthographicSize = 12.6f;
    }
}
