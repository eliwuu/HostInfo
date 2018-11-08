/* Author: eliwuu@oultook.com
 * License: MIT
 */

using System.Collections.Generic;
using System.Net;

namespace HostInfo
{
    public class GetLocalInfo
    {
        /// <value> name of local host </value>
        public string Hostname {get; private set;}

        /// <value> List of available ip addresses (ipv4, ipv6) </value>
        public List<IPAddress> IPAddresses {get; private set;}

        /// <Summary>
        /// GetLocalInfo() provides properties:
        /// string Hostname and List IPAddresses
        /// </Summary>
        public GetLocalInfo()
        {
            IPAddresses = new List<IPAddress>();

            var hostname = Dns.GetHostName();
            this.Hostname = hostname;

            var ips = Dns.GetHostEntry(hostname);
            foreach(var item in ips.AddressList)
                IPAddresses.Add(item);
        }
    }
}