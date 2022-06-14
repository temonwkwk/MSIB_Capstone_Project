using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    //Moving Platform = Platform bergerak secara otomatis looping pada array yang telah ditentukan
    //automatic = true;

    public Vector3[] points;
    public int point_number = 0;
    private Vector3 current_target;

    public float tolerance;
    public float speed;
    public float delay_time;

    private float delay_start;

    public bool automatic;   //jika true = looping/moving


    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != current_target)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }

    }

    private void Update()
    {
        if(tolerance != 0.08f)
        {
            tolerance = 0.08f;
        }
    }

    void MovePlatform()
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }
    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }
    }
    public void NextPlatform()
    {
        point_number++;
        if (point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }

    public void ReturnPlatform()
    {
        point_number--;
        if (point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("TriggerObject") || other.CompareTag("Box"))
        {
            other.transform.parent = transform;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("TriggerObject") || other.CompareTag("Box"))
        {
            other.transform.parent = GameManager.instance.gameObject.transform;
        }
    }
}
