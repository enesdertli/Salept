using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondImageConfig : MonoBehaviour
{

    [SerializeField] Sprite fullSprite;
    [SerializeField] Transform diamondAmount;
    [SerializeField] GameObject emptySprite;
    private void Start()
    {
        for (int i = 0; i < diamondAmount.childCount; i++) {
            Instantiate(emptySprite, transform);
        }
    }

    void Update()
    {
        for (int i = 0; i < FindObjectOfType<PlayerMovement>().GetDiamondAmount(); i++) {
            transform.GetChild(i).GetComponent<Image>().sprite = fullSprite;
        }
    }
}
