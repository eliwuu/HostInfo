/* Author: eliwuu@oultook.com
 * License: MIT
 */

using System.Collections.Generic;
using System.Net;

namespace HostInfo
{
    public class Host
    {
        private string hostname;
        private IPAddress ipv4;
        private IPAddress ipv6;

        /// <value> Hostname: server.domain address </value>
        public string Hostname
        {
            get
            {
                return hostname;
            }
        }
        /// <value> IPv4: IPv4 address </value>
        public IPAddress IPv4
        {
            get
            {
                return ipv4;
            }
        }
        /// <value> IPv6: IPv6 address </value>
        public IPAddress IPv6
        {
            get
            {
                return ipv6;
            }
        }
        /// <Summary>
        /// for hostname use SetHostname(), for IPv4 use SetIPv4(), for IPv6 use SetIPv6()
        /// </Summary>
        public Host()
        {

        }
        /// <Summary>
        /// Sets hostname
        /// </Summary>
        public void SetHostname(string hostname)
        {
            this.hostname = hostname;
        }
        /// <Summary>
        /// Sets IPv4 address
        /// </Summary>
        public void SetIPv4(string ip)
        {
            IPAddress.TryParse(ip, out ipv4);
        }
        /// <Summary>
        /// Sets IPv6 address
        /// </Summary>
        public void SetIPv6(string ip)
        {
            IPAddress.TryParse(ip, out ipv6);
        }
    }
}