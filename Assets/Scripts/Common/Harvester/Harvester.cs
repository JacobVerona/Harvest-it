using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Harvester : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private LayerMask _mask;

    private Level _currentLevel;

    private Sequence _sequence;

    public void Awake ()
    {
        _currentLevel = ApplicationContext.Instance.CurrentLevel;
    }

    private void OnEnable ()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnDisable ()
    {
        SwipeDetection.SwipeEvent -= OnSwipe;
    }

    public void Harvest (WheatField wheatField)
    {
        _currentLevel.RemoveField();
    }

    private void OnSwipe (Vector2 direction)
    {
        if (_sequence == null || _sequence.IsActive() == false)
        {
            if (Physics.Raycast(transform.position + _collider.center, new Vector3(direction.x, 0, direction.y), out RaycastHit hit, Mathf.Infinity, _mask))
            {
                var point = Vector3Int.RoundToInt(new Vector3((hit.point.x - direction.x) / 12f, 0, (hit.point.z - direction.y) / 12f));

                _sequence = DOTween.Sequence()
                    .Append(transform.DORotate(new Vector3(0, Vector2.SignedAngle(direction, Vector2.up), 0), 0.1f))
                    .Append(transform.DOMove(point * 12, 0.7f).SetEase(Ease.Flash));
            }
        }
    }
}