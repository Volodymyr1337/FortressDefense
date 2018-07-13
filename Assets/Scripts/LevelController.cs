using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public GameObject enemySpot;

    public event Action OnLevelCleared = () => { };
    public event Action OnLevelLoss = () => { };

    [SerializeField] private GameObject[] defSpawnPoints;
    
    private List<DefenderController> defenderControllers = new List<DefenderController>();
    private List<EnemyController> enemyControllers = new List<EnemyController>();
    private FortController fortController;

    public LevelModel[] LevelModels;
    private int CurrentGameLevel;

    private List<GameObject> objectsToClear = new List<GameObject>();
    
    public void InitCurrentLevel(int level)
    {
        ClearLevel();
        
        CurrentGameLevel = level;
        DefenderSetting defenderSetting = Resources.Load<DefenderSetting>("DefenderSetting");
        DefenderViewFactory defenderViewFactory = new DefenderViewFactory(defSpawnPoints);
        DefenderViewUi[] defenderViewUiList = FindObjectsOfType<DefenderViewUi>();
        FortView fortView = FindObjectOfType<FortView>();
        fortView.OnKill += OnKillEnemy;
        for (int i = 0; i < defenderViewFactory.Views.Count; i++)
        {
            objectsToClear.Add(defenderViewFactory.Views[i].gameObject);
            defenderControllers.Add(new DefenderController(defenderViewFactory.Views[i], new DefenderModel(defenderSetting), defenderViewUiList[i]));
            defenderViewFactory.Views[i].OnKill += OnKillEnemy;
        }

        EnemySetting enemySettings = Resources.Load<EnemySetting>("EnemySetting");
        EnemyViewFactory EnemyViewFactory = new EnemyViewFactory(LevelModels[CurrentGameLevel].EnemiesOnLevelCount, enemySpot);
        LevelModels[CurrentGameLevel].InitCurrentLevel(enemySettings.ExpForKill, LevelClearedGameOver);

        if (fortController != null)
            fortController.Init(FindObjectOfType<FortView>(), FindObjectOfType<FortViewUi>(), LevelModels[CurrentGameLevel]);
        else
        {
            FortController.OnFortDestroyed += LevelLossGameOver;
            fortController = new FortController(fortView, FindObjectOfType<FortViewUi>(), LevelModels[CurrentGameLevel]);
        }

        foreach (var view in EnemyViewFactory.Views)
        {
            objectsToClear.Add(view.gameObject);
            EnemyController enemyController = new EnemyController(view, new EnemyModel(enemySettings));
            foreach (var defender in defenderControllers)
            {
                enemyController.OnDie += defender.OnTargetDieHandler;
            }
            enemyControllers.Add(enemyController);
        }
    }
    private void ClearLevel()
    {
        defenderControllers.Clear();
        enemyControllers.Clear();
        objectsToClear.RemoveAll(obj => obj == null);
        foreach (var item in objectsToClear)
        {
            Destroy(item);
        }
        objectsToClear.Clear();
        Time.timeScale = 1;
    }
    private void LevelClearedGameOver()
    {
        OnLevelCleared();
    }

    private void LevelLossGameOver()
    {
        Time.timeScale = 0;
        new ShowWinLoseModalCommand(false, LevelModels[CurrentGameLevel]).Execute();
    }

    private void OnKillEnemy(int exp)
    {
        LevelModels[CurrentGameLevel].CurrentScore += exp;
        
        if (LevelModels[CurrentGameLevel].EnemiesLeft > 0)
            LevelModels[CurrentGameLevel].EnemiesLeft--;        
    }
}

[Serializable]
public class LevelModel
{
    private Action onLevelCleared;

    public int EnemiesOnLevelCount;
    private int currentEnemiesCount;
    public int EnemiesLeft
    {
        get
        {
            return currentEnemiesCount;
        }
        set
        {
            currentEnemiesCount = value;
            if (currentEnemiesCount <= 0)
            {
                onLevelCleared();
            }
        }
    }
    public int MaxScore { get; private set; }
    public int CurrentScore { get; set; }

    public void InitCurrentLevel(int maxScore, Action onLevelCleared)
    {
        CurrentScore = 0;
        EnemiesLeft = EnemiesOnLevelCount;
        MaxScore = maxScore * EnemiesOnLevelCount;
        this.onLevelCleared = onLevelCleared;
    }
}