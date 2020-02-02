using UnityEngine;

public class BucketInfo : MonoBehaviour
{
    public int value
    {
        get { return m_value; } set { m_value = value; OnValueChanged(); }
    }
    private int m_value;

    public float showDuration;

    public TextMesh text;
    public TextMesh outlineText;

    void OnValueChanged()
    {
        text.text = value + "%";
        outlineText.text = value + "%";
        showDuration = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (showDuration <= 0)
        {
            text.text = "";
            outlineText.text = "";
        }
        else
        {
            showDuration -= Time.deltaTime;
            transform.localEulerAngles = new Vector3(180, 0, transform.localEulerAngles.z + transform.eulerAngles.y);
        }
    }
}
