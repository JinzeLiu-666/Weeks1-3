using UnityEngine;

public class MoleController : MonoBehaviour
{
    public GameObject moleL; // Default image
    public GameObject moleD; // Image after click
    public AnimationCurve scaleCurve; // Scale curve
    public float speed = 1f; // Scale speed

    private Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f); // Initial size
    private float animationTime = 0f; // Animation timer
    private bool isShrinking = false; // Shrinking flag
    private bool isClickable = true;  // Clickable flag

    void Start()
    {
        // Initialize size and click state
        moleL.transform.localScale = initialScale;
        moleD.transform.localScale = initialScale;
        isClickable = true;
    }

    void Update()
    {
        // Shrink the mole
        if (isShrinking)
        {
            animationTime += Time.deltaTime * speed;
            float curveValue = scaleCurve.Evaluate(animationTime);

            // Shrink mole with Lerp
            Vector3 newScale = Vector3.Lerp(initialScale, Vector3.zero, curveValue);
            moleD.transform.localScale = newScale;

            if (animationTime >= 1f)
            {
                isShrinking = false;
            }
        }
    }

    public bool IsMouseOver(Vector3 mouseWorldPosition)
    {
        // Return false if not clickable
        if (!isClickable) return false;

        // World position
        Vector3 moleWorldPosition = transform.position;

        // Distance between mouse and mole
        Vector2 mousePos2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        Vector2 molePos2D = new Vector2(moleWorldPosition.x, moleWorldPosition.y);
        float distance = (mousePos2D - molePos2D).magnitude;

        return distance <= 1f; // Click range
    }

    public void ShrinkMole()
    {
        // Return if not clickable
        if (!isClickable) return;

        // Disable clicking
        isClickable = false;

        // Hide moleL
        moleL.transform.localScale = Vector3.zero;

        isShrinking = true;
        animationTime = 0f;
    }
}
