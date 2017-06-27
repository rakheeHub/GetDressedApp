using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetReadyPackage
{
    public class GetReadyClinet
    {
        public GetReadyClinet()
        {
            
        }

        public List<string> ExecuteCommands(string climate, string[] commands)
        {
            IResponse climateType = ResponseFactory.GetResponseObject(climate);
            List<string> responses = new List<string>();
            foreach (var command in commands)
            {
                int commandIndex = Convert.ToInt32(command);
                string response = climateType.GetResponse(commandIndex);
                responses.Add(response);
                if (response == "fail")
                {
                    break;
                }

                TaskManager.GetInstance().CompleteTask((CommandType) commandIndex);
            }

            return responses;
        }
    }
}
