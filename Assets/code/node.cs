
using UnityEngine;

public class node : MonoBehaviour
{
    public int cost = 100;
    public int upcostmagic = 300;
    public int upcostmech = 300;
    public NodeUI nodeUI;

    private GameObject turret;
    public GameObject basicTowerPrefab;
    public GameObject upMagicPrefab;
    public GameObject upMechPrefab;
    private node selectedNode;

    public bool isUpgraded = false;
    void Start()
    {
       // buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            SelectNode(this);
            // NodeUI.SetTarget();

            return;
        }

        //Turret c = turret.GetComponent<cost>();
        if (Player.Money < cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

         Player.Money -= cost;
        turret = (GameObject)Instantiate(basicTowerPrefab, transform.position, transform.rotation);
        
    }

    public void SelectNode(node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        //turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void UpgradeMagicTurret()
    {
        if (Player.Money < upcostmagic)
        {
            Debug.Log("Not enough money to up that!");
            return;
        }

        Player.Money -= upcostmagic;

        Destroy(turret);


        turret = (GameObject)Instantiate(upMagicPrefab, transform.position, transform.rotation);

        isUpgraded = true;
        return;

    }

    public void UpgradeMechTurret()
    {
        if (Player.Money < upcostmech)
        {
            Debug.Log("Not enough money to up that!");
            return;
        }

        Player.Money -= upcostmech;

        Destroy(turret);


        turret = (GameObject)Instantiate(upMechPrefab, transform.position, transform.rotation);

        isUpgraded = true;
        return;
    }
}
