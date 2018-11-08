/* Author: eliwuu@oultook.com
 * License: MIT
 */

using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System;

namespace HostInfo
{
    public sealed class GetHostStatus
    {
        private static readonly GetHostStatus instance = new GetHostStatus();

        static GetHostStatus() { }

        /// <Summary>
        /// Checks if any network interface is available
        /// </Summary>
        public bool CheckNetwork() // it's not very useful - i.e. if any other network interface is up - will return True;
        {
            var networkAvailable = NetworkInterface.GetIsNetworkAvailable();

            return networkAvailable;
        }

        /// <Summary>
        /// CheckHostname - provide server.domain as a parameter
        /// </Summary>
        public async Task<bool> CheckHostname(string hostname)
        {
            if (hostname is null)
                throw new ArgumentNullException();

            IPAddress ip;
            try 
            {
                var hostIP = await Dns.GetHostEntryAsync(hostname);
                ip = hostIP.AddressList[0];
            }
            catch (SocketException)
            {
                return false;
            }

            var ping = await Ping(ip);

            return ping;
        }
        /// <Summary>
        /// CheckIPv4() checks if device respond on ipv4 address
        /// </Summary>
        /// <typeparam name="IPAdrress">System.Net IPAddress</typeparam>
        /// <param name="ipv4"> ip address </param>
        public async Task<bool> CheckIPv4(IPAddress ipv4)
        {
            if (ipv4 is null)
                throw new ArgumentNullException();

            var ping = await Ping(ipv4);

            return ping;
        }
        /// <Summary>
        /// CheckIPv6() checks if device respond on ipv4 address
        /// </Summary>
        /// <typeparam name="IPAdrress">System.Net IPAddress</typeparam>
        /// <param name="ipv6"> ip address </param>
        public async Task<bool> CheckIPv6(IPAddress ipv6)
        {
            if (ipv6 is null)
                throw new ArgumentNullException();

            var ping = await Ping(ipv6);

            return ping;
        }
        private async Task<bool> Ping(IPAddress ip)
        {
            var ping = new Ping();

            PingReply reply;
            try
            {
                reply = await ping.SendPingAsync(ip);  

                if (reply == null)
                    return false;  

                switch (reply.Status)
                {
                    case IPStatus.Unknown:
                    case IPStatus.NoResources:
                    case IPStatus.IcmpError:
                    case IPStatus.DestinationHostUnreachable:
                    case IPStatus.DestinationNetworkUnreachable:
                    case IPStatus.BadDestination:
                    case IPStatus.DestinationUnreachable:
                    case IPStatus.TimedOut:
                        return false;
                    case IPStatus.Success:
                        return true;
                    default:
                        throw new PingException("Undetermined IPStatus");
                }
            }
            catch (PingException)
            {
                return false;
            }
        }
        public static GetHostStatus Instance
        {
            get
            {
                return instance;
            }
        }
    }
}