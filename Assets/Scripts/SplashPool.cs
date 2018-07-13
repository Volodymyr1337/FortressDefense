using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPool : MonoBehaviour
{
    public static SplashPool Instance;

    [SerializeField] private GameObject splashPrefab;

    private List<GameObject> splashList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (splashPrefab == null)
            splashPrefab = Resources.Load("SplashObj") as GameObject;

        splashList = new List<GameObject>();

        ReturnSplash(Instantiate(splashPrefab, transform));
    }

    public GameObject GetSplash()
    {
        splashList.RemoveAll(item => item == null);
        if (splashList.Count == 0)
            ReturnSplash(Instantiate(splashPrefab, transform));

        GameObject splash = splashList[0];
        splashList.Remove(splash);
        return splash.GetComponent<SplashView>().Splash().gameObject;
    }

    public void ReturnSplash(GameObject splash)
    {
        splash.transform.parent = transform;
        splash.transform.localPosition = Vector3.zero;
        splashList.Add(splash);
    }

}
