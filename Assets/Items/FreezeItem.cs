using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an example of an ItemCore child
public class FreezeItem : ItemCore
{
    public override void ActivateEffect()
    {
        Freeze();
    }

    private void Freeze()
    {
        Debug.Log(user.name + " has frozen " + enemy.name + "!");
    }
}
