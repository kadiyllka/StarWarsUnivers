using StarWarsUniverse.Services.Interfaces;

namespace StarWarsUniverse.Services
{
    public class CannonLoaderService : ICannonLoader
    {
        public int GetCannonCount(IReadOnlyList<uint> heights)
        {
            try
            {
                if (heights.Count < 3)
                    return 0;

                var peaks = new List<int>();
                for (int i = 1; i < heights.Count - 1; i++)
                {
                    if (heights[i - 1] < heights[i] && heights[i] > heights[i + 1])
                    {
                        peaks.Add(i);
                    }
                }

                if (peaks.Count == 0)
                    return 0;

                var totalDistance = peaks[peaks.Count - 1] - peaks[0];

                // according to question, having k Cannons means that minimal istance between two Cannons is equale to k,  
                // Distance between first and last Cannon;
                var maxCannons = (int)Math.Sqrt(totalDistance) + 1;


                // start with max number of cannons and reduce until number of cannons less than number of confirmed (valid) cannons
                for (int cannonIndex = maxCannons; cannonIndex >= 0; cannonIndex--)
                {
                    var cannonCount = 1;
                    var slicedPeakDistance = 0;

                    for (int peakIdx = 1; peakIdx < peaks.Count; peakIdx++)
                    {
                        // calculate sliced distance between peaks
                        slicedPeakDistance += peaks[peakIdx] - peaks[peakIdx - 1];

                        // checking distance
                        if (slicedPeakDistance >= cannonIndex)
                        {
                            cannonCount++;
                            slicedPeakDistance = 0;
                        }
                    }

                    if (cannonCount >= cannonIndex)
                        return cannonIndex;
                }

                return 0;
            }
            catch (Exception)
            {

                throw new ArgumentNullException("heights");
            }
        }
    }
}
