using System;
using System.Collections;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
   

    [Header(" Actions ")]
    public static Action<FruitType, Vector2> onMergeProcess;

    [Header(" Settings ")]

    Fruit lastSender;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Fruit.onCollitionWithFruit += CollisionBetweenFruitsCallback;
    }

    private void OnDestroy()
    {
        Fruit.onCollitionWithFruit -= CollisionBetweenFruitsCallback;   
    }
     void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void CollisionBetweenFruitsCallback(Fruit sender, Fruit otherFruit)
    {
        if (lastSender != null)
            return;

        lastSender = sender;

        ProcessMerge(sender, otherFruit);

        //Debug.Log("Collision detected by " + sender.name);

    }

    private void ProcessMerge(Fruit sender, Fruit otherFruit)
    {

        FruitType mergeFruitType = sender.GetFruitType();
        mergeFruitType += 1;

        Vector2 fruitSpawnPos = (sender.transform.position + otherFruit.transform.position) / 2;

        sender.Merge();
        otherFruit.Merge();

        StartCoroutine(DelayedDestroy(sender.gameObject));
        StartCoroutine(DelayedDestroy(otherFruit.gameObject));

        StartCoroutine(ResetLastSenderCoroutine());

        onMergeProcess?.Invoke(mergeFruitType, fruitSpawnPos);
    }
    private IEnumerator DelayedDestroy(GameObject obj)
    {
        yield return new WaitForEndOfFrame();
        Destroy(obj);
    }
    IEnumerator ResetLastSenderCoroutine()
    {
        yield return new WaitForEndOfFrame();
        lastSender = null;
    }
}
