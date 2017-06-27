using System;
using System.Collections.Generic;

namespace GetReadyPackage
{
    class ResponseFactory
    {
        public static IResponse GetResponseObject(string responseType)
        {
            List<Tuple<int, string, string>> commandData = TaskManager.GetCommandData();
            Dictionary<int, string> hotClimateData = new Dictionary<int, string>();
            Dictionary<int, string> coldClimateData = new Dictionary<int, string>();
            foreach (var data in commandData)
            {
                hotClimateData.Add(data.Item1, data.Item2);
                coldClimateData.Add(data.Item1, data.Item3);
            }
            ResponseType rt = responseType.Trim().ToLower() == "hot" ? ResponseType.Hot : ResponseType.NA;
            rt = responseType.Trim().ToLower() == "cold" ? ResponseType.Cold : rt;
            switch (rt)
            {
                case ResponseType.Cold:
                    return new ColdClimate(coldClimateData);
                case ResponseType.Hot:
                    return new HotClimate(hotClimateData);
                default:
                    throw new NotSupportedException($"{responseType} is not supported.");
            }
        }
    }
}
