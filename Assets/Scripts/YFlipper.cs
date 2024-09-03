using UnityEngine;

public class YFlipper : MonoBehaviour
{
    [SerializeField] private bool isFacingLeft;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void FlipToFaceTarget(Collider2D target)
    {
        if (target == null)
        {
            return;
        }
        float dot = Vector2.Dot(target.transform.position - transform.position, transform.right);
        if ((isFacingLeft && Mathf.Sign(dot) == 1f) || (!isFacingLeft && Mathf.Sign(dot) == -1f))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            isFacingLeft = !isFacingLeft;
        }
    }
}
