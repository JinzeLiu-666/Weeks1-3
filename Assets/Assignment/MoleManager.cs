using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public MoleController[] moles; // Mole array
    public float interval = 2f;    // Time interval
    private int moleCount = 0;     // Number of moles
    private float timer = 0f;      // Timer
    private bool waitingToShrink = false; // Shrinking animation
    private bool waitingToReset = false;  // Reset

    void Update()
    {
        // Wait for the last mole
        if (waitingToShrink || waitingToReset)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0f;
                if (waitingToReset)
                {
                    waitingToReset = false; // Stop waiting
                    ResetMoles(); // Reset all moles
                }
                else if (waitingToShrink)
                {
                    waitingToShrink = false; // Stop waiting
                    StartShrinkAllMoles(); // Shrinking animation
                    waitingToReset = true; // Enter reset phase
                }
            }
        }

        timer += Time.deltaTime;

        // If time reaches the interval
        if (timer >= interval)
        {
            timer = 0f;

            // Show animation
            moles[moleCount].ShowMole();

            moleCount++;

            // If all moles appear (11 in total)
            if (moleCount >= 11)
            {
                // Start waiting to shrink
                waitingToShrink = true;
            }
        }
    }

    private void StartShrinkAllMoles()
    {
        for (int i = 0; i < moles.Length; i++)
        {
            moles[i].ShrinkMole(); // Shrink all at once
        }
    }

    private void ResetMoles()
    {
        for (int i = 0; i < moles.Length; i++)
        {
            moles[i].ResetState(); // Reset all moles
        }
        moleCount = 0;
    }
}
