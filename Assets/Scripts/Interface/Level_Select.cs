using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Level_Select : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public Level_Status levelInfo;
    public Transform center;
    public GameObject levelContext, buttonBackLevel, buttonBackMenu;
    GameObject lastSelected;
    public GameObject objective1, objective2;
    public Image ingredientLevel;
    public List<Sprite> ingredientSprite;
    public Text levelName, description;
    float min = 3f, max; 
    static float t = 0f;
    
    //public Fase_Management loadLevel;

    void Awake()
    {
        //levelInfo = null;
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        max = min + 2f;
        cam.m_Follow = center;
        levelContext.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hit)
                    {
                        GameObject check = hit.collider.gameObject;
                        if (check.CompareTag("Level"))
                        {
                            levelInfo = check.GetComponent<Level_Status>();
                        
                            //if (!levelInfo.completed)

                            if (lastSelected != null && lastSelected != check)
                            {
                                // If the current object is different from the last selected object, set isSelected to false for the last selected object
                                Level_Status lastSelectedLevelInfo = lastSelected.GetComponent<Level_Status>();
                                lastSelectedLevelInfo.isSelected = false;
                            }

                            if (!levelInfo.isSelected)
                            {
                                levelInfo.isSelected = true;
                                levelName.text = levelInfo.levelNm;
                                description.text = levelInfo.desc;
                                ingredientLevel.GetComponent<Image>().sprite = ingredientSprite[levelInfo.levelId - 1];

                                if (ingredientSprite[levelInfo.levelId - 1] == null) 
                                {
                                    ingredientLevel.sprite = null;
                                }
                                
                                Focus(check.transform);

                                if (levelInfo.completed)
                                {
                                    ingredientLevel.color = Color.white;
                                }
                                else
                                {
                                    ingredientLevel.color = Color.black;
                                }
                                switch (levelInfo.objectivesDone)
                                {
                                    case 1:
                                        objective1.SetActive(true);
                                    break;

                                    case 2:
                                        objective1.SetActive(true);
                                        objective2.SetActive(true);
                                    break;

                                    default:
                                        objective1.SetActive(false);
                                        objective2.SetActive(false);
                                    break;
                                }
                            }
                            else
                            {
                                // loadLevel.SceneLoadObject(levelInfo.levelNm);
                            }

                            // Update the last selected object to the current object
                            lastSelected = check;
                        }
                    }
                break;
            }
        }
    }
    public void Focus(Transform obj)
    {
        buttonBackLevel.SetActive(true);
        buttonBackMenu.SetActive(false);

        cam.m_Follow = obj;
        StopAllCoroutines();
        StartCoroutine(Zoom(cam.m_Lens.OrthographicSize,min));
        levelContext.SetActive(true);
    }
    public void Back()
    {
        if (cam.m_Lens.OrthographicSize > 4f)
        {
            buttonBackLevel.SetActive(false);
            buttonBackMenu.SetActive(true);
        }
        

        if (levelInfo != null)
        {
            levelInfo.isSelected = false;
        }
        cam.m_Follow = center;
        StopAllCoroutines();
        StartCoroutine(Zoom(cam.m_Lens.OrthographicSize,max));
        levelContext.SetActive(false);
    }
    IEnumerator Zoom(float start, float end)
    {
        t = 0f;

        while(cam.m_Lens.OrthographicSize != end)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(start,end,t);
            t += 1f * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}