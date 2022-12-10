using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfitGraph : MonoBehaviour
{
    [SerializeField] RectTransform graphContainer, xLabelTemplate, labelsContainer;

    [SerializeField] List<int> graphValues;

    [SerializeField] int valuesLimite;

    [SerializeField] float xSize, ySize;

    [SerializeField] List<Profit> profitValues;

    private void OnEnable()
    {
        foreach (Transform child in labelsContainer) Destroy(child.gameObject);
        foreach (Transform child in graphContainer) Destroy(child.gameObject);

        graphValues.Clear();

        GlobalEvents.OnDateChange.AddListener((day, week, month, year) =>
        {
            if (day == 1)
            {
                if (profitValues.Count == 0) gameObject.SetActive(false);

                AddValue();
            }
        });
    }

    private void OnDisable()
    {
        GlobalEvents.OnDateChange.RemoveListener((day, week, month, year) =>
        {
            if (day == 1)
            {
                if (profitValues.Count < 1) gameObject.SetActive(false);

                AddValue();
            }
        });
    }

    void AddValue()
    {
        int value = 0;

        if (graphValues.Count > valuesLimite) graphValues.RemoveAt(0);

        foreach (var profit in profitValues) value += profit.profitValue;

        graphValues.Add(value);
        RenderGraph();

        ActionPanel.AddMoney(value);
        ActionPanel.AddFans(Random.Range((value / 100) * 5, (value / 100) * 15));

        for (int i = 0; i < profitValues.Count; i++)
        {
            profitValues[i].DeductProfit();

            if (profitValues[i].profitValue < (profitValues[i].startProfitValue / 100) * 10) 
                profitValues.RemoveAt(i);
        }
    }

    public void AddProfitValue(Profit profit) => profitValues.Add(profit);

    void RenderGraph()
    {
        Vector2 graphSize = graphContainer.sizeDelta;

        foreach (Transform child in labelsContainer) Destroy(child.gameObject);
        foreach (Transform child in graphContainer) Destroy(child.gameObject);

        foreach (int value in graphValues)
        {
            if (value > ySize) ySize = value * 1.2f;
        }

        for (int i = 0; i < graphValues.Count; i++)
        {
            float xPosition = (i * xSize) * 9.2f;
            float yPosition = (graphValues[i] / ySize) * graphSize.y;

            GameObject newBar = CreateBar(new Vector2(xPosition, yPosition), xSize * 9);

            RectTransform xLabel = Instantiate(xLabelTemplate);

            xLabel.SetParent(labelsContainer, false);
            xLabel.gameObject.SetActive(true);
            xLabel.anchoredPosition = new Vector2(xPosition, xLabel.anchoredPosition.y);

            xLabel.GetComponent<TextTranformations>().TransformText(graphValues[i]);
        }

    }

    GameObject CreateBar(Vector2 graphPosition, float width)
    {
        GameObject bar = new GameObject("bar", typeof(Image));

        bar.GetComponent<Image>().color = new Color32(255, 110, 0, 255);

        bar.transform.SetParent(graphContainer, false);

        RectTransform rect = bar.GetComponent<RectTransform>();

        rect.anchoredPosition = new Vector2(graphPosition.x, 0);
        rect.sizeDelta = new Vector2(width, graphPosition.y);
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(0, 0);
        rect.pivot = new Vector2(0f, 0);

        return bar;
    }
}