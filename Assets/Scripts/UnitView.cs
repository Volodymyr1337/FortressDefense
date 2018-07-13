using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitView : MonoBehaviour
{
    public event Action<UnitView, int> OnHit = (sender, e) => { };
    public event Action<int> OnKill = (exp) => { };

    public virtual void ReceiveDamage(UnitView sender, int dmg)
    {
        OnHit(sender, dmg);
    }

    public virtual void Kill(int ExpForKill)
    {
        OnKill(ExpForKill);
    }
}
