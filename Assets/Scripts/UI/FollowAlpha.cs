using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FollowAlpha : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text1.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, GetComponent<Image>().color.a);
        image1.GetComponent<Image>().color = new Color(1, 1, 1, GetComponent<Image>().color.a);
        image2.GetComponent<Image>().color = new Color(1, 1, 1, GetComponent<Image>().color.a);
    }
}
