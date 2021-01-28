using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BananaHudController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI bananaText;
    // Start is called before the first frame update
    public void TextUpdate(int value)
    {
        bananaText.text = value.ToString();
    }
}
