using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouristExitState : EnemyState
{
    Vector3 targetPos;

    public override void OnEnable()
    {
        base.OnEnable();
        GameObject[] finishlines = GameObject.FindGameObjectsWithTag("Finish");
        targetPos = finishlines[Random.Range(0, finishlines.Length)].transform.position;
        ic.move = new Vector2((transform.position.x - targetPos.x) > 0 ? -1 : 1, 0);
        
    }

    public override void Update()
    {
        Vector2 pos = Vector2.zero;
        Vector2 target = Vector2.zero;
        pos.x = transform.position.x;
        target.x = targetPos.x;

        if(Vector2.Distance(pos, target) <= .1f)
        {
            Destroy(gameObject);
        }
    }
}
