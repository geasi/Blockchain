using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Hub
{
    public class Arguments
    {
        public int Port;
        public string[] Addresses;
        public bool Loaded;

        public Arguments(List<string> args)
        {
            try
            {
                var portIndex = args.IndexOf("-p");
                var addressesIndex = args.IndexOf("-a");

                if (portIndex >= 0)
                {
                    Port = Convert.ToInt32(args[portIndex + 1]);
                }
                else
                {
                    Port = 5000;
                }

                if (addressesIndex >= 0)
                {
                    Addresses = args[addressesIndex + 1].Split(',');
                }

                Loaded = true;
            }
            catch
            {
                Loaded = false;
            }
        }
    }
}