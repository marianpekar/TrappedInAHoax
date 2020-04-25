using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerEvents<T>
{
    public Action<T> OnPlayerSelected;

    private static PlayerEvents<T> instance = new PlayerEvents<T>();
    public static PlayerEvents<T> Instance => instance ?? (instance = new PlayerEvents<T>());
}
