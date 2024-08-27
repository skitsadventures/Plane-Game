using UnityEngine;

public class DemoBomb : MonoBehaviour
{
    public GameObject[] AllEffect;
    int i;
    public UnityEngine.UI.Text Text;
    public Transform mg;
    GameObject MakedObject;

    void Start()
    {
        i = 0; // Initialize i to 0 to start with the first element in the array.
        UpdateText();
    }

    void UpdateText()
    {
        if (i >= 0 && i < AllEffect.Length)
        {
            Text.text = "(" + (i + 1) + "/" + AllEffect.Length + ") " + AllEffect[i].name;
        }
        else
        {
            Text.text = "No Effect"; // Or any default text you want to show when index is out of bounds.
        }
    }


    public void InstantiateEffect()
    {
        if (MakedObject != null)
        {
            Destroy(MakedObject);
        }

        // Check if i is within the valid range.
        if (i >= 0 && i < AllEffect.Length)
        {
            MakedObject = Instantiate(AllEffect[i], AllEffect[i].transform.position, AllEffect[i].transform.rotation) as GameObject;
            UpdateText();
        }
    }
}
