using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller uic;

    [SerializeField] List<Base_UIPanel> panels = new List<Base_UIPanel>();
    Base_UIPanel _currentPanel;

    void Start()
    {
        TriggerOpenPanel(panels[0]);
    }

    public void TriggerOpenPanel(Base_UIPanel panel)
    {
        if (_currentPanel != null) TriggerClosePanel(_currentPanel);
        _currentPanel = panel;
        _currentPanel.OpenBehavior();
    }

    public void TriggerPanelTransition(Base_UIPanel panel)
    {
        TriggerOpenPanel(panel);
    }

    void TriggerClosePanel(Base_UIPanel panel)
    {
        panel.CloseBehavior();
    }
}