using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private float _delay;

    private CounterUI _counterUI;
    private int _value;
    private bool _isActive;

    private void Reset() =>
        _delay = 0.5f;

    private void Awake() =>
        _counterUI = new CounterUI(this);

    private void Start() =>
        StartCoroutine(IncreaseValueByOne(_delay));

    private void Update() =>
        SetActive();

    private void SetActive()
    {
        if (Input.GetMouseButtonDown(0))
            _isActive = _isActive == false;
    }

    private IEnumerator IncreaseValueByOne(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            if (_isActive)
            {
                _value++;
                _counterUI.ShowInfoInConsole();

                yield return wait;
            }

            yield return null;
        }
    }

    public override string ToString() =>
        _value.ToString();
}
