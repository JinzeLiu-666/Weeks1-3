using UnityEngine;

public class MoleController : MonoBehaviour
{
    public GameObject moleL;
    public GameObject moleD;

    public AnimationCurve scaleCurve; // Scaling curve
    public float speed = 1f;          // Scaling speed

    private Vector3 initialScale;     // Initial size
    private Vector3 targetScale = new Vector3(1f, 1f, 1f); // Target size
    private float animationTime = 0f; // Timer
    private bool isAppearing = false; // Is appearing
    private bool isShrinking = false; // Is shrinking

    void Start()
    {
        moleL.SetActive(true);
        moleD.SetActive(false);

        // Set the initial size to invisible
        initialScale = Vector3.zero;
        transform.localScale = initialScale;
    }

    void Update()
    {
        // Scaling up logic
        if (isAppearing)
        {
            // Add animation time to make the animation play continuously
            animationTime += Time.deltaTime * speed;

            // Calculate the current animation progress using the animation curve (range: 0 to 1)
            float curveValue = scaleCurve.Evaluate(animationTime);

            // Use the interpolation function to scale the mole from its initial size to the target size
            transform.localScale = Vector3.Lerp(initialScale, targetScale, curveValue);

            if (animationTime >= 1f)
            {
                isAppearing = false; // Stop the appearing animation
            }
        }

        // Scaling down logic(same logic)
        if (isShrinking)
        {
            animationTime += Time.deltaTime * speed;
            float curveValue = scaleCurve.Evaluate(animationTime);
            transform.localScale = Vector3.Lerp(targetScale, initialScale, curveValue);

            if (animationTime >= 1f)
            {
                isShrinking = false;
                ResetState(); // Reset the state
            }
        }
    }

    void OnMouseDown()
    {
        moleL.SetActive(false);
        moleD.SetActive(true);
    }

    public void ResetState()
    {
        // Reset the images and state
        transform.localScale = initialScale;
        moleL.SetActive(true);
        moleD.SetActive(false);
    }

    public void ShowMole()
    {
        isAppearing = true;
        isShrinking = false;
        animationTime = 0f;
    }

    public void ShrinkMole()
    {
        isShrinking = true;
        isAppearing = false;
        animationTime = 0f;
    }
}
