using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public bool isAttacking;
    InputController input;

    public GameObject projectile;

    private void Awake()
    {
        input = GetComponent<InputController>();
    }

    private void Update()
    {
        if (input.action)
        {
            if(isAttacking == false)
            {
                isAttacking = true;
                OnAttack();
            }
            
        }
        else if (isAttacking)
        {
            isAttacking = false;
        }
    }

    internal void CreateProjectile(Vector2 ShootDir)
    {
        //  spawns object and sets parent
        GameObject spawnObject = Instantiate(projectile);

        //  sets transform of spawned object, user direction is used to place it on one of the entitys sides
        spawnObject.transform.position = (Vector2)gameObject.transform.position + ShootDir;

        spawnObject.GetComponent<InputController>().move = ShootDir;

        //  gets the angle from the look direction
        float angle = Mathf.Atan2(ShootDir.y, ShootDir.x) * Mathf.Rad2Deg;

        //  rotates object to face the new angle
        spawnObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public virtual void OnAttack()
    {
    }


}
