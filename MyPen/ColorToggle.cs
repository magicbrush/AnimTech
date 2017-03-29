using UnityEngine;
using UnityEngine.UI;

public class ColorToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle PureColorToggle, MultiColorToggle;


    void Start()
    {
        PureColorToggle.onValueChanged.AddListener(OnValChangedPure);
        MultiColorToggle.onValueChanged.AddListener(OnValChangedMulti);
    }

    void OnValChangedPure(bool check)
    {
        if (check) {
            GameObject.Find("PureColorToggle").GetComponent<Toggle>().isOn = true;
            GameObject.Find("MultiColorToggle").GetComponent<Toggle>().isOn = false;
                }
    }
    void OnValChangedMulti(bool check)
    {
        if (check)
        {
            GameObject.Find("PureColorToggle").GetComponent<Toggle>().isOn = false;
            GameObject.Find("MultiColorToggle").GetComponent<Toggle>().isOn = true;
        }
    }
}