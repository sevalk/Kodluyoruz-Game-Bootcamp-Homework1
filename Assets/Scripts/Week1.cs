using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Week1 : MonoBehaviour
{
    public void Enter()
    {
        Execute();
    }

    public void Execute()
    {
        var ship = new Ship(10);
        StartCoroutine(ship.FakeUpdate(1f));
    }
}
public class Ship
{
    Gun _gun;
    public Ship(int a)
    {
        _gun = new Gun(a);
        
    }
   

    
    private void Start()
    {
         //StartCoroutine(FakeUpdate(0.2f));
       
    }


    public IEnumerator FakeUpdate(float period)
    {
        WaitForSeconds waitPeriod = new WaitForSeconds(period);
        shootController _shootcontroller = new shootController();
        Motor _motor = new Motor();
        while (true)
        {
            if (_gun._projectileCount > 0 )
            {
                if (_shootcontroller.isShooting())
                {
                    _gun.Shoot();
                }
                   
            }
            else
            {
                Debug.LogError("There is no projectile");
            }
            _motor.Move();
            _motor.Turn();

            yield return waitPeriod;
        }




    }
}
public interface IShipController
{
    void Move();
    void Turn();
}

public class Motor : IShipController
{
    motorController _motorController = new motorController();
    public void Move()
    {
        if (_motorController.isMoving())
        {
            Debug.Log("Moving");
        }
     }

    public void Turn()
    {
        if (_motorController.isTurning())
        {
            Debug.Log("Turning");
        }
       
    }
}
public interface IShooter
{
    void Shoot();
}
public class Gun : IShooter
{
    public int _projectileCount;
    
    public Gun(int projectileCount)
    {
        _projectileCount = projectileCount;
    }
    public void Shoot()
    {
            Debug.Log("Shooting");
            _projectileCount--;
            Debug.Log(_projectileCount + " Projectile left");
        
    }
}

public class shootController
{
    //bool _isShooting;
    public bool isShooting()
    {
        if (Input.GetKey("space"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class motorController
{
   // bool _isMoving;
  //  bool _isTurning;
    public bool isMoving()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isTurning()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class Projectile
{

}