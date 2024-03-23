using System;
using UnityEngine;

public class CounterUI
{
    [SerializeField] private Counter _counter;

    public CounterUI(Counter counter) =>
        _counter = counter ?? throw new ArgumentNullException(nameof(counter));

    public void ShowInfoInConsole() =>
        Debug.Log(_counter);
}
