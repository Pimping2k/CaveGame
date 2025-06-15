using System;
using Interfaces;
using Unity.Cinemachine;
using UnityEngine;

namespace Dependencies
{
    public class CameraService : MonoBehaviour, ICameraService
    {
        [SerializeField] private CinemachineCamera _camera;
        public bool IsInitialized { get; private set; }
        public CinemachineCamera Camera => _camera;
        
        private void Awake()
        {
            IsInitialized = true;
        }
    }
}