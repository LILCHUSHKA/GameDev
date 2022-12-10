using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockGraph : MonoBehaviour
{
    [SerializeField] RectTransform graphContainer, stockPanel, xLabelTemplate, yLabelTemplate, yLineTemplate;

    [SerializeField] RectTransform labelsContainer;

    [SerializeField] float xSize, ySize;

    [SerializeField] int xLabelCount = 4, yLabelCount = 5;

    private void OnEnable() => ySize = 0;

    GameObject SpawnValueDot(Vector2 position)
    {
        GameObject dot = new GameObject("dot", typeof(Image));

        dot.transform.SetParent(graphContainer, false);

        RectTransform rect = dot.GetComponent<RectTransform>();

        rect.anchoredPosition = position;
        rect.sizeDelta = new Vector2(0, 0);
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(0, 0);

        return dot;
    }

    void RenderLines()
    {
        for (int i = 0; i < yLabelCount; i++)
        {
            RectTransform yLine = Instantiate(yLineTemplate);

            yLine.SetParent(graphContainer, false);
            yLine.gameObject.SetActive(true);
            yLine.anchoredPosition = new Vector2(yLine.anchoredPosition.x, (i * (1f / yLabelCount)) * stockPanel.sizeDelta.y);

            if (i == 0) yLine.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        }
    }

    public void ShowGraph(List<int> valuesList)
    {
        Vector2 graphSize = graphContainer.sizeDelta;

        foreach (Transform child in labelsContainer) Destroy(child.gameObject);
        foreach (Transform child in graphContainer) Destroy(child.gameObject);

        foreach (int value in valuesList)
        {
            if (value > ySize) ySize = value * 1.2f;
        }

        GameObject lastDot = null;

        for (int i = 0; i < valuesList.Count; i++)
        {
            float xPosition = i * xSize;
            float yPosition = (valuesList[i] / ySize) * graphSize.y;

            GameObject newDot = SpawnValueDot(new Vector2(xPosition, yPosition));

            if (lastDot != null)
            {
                GameObject newLine = CreateValuesConnection(lastDot.GetComponent<RectTransform>().anchoredPosition,
                    newDot.GetComponent<RectTransform>().anchoredPosition);
            }

            lastDot = newDot;
        }

        RenderXLabels();
        RenderYLabels();
        RenderLines();
    }

    GameObject CreateValuesConnection(Vector2 aPos, Vector2 bPos)
    {
        GameObject connectionObject = new GameObject("ConnectionObject", typeof(Image));

        connectionObject.GetComponent<Image>().color = Color.green;
        connectionObject.transform.SetParent(graphContainer, false);

        RectTransform rect = connectionObject.GetComponent<RectTransform>();

        Vector2 dir = (bPos - aPos).normalized;

        float distance = Vector2.Distance(aPos, bPos);

        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(0, 0);
        rect.sizeDelta = new Vector2(distance, 3f);
        rect.anchoredPosition = aPos + dir * distance * .5f;
        rect.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));

        return connectionObject;
    }

    void RenderXLabels()
    {
        for (int i = 0; i < xLabelCount; i++)
        {
            if (i > 0)
            {
                RectTransform xLabel = Instantiate(xLabelTemplate);

                float normalizedValue = i * (1f / xLabelCount);

                xLabel.SetParent(labelsContainer, false);
                xLabel.gameObject.SetActive(true);
                xLabel.anchoredPosition = new Vector2(normalizedValue * labelsContainer.sizeDelta.x, xLabel.anchoredPosition.y);

                xLabel.GetComponent<Text>().text = (GameTime.year - (4 - i)).ToString();
            }
        }
    }

    void RenderYLabels()
    {
        for (int i = 0; i < yLabelCount + 1; i++)
        {
            if (i > 0)
            {
                RectTransform yLabel = Instantiate(yLabelTemplate);

                float normalizedValue = i * (1f / yLabelCount);

                yLabel.SetParent(labelsContainer, false);
                yLabel.gameObject.SetActive(true);
                yLabel.anchoredPosition = new Vector2(yLabel.anchoredPosition.x, normalizedValue * labelsContainer.sizeDelta.y);

                yLabel.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * ySize).ToString();
            }

        }
    }

    float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}