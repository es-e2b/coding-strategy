﻿#nullable enable


using UnityEngine.Events;

namespace CodingStrategy.Entities.CodingTime
{
    using UnityEngine;
    using System.Collections;

    public class CodingTimeExecutor : LifeCycleMonoBehaviourBase, ILifeCycle
    {
        public int Countdown = 20;

        private int _current = 0;

        public void Awake()
        {
            LifeCycle = this;
        }

        public UnityEvent<int, int> OnCountdownChange { get; } = new UnityEvent<int, int>();

        public void Initialize()
        {
            _current = Countdown;
        }

        public bool MoveNext()
        {
            return _current >= 0;
        }

        public bool Execute()
        {
            _current -= 1;
            return true;
        }

        public void Terminate() {}

        protected override IEnumerator OnAfterInitialization()
        {
            Debug.Log("CodingTimeExecutor Started.");
            yield return null;
        }

        protected override IEnumerator OnBeforeExecution()
        {
            if (_current == 1)
            {
                Debug.Log("1 Second Left.");
            }
            else
            {
                Debug.LogFormat("{0} Seconds Left.", _current);
            }

            yield return null;
        }

        protected override IEnumerator OnAfterFailExecution()
        {
            yield return null;
        }

        protected override IEnumerator OnAfterExecution()
        {
            yield return new WaitForSecondsRealtime(1.0f);
            OnCountdownChange.Invoke(_current + 1, _current);
        }

        protected override IEnumerator OnAfterTermination()
        {
            Debug.Log("CodingTimeExecutor Terminated.");
            yield return null;
        }
    }
}
