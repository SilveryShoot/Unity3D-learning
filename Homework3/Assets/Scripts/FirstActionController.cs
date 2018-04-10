using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class FirstActionController : SSActionManager {

    public void toggleBoat(BoatController boat)
    {
        MoveAction action = MoveAction.getAction(boat.getDestination(), boat.speed);
        this.addAction(boat.getGameobj(), action, this);
        boat.Move();
    }

    public void moveCharacter(MyCharacterController character, Vector3 target)
    {
        Vector3 nowPos = character.getPos();
        Vector3 tmpPos = nowPos;
        if (target.y > nowPos.y)
        {
            tmpPos.y = target.y;
        }
        else
        {
            tmpPos.x = target.x;
        }
        SSAction action1 = MoveAction.getAction(tmpPos, character.speed);
        SSAction action2 = MoveAction.getAction(target, character.speed);
        SSAction sequenceAction = CCSequenceAction.getAction(1, 0, new List<SSAction> { action1, action2 });
        this.addAction(character.getGameobj(), sequenceAction, this);
    }
}
