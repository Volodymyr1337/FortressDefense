using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashView : MonoBehaviour
{
    public SplashView Splash()
    {
        this.GetComponent<Animator>().SetTrigger("Splash");
        return this;
    }
    /// <summary>
    /// вызывается в последнем фрейме анимации
    /// </summary>
    public void ReturnToSplashPool()
    {
        SplashPool.Instance.ReturnSplash(gameObject);
    }
}
