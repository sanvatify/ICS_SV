using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;

namespace RemotingServer
{
    public class Service : MarshalByRefObject
    {
        public string SayHello(string s)
        {
            return "Hello" + s;
        }
        public int HighestNumber(int n1, int n2)
        {
            int maxnumber = (Math.Max(n1, n2));
            Console.WriteLine("Remote Call Executed");
            return maxnumber;
        }
        public int Add(int n1, int n2)
        {
            Console.WriteLine("Remote Call Executed");
            return n1 + n2;
        }
        public int Subtract(int n1, int n2)
        {
            Console.WriteLine("Remote Call Executed");
            return n1 - n2;
        }
        public int Multiply(int n1, int n2)
        {
            Console.WriteLine("Remote Call Executed");
            return n1 * n2;
        }
        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            if (lease.CurrentState == LeaseState.Initial)
            {
                lease.InitialLeaseTime = TimeSpan.FromSeconds(25);
                lease.SponsorshipTimeout = TimeSpan.FromSeconds(25);
                lease.RenewOnCallTime = TimeSpan.FromSeconds(25);
            }
            return lease;
        }
    }
    class Server
    {
        static void Main(string[] args)
        {
            TcpChannel tcpchannel = new TcpChannel(8189);
            ChannelServices.RegisterChannel(tcpchannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Service), "OurFirstRemoteService",
            WellKnownObjectMode.Singleton);
            Console.WriteLine("Server Services started on: 8189");
            Console.WriteLine("Press ");
            Console.ReadLine();
        }
    }
}