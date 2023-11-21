using UnityEngine;

namespace Assignment_5
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] GameObject wallPrefab;
        [SerializeField] Vector2 mapSize;
        [SerializeField] float noiseScale;
        [SerializeField] float spawnThreshold;

        void Start()
        {
            GenerateMap();
        }

        void GenerateMap()
        {
            var xOrigin = Random.Range(0f, 100f);
            var yOrigin = Random.Range(0f, 100f);

            for (var i = -1; i < mapSize.x + 1; i++)
            for (var j = -1; j < mapSize.y + 1; j++)
            {
                if (i < 0 || j < 0 || i >= mapSize.x || j >= mapSize.y)
                {
                    var outsideWall = Instantiate(wallPrefab, transform);
                    outsideWall.transform.position = new Vector3(i, 0, j);

                    continue;
                }

                var x = xOrigin + i / noiseScale;
                var y = yOrigin + j / noiseScale;
                var value = Mathf.PerlinNoise(x, y);

                if (value < spawnThreshold) continue;

                var wall = Instantiate(wallPrefab, transform);
                wall.transform.position = new Vector3(i, 0, j);
            }
        }
    }
}