using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        InitializeOnEnable();
    }

    private void OnDisable()
    {
        InitializeOnDisable();
    }

    private void Start()
    {
        InitializeStart();
    }

    private void InitializeOnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnSetNextWave);
    }

    private void InitializeOnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnSetNextWave);
    }

    private void InitializeStart()
    {
        _nextWaveButton.gameObject.SetActive(false);
    }

    private void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnSetNextWave()
    {
        _spawner.SetNextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}