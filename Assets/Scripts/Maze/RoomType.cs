﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;

    public void destroyRoom() {
        Destroy(gameObject);
    }
}
