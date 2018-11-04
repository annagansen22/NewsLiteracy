using UnityEngine;
using System.Collections;

public class Rotations : MonoBehaviour
{
    public enum Direction { North, East, South, West };

    public class Dir
    {
        public Direction dir;

        void Start()
        {
        }

        public Direction getdirection()
        {
            return dir;
        }

        public void setDirection(Direction newDir)
        {
            dir = newDir;
        }

        public static Vector3 directionToEuler(Direction oldDir)
        {
            if (oldDir == Direction.North) {
                return new Vector3(0, 0, 0);
            }
            else if (oldDir == Direction.East){
                return new Vector3(0, 0, 270);
            }
            else if (oldDir == Direction.South){
                return new Vector3(0, 0, 180);
            } 
            else
            {
                return new Vector3(0, 0, 90);
            }

        }
  
        Direction ReverseDirection(Direction oldDir)
        {
            if (oldDir == Direction.North)
                oldDir = Direction.South;
            else if (oldDir == Direction.South)
                oldDir = Direction.North;
            else if (oldDir == Direction.East)
                oldDir = Direction.West;
            else if (oldDir == Direction.West)
                oldDir = Direction.East;

            return oldDir;
        }
    }
}