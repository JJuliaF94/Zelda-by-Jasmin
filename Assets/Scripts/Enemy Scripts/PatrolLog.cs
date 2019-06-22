using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;
  
    //we override the CheckDistance() from the log script
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
        && Vector3.Distance(target.position,
                            transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
            && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                //we dont need this here because this Enemy will always be in the walk state
                //ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }

        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)

        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
        }

    }
    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
