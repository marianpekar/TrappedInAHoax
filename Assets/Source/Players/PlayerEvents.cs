using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerEvents
{
    public Action<Transform> OnPlayerSelected;

    private static PlayerEvents instance = new PlayerEvents();
    public static PlayerEvents Instance => instance ?? (instance = new PlayerEvents());
}
