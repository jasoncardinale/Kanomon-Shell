using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public int level;
    public GameObject gameObject;

    public enum Direction
    {
        Forward,
        Left,
        Right,
        Backward
    }

    void animateMovement()
    {

    }

    void animateRotation(Direction direction)
    {
        switch(direction) {
            case Direction.Forward:
                //do something
                return;
            case Direction.Left:
                return;
            case Direction.Right:
                return;
            case Direction.Backward:
                return;
        }
    }

    void movePlayer(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                //do something
                return;
            case Direction.Left:
                return;
            case Direction.Right:
                return;
            case Direction.Backward:
                return;
        }
    }

    void pauseMenu()
    {

    }

    void bagMenu()
    {

    }

    void kanopadMenu()
    {

    }
}
