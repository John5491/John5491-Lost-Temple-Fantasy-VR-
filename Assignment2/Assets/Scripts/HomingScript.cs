using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingScript : MonoBehaviour
{
    public Transform target;
    public float floatAmount = 3.2f;
    public float delayBeforeLaunch = 0f;
    [SerializeField]
    private float speed = 15;
    [SerializeField]
    [Range(0, 2)]
    private float rotationSpeed;
    [SerializeField]
    private float focusDistance = 5;
    private bool isFollowingTarget = true;
    
    [SerializeField]
    private bool faceTarget;
    private Vector3 tempVector;

    private float curSpeed = 0f;
    private float acceleration = 1.0f;
    private bool startMoving = false;
    private bool animating = false;
    private float floatHeight;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        floatHeight = transform.position.y + floatAmount;
        StartCoroutine(updateState());
    }

    private void Update()
    {
        if(startMoving)
        {
            if (Vector3.Distance(transform.position, target.position) < focusDistance)
            {
                isFollowingTarget = false;
            }

            Vector3 targetDirection = target.position - transform.position;

            if (faceTarget)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

                MoveForward(Time.deltaTime);

                if (isFollowingTarget)
                {
                    transform.rotation = Quaternion.LookRotation(newDirection);
                }
            }
            else
            {
                if (isFollowingTarget)
                {
                    tempVector = targetDirection.normalized;

                    transform.position = Vector3.MoveTowards(transform.position, target.position, curSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(tempVector * Time.deltaTime * curSpeed, Space.World);
                }
            }

            curSpeed += acceleration;
            if (curSpeed > speed)
                curSpeed = speed;
        }
    }

    private void FixedUpdate()
    {
        if (animating)
        {
            animate();
        }
    }

    private void MoveForward(float rate)
    {
        transform.Translate(Vector3.forward * rate * curSpeed, Space.Self);
    }

    private IEnumerator updateState()
    {
        yield return new WaitForSeconds(3f);
        animating = true;
        transform.LookAt(Camera.main.transform);
        yield return new WaitForSeconds(3f + delayBeforeLaunch);
        startMoving = true;
        animating = false;
    }

    private void animate()
    {
        transform.position = Vector3.Lerp(transform.position, new  Vector3(transform.position.x, floatHeight, transform.position.z), Time.deltaTime * 3);
    }
}
