using System;
using System.Net.NetworkInformation;
using System.Net;

class MainClass
{
    public static void ShowIPAddresses(IPInterfaceProperties adapterProperties)
    {
        IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
        if (dnsServers != null)
        {
            foreach (IPAddress dns in dnsServers)
            {
                Console.WriteLine("  DNS Servers ............................. : {0}",
                dns.ToString()
                );
            }
        }
        IPAddressInformationCollection anyCast = adapterProperties.AnycastAddresses;
        if (anyCast != null)
        {
            foreach (IPAddressInformation any in anyCast)
            {
                Console.WriteLine("  Anycast Address .......................... : {0} {1} {2}",
                any.Address,
                any.IsTransient ? "Transient" : "",
                any.IsDnsEligible ? "DNS Eligible" : ""
                );
            }
            Console.WriteLine();
        }

        MulticastIPAddressInformationCollection multiCast = adapterProperties.MulticastAddresses;
        if (multiCast != null)
        {
            foreach (IPAddressInformation multi in multiCast)
            {
                Console.WriteLine("  Multicast Address ....................... : {0} {1} {2}",
                multi.Address,
                multi.IsTransient ? "Transient" : "",
                multi.IsDnsEligible ? "DNS Eligible" : ""
                );
            }
            Console.WriteLine();
        }
        UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
        if (uniCast != null)
        {
            string lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
            foreach (UnicastIPAddressInformation uni in uniCast)
            {
                DateTime when;

                Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
                Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin);
                Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin);
                Console.WriteLine("     Duplicate Address Detection .......... : {0}",
                uni.DuplicateAddressDetectionState);

                // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
                // if en-us is the current culture.

                // Calculate the date and time at the end of the lifetimes.
                when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime);
                when = when.ToLocalTime();
                Console.WriteLine("     Valid Life Time ...................... : {0}",
                when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                );
                when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressPreferredLifetime);
                when = when.ToLocalTime();
                Console.WriteLine("     Preferred life time .................. : {0}",
                when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                );

                when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime);
                when = when.ToLocalTime();
                Console.WriteLine("     DHCP Leased Life Time ................ : {0}",
                when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                );
            }
            Console.WriteLine();
        }
    }



    public static void ShowNetworkInterfaces()
    {
        IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        Console.WriteLine("Interface information for {0}.{1}     ",
        computerProperties.HostName, computerProperties.DomainName);
        if (nics == null || nics.Length < 1)
        {
            Console.WriteLine("  No network interfaces found.");
            return;
        }

        Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
        foreach (NetworkInterface adapter in nics)
        {
            IPInterfaceProperties properties = adapter.GetIPProperties();
            Console.WriteLine();
            Console.WriteLine(adapter.Description);
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length,'='));
            Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
            Console.WriteLine("  Physical Address ........................ : {0}",
            adapter.GetPhysicalAddress().ToString());
            Console.WriteLine("  Operational status ...................... : {0}",
            adapter.OperationalStatus);
            string versions ="";

            // Create a display string for the supported IP versions.
            if (adapter.Supports(NetworkInterfaceComponent.IPv4))
            {
                versions = "IPv4";
            }
            if (adapter.Supports(NetworkInterfaceComponent.IPv6))
            {
                if (versions.Length > 0)
                {
                    versions += " ";
                }
                versions += "IPv6";
            }
            Console.WriteLine("  IP version .............................. : {0}", versions);
            ShowIPAddresses(properties);

            // The following information is not useful for loopback adapters.
            if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
            {
                continue;
            }
            Console.WriteLine("  DNS suffix .............................. : {0}",
            properties.DnsSuffix);

            string label;
            if (adapter.Supports(NetworkInterfaceComponent.IPv4))
            {
                IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                Console.WriteLine("  MTU...................................... : {0}", ipv4.Mtu);
                if (ipv4.UsesWins)
                {

                    IPAddressCollection winsServers = properties.WinsServersAddresses;
                    if (winsServers.Count > 0)
                    {
                        label = "  WINS Servers ............................ :";
                        Console.Write(label);
                        ShowIPAddresses(properties);
                    }
                }
            }

            Console.WriteLine("  DNS enabled ............................. : {0}",
            properties.IsDnsEnabled);
            Console.WriteLine("  Dynamically configured DNS .............. : {0}",
            properties.IsDynamicDnsEnabled);
            Console.WriteLine("  Receive Only ............................ : {0}",
            adapter.IsReceiveOnly);
            Console.WriteLine("  Multicast ............................... : {0}",
            adapter.SupportsMulticast);
            //ShowInterfaceStatistics(adapter);

            Console.WriteLine();
        }
    }

    public static void ShowIPStatistics(NetworkInterfaceComponent version)
    {
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        IPGlobalStatistics ipstat = null;
        switch (version)
        {
        case NetworkInterfaceComponent.IPv4:
            ipstat = properties.GetIPv4GlobalStatistics();
            Console.WriteLine("{0}IPv4 Statistics ",Environment.NewLine);
            break;
        case NetworkInterfaceComponent.IPv6:
            ipstat = properties.GetIPv4GlobalStatistics();
            Console.WriteLine("{0}IPv6 Statistics ",Environment.NewLine);
            break;
        default:
            throw new ArgumentException("version");
            //    break;
        }
        Console.WriteLine("  Forwarding enabled ...................... : {0}",
        ipstat.ForwardingEnabled);
        Console.WriteLine("  Interfaces .............................. : {0}",
        ipstat.NumberOfInterfaces);
        Console.WriteLine("  IP addresses ............................ : {0}",
        ipstat.NumberOfIPAddresses);
        Console.WriteLine("  Routes .................................. : {0}",
        ipstat.NumberOfRoutes);
        Console.WriteLine("  Default TTL ............................. : {0}",
        ipstat.DefaultTtl);
        Console.WriteLine("");
        Console.WriteLine("  Inbound Packet Data:");
        Console.WriteLine("      Received ............................ : {0}",
        ipstat.ReceivedPackets);
        Console.WriteLine("      Forwarded ........................... : {0}",
        ipstat.ReceivedPacketsForwarded);
        Console.WriteLine("      Delivered ........................... : {0}",
        ipstat.ReceivedPacketsDelivered);
        Console.WriteLine("      Discarded ........................... : {0}",
        ipstat.ReceivedPacketsDiscarded);
        Console.WriteLine("      Header Errors ....................... : {0}",
        ipstat.ReceivedPacketsWithHeadersErrors);
        Console.WriteLine("      Address Errors ...................... : {0}",
        ipstat.ReceivedPacketsWithAddressErrors);
        Console.WriteLine("      Unknown Protocol Errors ............. : {0}",
        ipstat.ReceivedPacketsWithUnknownProtocol);
        Console.WriteLine("");
        Console.WriteLine("  Outbound Packet Data:");
        Console.WriteLine("      Requested ........................... : {0}",
        ipstat.OutputPacketRequests);
        Console.WriteLine("      Discarded ........................... : {0}",
        ipstat.OutputPacketsDiscarded);
        Console.WriteLine("      No Routing Discards ................. : {0}",
        ipstat.OutputPacketsWithNoRoute);
        Console.WriteLine("      Routing Entry Discards .............. : {0}",
        ipstat.OutputPacketRoutingDiscards);
        Console.WriteLine("");
        Console.WriteLine("  Reassembly Data:");
        Console.WriteLine("      Reassembly Timeout .................. : {0}",
        ipstat.PacketReassemblyTimeout);
        Console.WriteLine("      Reassemblies Required ............... : {0}",
        ipstat.PacketReassembliesRequired);
        Console.WriteLine("      Packets Reassembled ................. : {0}",
        ipstat.PacketsReassembled);
        Console.WriteLine("      Packets Fragmented .................. : {0}",
        ipstat.PacketsFragmented);
        Console.WriteLine("      Fragment Failures ................... : {0}",
        ipstat.PacketFragmentFailures);
        Console.WriteLine("");
    }


    public static void Main(string[] args)
    {
        ShowNetworkInterfaces();

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
