using System;

namespace DefaultNamespace.Data
{
    [Serializable]
    public class PointsData
    {
        public float PlayerRecordPoints;

        public void CheckNewRecord(float newPoints)
        {
            if (PlayerRecordPoints < newPoints)
            {
                PlayerRecordPoints = newPoints;
            }
        }
    }
}