using UnityEngine;

public class MergePushEffect : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float pushRadius;
    [SerializeField] private Vector2 minMaxPushMagnitude;
    [SerializeField] private float pushMagnitude;
    private Vector2 pushPosition;

    [Header(" DEBUG ")]
    [SerializeField] private bool enableGizmos;

    private void Awake()
    {
        MergeManager.onMergeProcess += MergeProcessedCallBack;
    }
    private void OnDestroy()
    {
        MergeManager.onMergeProcess -= MergeProcessedCallBack;
    }
    private void MergeProcessedCallBack(FruitType fruitType, Vector2 mergePos)
    {
        pushPosition = mergePos;

      Collider2D[] colliders =  Physics2D.OverlapCircleAll(mergePos, pushRadius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Fruit fruit))
            {
                Vector2 force = ((Vector2)fruit.transform.position - mergePos).normalized;
                force *= pushMagnitude;

                fruit.GetComponent<Rigidbody2D>().AddForce(force);
            }
        }   
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (!enableGizmos)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pushPosition, pushRadius);
    }
#endif
}
