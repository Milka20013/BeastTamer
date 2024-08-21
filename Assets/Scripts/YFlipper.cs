using UnityEngine;

public class YFlipper : MonoBehaviour
{
    [SerializeField] private bool isFacingLeft;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void FlipToFaceTarget(Transform target)
    {
        if (target == null)
        {
            return;
        }
        float dot = Vector2.Dot(target.position - transform.position, transform.right);
        Debug.Log(dot);
        if ((isFacingLeft && Mathf.Sign(dot) == 1f) || (!isFacingLeft && Mathf.Sign(dot) == -1f))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            isFacingLeft = !isFacingLeft;
        }
    }
}
