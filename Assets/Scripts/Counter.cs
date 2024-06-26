using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _delay;

    private IEnumerator _coroutine;
    private CounterUI _counterUI;
    private int _value;
    private bool _isActive;

    private void Reset() =>
        _delay = 0.5f;

    private void Awake() =>
        _counterUI = new CounterUI(this);

    private void Start() =>
        _coroutine = IncreaseValueByOne(_delay);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isActive = !_isActive;

            if (_isActive)
                StartCoroutine(_coroutine);
            else
                StopCoroutine(_coroutine);
        }
    }

    public override string ToString() =>
        _value.ToString();

    private IEnumerator IncreaseValueByOne(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _value++;
            _counterUI.ShowInfoInConsole();

            yield return wait;
        }
    }
}
