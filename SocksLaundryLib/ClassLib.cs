using System;
using System.Collections.Generic;
using System.Linq;

namespace SocksLaundryLib
{
    public class ClassLib
    {

        //Do not delete or edit this method, you can only modify the block
        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            {
                var oc = 0.0;
                var ss = new Dictionary<int, int>();


                var searchableClean = new List<int>(cleanPile.ToList());

                foreach (int sock in cleanPile)
                {
                    int fci = searchableClean.IndexOf(sock);
                    if (fci != -1)
                    {
                        searchableClean.Remove(fci);
                        if (ss.ContainsKey(sock))
                            ss[sock] = ss[sock] + 1;
                        else ss[sock] = 1;
                    }
                }


                if (noOfWashes == 0)
                {
                    foreach (var kv in ss)
                    {
                        var tsSameTypeSc = ((int)(kv.Value));
                        if (((tsSameTypeSc / 2) >= 1))
                        {
                            double d = tsSameTypeSc / 2;
                            oc += Math.Floor(d);
                        }

                    }
                }
                else
                {
                    List<int> searchableDirtyForCleanMatch = new List<int>(dirtyPile.ToList());
                    int countWashAsCleanMatchesInDirtyPile = 0;
                    foreach (var item in ss)
                    {
                        if ((int)item.Value % 2 > 0)
                        {
                            while (searchableDirtyForCleanMatch.IndexOf(item.Key) != -1)
                            {
                                countWashAsCleanMatchesInDirtyPile++;
                                searchableDirtyForCleanMatch.Remove(searchableDirtyForCleanMatch.IndexOf((int)item.Key));
                                ss[item.Key] = ss[item.Key] + 1;

                                if (countWashAsCleanMatchesInDirtyPile == noOfWashes) break;

                            }

                            if (countWashAsCleanMatchesInDirtyPile == noOfWashes) break;
                        }
                    }

                    if (countWashAsCleanMatchesInDirtyPile < noOfWashes)
                    {
                        var remainingDirtyAfterCleanMatch = new List<int>(searchableDirtyForCleanMatch);

                        foreach (int dirtySock in remainingDirtyAfterCleanMatch)
                        {
                            if (countWashAsCleanMatchesInDirtyPile == noOfWashes) break;
                            int foundDirtySockIndex = searchableDirtyForCleanMatch.IndexOf(dirtySock);
                            if (foundDirtySockIndex != -1)
                            {
                                searchableDirtyForCleanMatch.Remove(foundDirtySockIndex);
                                if (ss.ContainsKey(dirtySock))
                                    ss[dirtySock] = ss[dirtySock] + 1;
                                else ss[dirtySock] = 1;
                            }
                            countWashAsCleanMatchesInDirtyPile++;
                        }
                    }


                    foreach (var entry in ss)
                    {
                        var tsSameTypeSc = entry.Value;
                        if ((tsSameTypeSc / 2) >= 1)
                        {
                            double db = tsSameTypeSc / 2;
                            oc += Math.Floor(db);
                        }
                    }
                }
                return (int)oc;
            }
        }
        /**
         * You can create various helper methods
         * */
    }
}
