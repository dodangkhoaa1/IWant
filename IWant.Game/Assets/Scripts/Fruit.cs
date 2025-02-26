using UnityEngine;
using System;

public class Fruit : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite heldSprite; // Thêm sprite cho biểu cảm khi được giữ
    [SerializeField] private Sprite droppedSprite;

    [Header(" Data ")]

    [SerializeField] private FruitType fruitType;
    private bool hasCollided;
    private bool canBeMerged;

    [Header(" Actions ")]
    public static Action<Fruit, Fruit> onCollitionWithFruit;

    [Header(" Effects ")]
    [SerializeField] private ParticleSystem mergeParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("AllowMerge", .25f);
    }
    private void AllowMerge()
    {
        canBeMerged = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveTo(Vector2 targetPosition)
    {
        transform.position = targetPosition;
        //Debug.Log("Fruit moved to: " + targetPosition);
    }
    public void EnablePhysics()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManageCollision(collision);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        ManageCollision(collision);
    }

    private void ManageCollision(Collision2D collision)
    {
        hasCollided = true;

        if (!canBeMerged)
            return;

        if (collision.collider.TryGetComponent(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != fruitType)
                return;

            if (!otherFruit.CanBeMerged())
                return;
            onCollitionWithFruit?.Invoke(this, otherFruit);
        }
    }
    public void Merge()
    {
        if (mergeParticles != null)
        {
            mergeParticles.transform.SetParent(null);
            mergeParticles.Play();
        }


        Destroy(gameObject);
    }
    public FruitType GetFruitType()
    {
        return fruitType;
    }

    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }

    public bool HasCollided()
    {
        return hasCollided;
    }
    public bool CanBeMerged()
    {
        return canBeMerged;
    }

    // Thêm phương thức để thay đổi biểu cảm khi được giữ
    public void SetHeldExpression()
    {
        if (heldSprite != null)
        {
            spriteRenderer.sprite = heldSprite; // Thay đổi sprite thành biểu cảm khi được giữ
        }
    }

    // Thêm phương thức để thay đổi biểu cảm khi được thả
    public void SetDroppedExpression()
    {
        if (droppedSprite != null)
        {
            spriteRenderer.sprite = droppedSprite; // Thay đổi sprite thành biểu cảm khi được thả
        }
    }
}
