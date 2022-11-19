using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{

    #region Serialized field

    [SerializeField] private List<GameObject> sections;
    [SerializeField] private GameObject sectionsShop;
    [SerializeField] private GameObject lastSection;
    [SerializeField] private int sectionsBeforeShop;
    [SerializeField] private float offsetSection;

    #endregion

    #region private field

    private int shop=0;

    #endregion
    
    public void NewSection()
    {
        if (shop < sectionsBeforeShop)
        {
            shop += 1;
            int i = Random.Range(0, sections.Count);
            GameObject sec = Instantiate(sections[i], transform);
            sec.transform.position = lastSection.transform.position + new Vector3(offsetSection, 0, 0);
            lastSection = sec;
            

        }
        if(shop==sectionsBeforeShop)
        {
            GameObject sec = Instantiate(sectionsShop, transform);
            sec.transform.position = lastSection.transform.position + new Vector3(offsetSection, 0, 0);
            lastSection = sec;
            shop += 1;
        }
    }
}
