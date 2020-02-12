using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    public GameObject projectile;
    public float power = 10;
    public float maxPower = 10;
    public Slider powerDisplay;

    private bool aiming;
    private List<GameObject> cannon;
    private Vector3 target, release, launchAngle;
    private int turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        cannon = new List<GameObject>();
        cannon.Add(GameObject.Find("Cannon"));
        cannon.Add(GameObject.Find("Cannon2"));
        aiming = false;
    }

    /*private void OnEnable()
    {
        if (Input.GetMouseButton(0))
        {
            aiming = true;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target = Input.mousePosition;
            target.z = 0;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aiming = true;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target = Input.mousePosition;
            target.z = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            aiming = false;
            release = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //release = Input.mousePosition;
            release.z = 0;

            launchAngle = target - release;
            if(launchAngle.magnitude > maxPower)
            {
                launchAngle.Normalize();
                launchAngle *= maxPower;
            }
            Object.Instantiate(projectile, cannon[turn].transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce((launchAngle)*power);

            target = cannon[turn].transform.position;

            this.enabled = false;
        }
        if (aiming)
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 currentPos = Input.mousePosition;
            currentPos.z = 0;
            if ((target - currentPos).y >= 0)
            {
                cannon[turn].transform.rotation = Quaternion.AngleAxis(Vector3.Angle(target - currentPos, Vector3.right), Vector3.forward);
            }
            else
            {
                cannon[turn].transform.rotation = Quaternion.AngleAxis(-Vector3.Angle(target - currentPos, Vector3.right), Vector3.forward);
            }

            powerDisplay.value = (target - currentPos).magnitude;
        }
    }

    public int NextTurn()
    {
        ++turn;
        if(turn >= cannon.Count)
        {
            turn = 0;
        }
        return turn;
    }

    public void ResetTarget()
    {
        if (Input.GetMouseButton(0))
        {
            aiming = true;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target = Input.mousePosition;
            target.z = 0;
        }
    }
}
