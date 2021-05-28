using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed,rotateSpeed;
    [SerializeField] Vector3 camOffset,wallCamPosition;
    public DynamicJoystick dynamicJoystick;
    public Animator anim;
    Vector3 direction;
    public bool inPlatform = true;
    Transform camTransform;
    public bool raceStarted = false;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }
    void FixedUpdate()
    {
        MoveTheBoy();
    }
    void LateUpdate()
    {
        if (inPlatform)
        {
            camTransform.position = gameObject.transform.position + camOffset;
            camTransform.rotation = Quaternion.Euler(145, 90, 180);
        }
        else
        {
            camTransform.position = Vector3.Lerp(camTransform.position, wallCamPosition,  Time.deltaTime);
            camTransform.rotation = Quaternion.Lerp(camTransform.rotation, Quaternion.Euler(180, 90, 180), Time.deltaTime);
        }
    }
    
    void MoveTheBoy()
    {
        if (inPlatform)
        {
                direction = Vector3.left * dynamicJoystick.Vertical + Vector3.forward * dynamicJoystick.Horizontal;
            if (Mathf.Abs(dynamicJoystick.Vertical) >= 0.5 || Mathf.Abs(dynamicJoystick.Horizontal) >= 0.5)
            {
                PlayerLookRotation();
                PlayRunningAnim();
            }
            else if (Mathf.Abs(dynamicJoystick.Vertical) > 0 || Mathf.Abs(dynamicJoystick.Horizontal) > 0)
            {
                PlayerLookRotation();
                PlayWalkingAnim();
            }
            else
            {
                PlayStoppingAnim();
            }
            gameObject.transform.position += direction * speed * Time.fixedDeltaTime;


            }
        else
        {
            PlayStoppingAnim();
        }
        
    }
    void PlayRunningAnim()
    {
                anim.SetBool("Stopping", false);
                anim.SetBool("Walking", false);
                anim.SetBool("Running", true);
    }
    void PlayWalkingAnim()
    {
                anim.SetBool("Stopping", false);
                anim.SetBool("Running", false);
                anim.SetBool("Walking", true);
    }
    void PlayStoppingAnim()
    {
            anim.SetBool("Running", false);
            anim.SetBool("Walking", false);
            anim.SetBool("Stopping", true);
    }
    void PlayerLookRotation (){

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.fixedDeltaTime * rotateSpeed);
    }
}
