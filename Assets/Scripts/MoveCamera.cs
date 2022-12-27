using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject target;

    private bool isRotateLHeld=false;
    private bool isRotateRHeld=false;
    private bool isInHeld=false;
    private bool isOutHeld=false;
    private bool isUpHeld=false;
    private bool isDownHeld=false;
    private bool isLeftHeld=false;
    private bool isRightHeld=false;

    void Update() 
    {
        if(isRotateLHeld)
            rotateLeft();
        if(isRotateRHeld)
            rotateRight();
        if(isInHeld)
            getClose();
        if(isOutHeld)
            goFar();
        if(isUpHeld)
            goUp();
        if(isDownHeld)
            goDown();
        if(isLeftHeld)
            goLeft();
        if(isRightHeld)
            goRight();
    } 
    
    private void rotateRight()
    {
        mainCamera.transform.RotateAround(target.transform.position, Vector3.down, 30 * Time.deltaTime);
    }

    private void rotateLeft()
    {
        mainCamera.transform.RotateAround(target.transform.position, Vector3.up, 30 * Time.deltaTime);
    }

    private void getClose()
    {
        Camera.main.fieldOfView = Camera.main.fieldOfView-(float)0.4;
    }

    private void goFar()
    {
        Camera.main.fieldOfView = Camera.main.fieldOfView+(float)0.4;
    }

    private void goUp()
    {
         Vector3 pos=mainCamera.transform.position;
         pos.y=pos.y+(float)0.4;
         mainCamera.transform.position=pos;
    }

    private void goDown()
    {
        Vector3 pos=mainCamera.transform.position;
        pos.y=pos.y-(float)0.4;
        mainCamera.transform.position=pos;
    }

    private void goRight()
    {
        Vector3 pos=mainCamera.transform.position;
        pos.x=pos.x+(float)0.4;
        mainCamera.transform.position=pos; 
    }

    private void goLeft()
    {
        Vector3 pos=mainCamera.transform.position;
        pos.x=pos.x-(float)0.4;
        mainCamera.transform.position=pos;
    }

    public void holdRotateL()
    {
        isRotateLHeld=true;
    }

    public void releaseRotateL()
    {
        isRotateLHeld=false;
    }

    public void holdRotateR()
    {
        isRotateRHeld=true;
    }

    public void releaseRotateR()
    {
        isRotateRHeld=false;
    }

    public void holdIn()
    {
        isInHeld=true;
    }

    public void releaseIn()
    {
        isInHeld=false;
    }

    public void holdOut()
    {
        isOutHeld=true;
    }

    public void releaseOut()
    {
        isOutHeld=false;
    }

    public void holdUp()
    {
        isUpHeld=true;
    }

    public void releaseUp()
    {
        isUpHeld=false;
    }

    public void holdDown()
    {
        isDownHeld=true;
    }

    public void releaseDown()
    {
        isDownHeld=false;
    }

    public void holdRight()
    {
        isRightHeld=true;
    }

    public void releaseRight()
    {
        isRightHeld=false;
    }

    public void holdLeft()
    {
        isLeftHeld=true;
    }

    public void releaseLeft()
    {
        isLeftHeld=false;
    }

}
