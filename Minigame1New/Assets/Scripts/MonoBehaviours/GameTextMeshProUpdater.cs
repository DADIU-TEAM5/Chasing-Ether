using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTextMeshProUpdater : MonoBehaviour
{
    public GameText GameText;
    public TMP_Text TextObject; 

    public void Start() {
        UpdateText();
    }

    public void UpdateText() {
        TextObject.text = GameText.GetText();
    }
}
