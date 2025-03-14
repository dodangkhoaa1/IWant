using System.Collections.Generic;
using UnityEngine;
namespace Connect.Common
{
    [CreateAssetMenu(fileName = "Level", menuName = "SO/Level")]
    public class LevelData : ScriptableObject
    {
        public string LevelName;//tên level

        [SerializeField] public List<Edge> Edges = new List<Edge>();

    }
    [System.Serializable]
    public class Edge //làm cho nó có thể được Unity serializable để có thể lưu và tải.
    {
        [SerializeField] public List<Vector2Int> Points; //Một danh sách các Vector2Int đại diện cho các điểm trong không gian 2D.
        public Vector2Int StartPoint
        {
            get
            {
                if (Points != null && Points.Count > 0)
                {
                    return Points[0];
                }
                return new Vector2Int(-1, -1);
            }
        }//Trả về điểm đầu tiên trong danh sách Points hoặc (-1, -1) nếu danh sách trống.
        public Vector2Int EndPoint
        {
            get
            {
                if (Points != null && Points.Count > 0)
                {
                    return Points[Points.Count - 1];
                }
                return new Vector2Int(-1, -1);
            }
        } //Trả về điểm cuối cùng trong danh sách Points hoặc (-1, -1) nếu danh sách trống.
    }
}
