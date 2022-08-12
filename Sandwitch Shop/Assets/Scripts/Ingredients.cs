using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
// ENUMS FOR EACH IGREDIENT TYPE
    // Breads
    public enum bread
    {
        Sourdough,
        White, 
        WholeGrain,
        NoBread
    }
    // Meats
    public enum meat
    {
        Frog,
        Dragon,
        Jelly,
        Piranha,
        Cthulu,
        RollyPolly,
        NoMeat
    }
    // Veggies
    public enum veggy
    {
        Potato,
        Lettuce,
        Tomato,
        Onion,
        Mushroom,
        NoVeggy
    }
    // Dressings
    public enum dressing
    {
        Vinegar,
        Ketchup,
        Mustard,
        NoDressing
    }
}
