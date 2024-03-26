using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight 
{
    private Inhabitant thePlayer;
    private Inhabitant theMonster;
    private GameObject thePlayerGO;
    private GameObject theMonsterGO;
    private Rigidbody rigidBodyOfAttacker;
    private float attackMoveDistance = -2.5f;
    private Vector3 attackerOriginalPosition;
    private Inhabitant currentAttacker;
    private GameObject currentAttackerGO;
    private Inhabitant currentTarget;
    private GameObject currentTargetGO;
    private MonoBehaviour fightController;

    public Fight(Inhabitant thePlayer, Inhabitant theMonster, GameObject thePlayerGO, GameObject theMonsterGO, MonoBehaviour fightController)
    {
        this.thePlayer = thePlayer;
        this.theMonster = theMonster;
        this.thePlayerGO = thePlayerGO;
        this.theMonsterGO = theMonsterGO;
        this.currentAttacker = this.thePlayer;
        this.currentAttackerGO = this.thePlayerGO;
        this.currentTarget = this.theMonster;
        this.currentTargetGO = this.theMonsterGO;
        this.fightController = fightController;
    }

    IEnumerator MoveObjectRoutine()
    {
        Vector3 originalPosition = this.attackerOriginalPosition;
        Vector3 targetPosition = originalPosition + this.currentAttackerGO.transform.forward * attackMoveDistance;

        this.rigidBodyOfAttacker.MovePosition(targetPosition);

        yield return new WaitForSeconds(0.5f);

        this.rigidBodyOfAttacker.MovePosition(originalPosition);

        if(Random.Range(1, 20) >= this.currentTarget.getAC())
        {
            this.currentAttacker.setDamage(Random.Range(1,6));
            this.currentTarget.takeDamage(this.currentAttacker.getDamage());
        }

        yield return new WaitForSeconds(0.5f);
        ((fightController)this.fightController).updateHP();

        if(currentTarget.isDead())
        {
            this.fightController.StopCoroutine(MoveObjectRoutine());
        }
        else
        {
            this.fight();
        }
    }


    public void fight()
    {
            this.attackerOriginalPosition = this.currentAttackerGO.transform.position;
            this.rigidBodyOfAttacker = this.currentAttackerGO.GetComponent<Rigidbody>();
            //this.attackMoveDistance *= -1;

            if (this.currentAttackerGO == this.thePlayerGO)
            {
                this.currentAttackerGO = this.theMonsterGO;
                this.currentAttacker = this.theMonster;
                this.currentTarget = this.thePlayer;
                this.currentTargetGO = this.thePlayerGO;
            }
            else
            {
                this.currentAttackerGO = this.thePlayerGO;
                this.currentAttacker = this.thePlayer;
                this.currentTarget = this.theMonster;
                this.currentTargetGO = this.theMonsterGO;
            }

            this.fightController.StartCoroutine(MoveObjectRoutine());
    }
}
