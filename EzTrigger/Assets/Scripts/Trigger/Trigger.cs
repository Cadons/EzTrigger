using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
namespace EzTrigger
{


    [RequireComponent(typeof(BoxCollider))]
    public class Trigger : MonoBehaviour
    {
        [Header("Trigger Callbacks")]
        //Tree UnityEvents 
        [SerializeField]
        private UnityEngine.Events.UnityEvent _onEnter;
        [SerializeField]
        private UnityEngine.Events.UnityEvent _onExit;
        [SerializeField]
        private UnityEngine.Events.UnityEvent _onStay;

        public UnityEngine.Events.UnityEvent OnEnter { get => _onEnter; set => _onEnter = value; }
        public UnityEngine.Events.UnityEvent OnExit { get => _onExit; set => _onExit = value; }
        public UnityEngine.Events.UnityEvent OnStay { get => _onStay; set => _onStay = value; }

        private Dictionary<string, Collider> _colliders = new Dictionary<string, Collider>()
    {
        { "Enter", null },
        { "Exit", null },
        { "Stay", null }
    };


        [SerializeField, HideInInspector]
        private bool _anyTag = false;
        public bool AnyTag { get => _anyTag; set => _anyTag = value; }
        [SerializeField, HideInInspector]
        [TagField]

        private List<string> _targetTag = new List<string>();

        public List<string> TargetTag { get => _targetTag; set => _targetTag = value; }

        [Header("Trigger Scene Color")]
        [SerializeField]
        private Color _triggerColor = Color.green;
        private Collider _collider;
        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.enabled = true;
            _collider.isTrigger = true;
        }
        private bool CheckTag(string tag)
        {
            foreach (string target_tag in _targetTag)
            {
                if (tag.Equals(target_tag))
                {
                    return true;
                }
            }
            return false;
        }
        public void OnTriggerEnter(Collider other)
        {
            _colliders["Enter"] = other;
            if (_anyTag || CheckTag(other.tag))
            {
                _onEnter.Invoke();
            }

        }

        public void OnTriggerExit(Collider other)
        {
            _colliders["Exit"] = other;
            if (_anyTag || CheckTag(other.tag))
            {
                _onExit.Invoke();
            }

        }

        public void OnTriggerStay(Collider other)
        {
            _colliders["Stay"] = other;
            if (_anyTag || CheckTag(other.tag))
            {
                _onStay.Invoke();
            }

        }
        public Collider GetColliderOfTheEvent(string eventName)
        {
            Collider collider = null;
            _colliders.TryGetValue(eventName, out collider);
            return collider;
        }
        protected void OnDrawGizmos()
        {


            gameObject.GetComponent<BoxCollider>().center = Vector3.zero;
            Gizmos.color = _triggerColor;

            Gizmos.DrawWireCube(transform.position, gameObject.GetComponent<BoxCollider>().size);
        }

    }
}