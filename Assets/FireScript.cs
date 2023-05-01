using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("button clicked");
        }
    }
}
