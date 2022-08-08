using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderStation : Station
{
    // Private Global Variables
    GeneratedOrder desiredOrder;
    GeneratedOrder myOrder = new GeneratedOrder();
    private SpriteRenderer iconSprite;
    [SerializeField] Sprite downActive;
    public AudioClip dingSound;

    protected override void Start()
    {
        base.Start();
        iconSprite = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        iconSprite.sprite = null;
        //assign buttons
        actionFunction = () => TryToRecieveItem();
    }

    private void TryToRecieveItem()
    {
        Debug.Log("It works!");
        Food item = Hand.getItem();
        if (!item || !item.isReadyForAssembly)
        {
            return;
        }
        Debug.Log("Its ready!");
        // Check what type of ingredient the hand has
        // might have to do more checks later if the item has been properly prepared and cooked
        if (item.TryGetComponent<Bread>(out Bread heldBread))
        {
            if(heldBread.bread == desiredOrder.bread)
            {
                myOrder.bread = heldBread.bread;
                Hand.dropItem();
                StartCoroutine(flashSprite());
            }
        }
        else if (item.TryGetComponent<Meat>(out Meat heldMeat))
        {
            Debug.Log("its meat!");
            if(heldMeat.meat == desiredOrder.meat)
            {
                Debug.Log("It matches and i giv");
                myOrder.meat = heldMeat.meat;
                Hand.dropItem();
                StartCoroutine(flashSprite());
            }
        }
        else if (item.TryGetComponent<Veggy>(out Veggy heldVeggy))
        {
            if(heldVeggy.veggy == desiredOrder.veggy)
            {
                myOrder.veggy = heldVeggy.veggy;
                Hand.dropItem();
                StartCoroutine(flashSprite());
            }
        }
        else if (item.TryGetComponent<Dressing>(out Dressing heldDressing))
        {
            if(heldDressing.dressing == desiredOrder.dressing)
            {
                myOrder.dressing = heldDressing.dressing;
                Hand.dropItem();
                StartCoroutine(flashSprite());
            }
        }
        CheckForWin();
    }

    IEnumerator flashSprite(){
        iconSprite.sprite = downActive;
        FindObjectOfType<MusicPlayer>().RecieveAndPlaySFX(dingSound);
        yield return new WaitForSeconds(1.0f);
        iconSprite.sprite = null;
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
                        //myOrder = new GeneratedOrder();
                    }
                }
            }
        }
    }

    public void RecieveDesiredOrder(GeneratedOrder order)
    {
        desiredOrder = order;
    }
    public void TellMyOrderHasNoDressing()
    {
        myOrder.dressing = Ingredients.dressing.NoDressing;
    }
}
