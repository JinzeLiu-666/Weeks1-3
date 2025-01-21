using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public MoleController[] moles;

    void Start()
    {

    }

    void Update()
    {
        // check mouse cleck
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (var mole in moles)
            {
                if (mole.IsMouseOver(mousePosition))
                {
                    mole.ShrinkMole(); // shrinking
                }
            }
        }
    }
}
