using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.HelperModels
{

    public class MonitizerResult
    {

        /// <summary>
        ///  Service start status
        ///  <value>-1: Application error in startup</value>
        ///  <value>0: Application loading</value>
        ///  <value>1: Application started successfully</value>
        /// </summary>
        public int StartSuccesful { get; set; }

        /// <summary>
        ///  Application name
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        ///  Application hosting ip
        /// </summary>
        public string IpAddress { get; set; }

    }

}
