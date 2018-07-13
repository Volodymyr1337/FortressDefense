using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortView : UnitView
{
    private Animator fortAnimator;

    private void Start()
    {
        fortAnimator = this.GetComponent<Animator>();
    }

    public void SetFortState(FortModel.DestructionState destructionState)
    {
        fortAnimator.SetInteger("States", (int)destructionState);
    }

}
