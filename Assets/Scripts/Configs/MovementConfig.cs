using CustomEditorAttributes;
using Data;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Movement Config", fileName = Paths.PLAYER + "Movement Config")]
    public class MovementConfig : ScriptableObject
    {
        [PimpingHeader("Settings", HeaderColor.Forest, direction: GradientDirection.Horizontal)] 
        [SerializeField] private float _movementSpeed;

        public float MovementSpeed => _movementSpeed;
    }
}