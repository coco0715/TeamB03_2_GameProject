using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EWireColor
{
    None = -1,
    Red,
    Blue,
    Yellow,
    Magenta
}

public class FixWiringTask : MonoBehaviour
{
    [SerializeField]
    private List<LeftWire> mLeftWires;

    [SerializeField]
    private List<RightWire> mRightWires;

    private LeftWire mSelectedWire;

    private void OnEnable()
    {
        for(int i = 0; i < mLeftWires.Count; i++)
        {
            mLeftWires[i].ResetTarget();
            mLeftWires[i].DisconnectWire();
        }

        List<int> numberPool = new List<int>();
        for(int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }

        int index = 0;
        while(numberPool.Count !=0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mLeftWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }

        for (int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }

        index = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mRightWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if (hit.collider != null)
            {
                var left = hit.collider.GetComponent<LeftWire>();
                if (left != null)
                {
                    mSelectedWire = left;
                }
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (mSelectedWire != null)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponent<RightWire>();
                        if (right != null)
                        {
                            mSelectedWire.SetTarget(hit.transform.position, -50f);
                            mSelectedWire.ConnectedWire(right);
                            right.ConnectedWire(mSelectedWire);
                            mSelectedWire = null;
                            CheckCompleteTask();
                            return;
                        }
                    }
                }

                mSelectedWire.ResetTarget();
                mSelectedWire.DisconnectWire();
                mSelectedWire = null;
                CheckCompleteTask();
            }
        }


        if (mSelectedWire != null)
        {
            mSelectedWire.SetTarget(Input.mousePosition, -15f);
        }
    }

    private void CheckCompleteTask()
    {
        bool isAllComplete = true;
        foreach (var wire in mLeftWires)
        {
            if(wire.IsConnected)
            {
                isAllComplete = false;
                break;
            }
        }
    }


    //public void Open()
    //{
    //    Player.PlayerArmature.IsMoveable = false;
    //    gameObject.transform.parent.gameObject.SetActive(true);
    //    gameObject.SetActive(true);
    //}


    //public void Close()
    //{
    //    Player.PlayerArmature.IsMoveable = true;
    //    gameObject.transform.parent.gameObject.SetActive(false);
    //    gameObject.SetActive(false);
    //}
}
