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
    private OrderGenerator orderGenerator;

    protected override void Start()
    {
        base.Start();
        iconSprite = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        iconSprite.sprite = null;
        //assign buttons
        actionFunction = () => TryToRecieveItem();
        orderGenerator = FindObjectOfType<OrderGenerator>();
        myOrder.bread = Ingredients.bread.NoBread;
        myOrder.meat = Ingredients.meat.NoMeat;
        myOrder.veggy = Ingredients.veggy.NoVeggy;
        myOrder.dressing = Ingredients.dressing.NoDressing;
    }

    private void TryToRecieveItem()
    {
       
        Food item = Hand.getItem();
        if (!item || !item.isReadyForAssembly)
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
                StartCoroutine(flashSprite());
                orderGenerator.CheckBread();
                
            }
        }
        else if (item.TryGetComponent<Meat>(out Meat heldMeat))
        {
            
            if(heldMeat.meat == desiredOrder.meat)
            {
                
                myOrder.meat = heldMeat.meat;
                Hand.dropItem();
                StartCoroutine(flashSprite());
                orderGenerator.CheckMeat();
            }
        }
        else if (item.TryGetComponent<Veggy>(out Veggy heldVeggy))
        {
            if(heldVeggy.veggy == desiredOrder.veggy)
            {
                myOrder.veggy = heldVeggy.veggy;
                Hand.dropItem();
                StartCoroutine(flashSprite());
                orderGenerator.CheckVeggy();
            }
        }
        else if (item.TryGetComponent<Dressing>(out Dressing heldDressing))
        {
            if(heldDressing.dressing == desiredOrder.dressing)
            {
                myOrder.dressing = heldDressing.dressing;
                Hand.dropItem();
                StartCoroutine(flashSprite());
                orderGenerator.CheckDressing();
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
    private void CheckForWin()
    {
        if (myOrder.bread == desiredOrder.bread)
        {
            if (myOrder.meat == desiredOrder.meat)
            {
                if (myOrder.veggy == desiredOrder.veggy)
                {
                    if (myOrder.dressing == desiredOrder.dressing || desiredOrder.dressing == Ingredients.dressing.NoDressing)
                    {
                        
                        FindObjectOfType<OrderGenerator>().CompleteOrder();
                        
                        myOrder.bread = Ingredients.bread.NoBread;
                        myOrder.meat = Ingredients.meat.NoMeat;
                        myOrder.veggy = Ingredients.veggy.NoVeggy;
                        myOrder.dressing = Ingredients.dressing.NoDressing;
                       
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
