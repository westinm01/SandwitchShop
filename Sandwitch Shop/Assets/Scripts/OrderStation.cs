using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderStation : Station
{
    // Private Global Variables
    GeneratedOrder desiredOrder;
    GeneratedOrder myOrder = new GeneratedOrder();

    protected override void Start()
    {
        base.Start();
        //assign buttons
        actionFunction = () => TryToRecieveItem();
    }

    private void TryToRecieveItem()
    {
        Debug.Log("It works!");
        Food item = Hand.getItem();
        if (!item)
        {
            return;
        }
        // Check what type of ingredient the hand has
        // might have to do more checks later if the item has been properly prepared and cooked
        if (item.TryGetComponent<Bread>(out Bread heldBread))
        {
            if(heldBread.bread == desiredOrder.bread)
            {
                myOrder.bread = heldBread.bread;
                Hand.dropItem();
            }
        }
        else if (item.TryGetComponent<Meat>(out Meat heldMeat))
        {
            if(heldMeat.meat == desiredOrder.meat)
            {
                myOrder.meat = heldMeat.meat;
                Hand.dropItem();
            }
        }
        else if (item.TryGetComponent<Veggy>(out Veggy heldVeggy))
        {
            if(heldVeggy.veggy == desiredOrder.veggy)
            {
                myOrder.veggy = heldVeggy.veggy;
                Hand.dropItem();
            }
        }
        else if (item.TryGetComponent<Dressing>(out Dressing heldDressing))
        {
            if(heldDressing.dressing == desiredOrder.dressing)
            {
                myOrder.dressing = heldDressing.dressing;
                Hand.dropItem();
            }
        }
        CheckForWin();
    }

    // Checks for order successfully completed
    // Very ugly U_U but I can't think of anything better
    private void CheckForWin()
    {
        if (myOrder.bread == desiredOrder.bread)
        {
            if (myOrder.meat == desiredOrder.meat)
            {
                if (myOrder.veggy == desiredOrder.veggy)
                {
                    if (myOrder.dressing == desiredOrder.dressing)
                    {
                        FindObjectOfType<OrderGenerator>().CompleteOrder();
                        myOrder = new GeneratedOrder();
                    }
                }
            }
        }
    }

    public void RecieveDesiredOrder(GeneratedOrder order)
    {
        desiredOrder = order;
    }
}
