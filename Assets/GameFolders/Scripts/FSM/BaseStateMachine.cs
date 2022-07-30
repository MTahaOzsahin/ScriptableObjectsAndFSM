using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] BaseState _initialState;
        Dictionary<Type, Component> _cachedComponents;
        private void Awake()
        {
            CurrentState = _initialState;
            _cachedComponents = new Dictionary<Type, Component>();
        }
        public BaseState CurrentState { get; set; }
        private void Update()
        {
            CurrentState.Execute(this);
        }
        public new T GetComponent<T>() where T : Component
        {
            if (_cachedComponents.ContainsKey(typeof(T)))
                return _cachedComponents[typeof(T)] as T;

            var component = base.GetComponent<T>();
            if (component != null)
            {
                _cachedComponents.Add(typeof(T), component);
            }
            return component;
        }
    }
}
