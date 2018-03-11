using UnityEngine;

namespace Buildings
{
    public class Building : MonoBehaviour, IBuilding
    {
        [SerializeField]
        BuildingType type;
        [SerializeField]
        int width;
        [SerializeField]
        int height;

        public BuildingType Type
        {
            get
            {
                return type;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public Vector2Int Position
        {
            get
            {
                Vector3 position = transform.position;
                return new Vector2Int((int)position.x, (int)position.y);
            }

            protected set
            {
                transform.position = new Vector3(value.x, value.y, transform.position.z);
            }
        }

        public void MovePrefab(Vector2Int _position)
        {
            Position = _position;
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}