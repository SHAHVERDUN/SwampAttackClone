using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _sliderFillRectangle;
    [SerializeField] private float _smoothingChangingValue;
    [SerializeField] private Gradient _gradient;

    private Coroutine _coroutineChangeSmoothlySliderValue;

    public float SliderValue => _slider.value;

    protected virtual void OnEnable()
    {
        InitializeOnEnable();
    }

    protected virtual void OnDisable()
    {
        InitializeOnDisable();
    }

    protected virtual void Start()
    {
        InitializeStart();
    }

    protected virtual void InitializeOnEnable()
    {

    }

    protected virtual void InitializeOnDisable()
    {

    }

    protected virtual void InitializeStart()
    {
        _slider.interactable = false;
    }

    protected void SetSliderMaxValue()
    {
        _slider.value = _slider.maxValue;
    }

    protected void SetSliderMinValue()
    {
        _slider.value = _slider.minValue;
    }

    protected void SetNewStateBar(float normalizedValue)
    {
        SetNewSliderValue(normalizedValue);
        SetNewFillColorForSliderRectangle(normalizedValue);
    }

    private void SetNewSliderValue(float normalizedValue)
    {
        float targetSliderValue = normalizedValue * _slider.maxValue;

        RestartCoroutineChangeSmoothlyValue(targetSliderValue);
    }

    private void SetNewFillColorForSliderRectangle(float normalizedValue)
    {
        _sliderFillRectangle.color = _gradient.Evaluate(normalizedValue);
    }

    private void RestartCoroutineChangeSmoothlyValue(float targetValue)
    {
        if (_coroutineChangeSmoothlySliderValue != null)
        {
            StopCoroutine(_coroutineChangeSmoothlySliderValue);
        }

        _coroutineChangeSmoothlySliderValue = StartCoroutine(ChangeSmoothlySliderValue(targetValue));
    }

    private IEnumerator ChangeSmoothlySliderValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _smoothingChangingValue * _slider.maxValue);

            yield return null;
        }
    }
}