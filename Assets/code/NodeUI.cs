using UnityEngine;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    private node target;

    public void SetTarget(node _target)
    {
        target = _target;

        transform.position = target.transform.position;

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeMagic()
    {
        target.UpgradeMagicTurret();
        Hide();


    }

    public void UpgradeMech()
    {
        target.UpgradeMechTurret();
        Hide();
    }

}