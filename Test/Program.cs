using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            
            string Continue = "Yes";
            Guid PartitionId = new Guid() ;
            string ReplicaId = string.Empty;
            string serviceInstanceName = string.Empty;
            string CheckpointType = string.Empty;
            do
            {
                sb.Clear();
                Console.Write("PartitionId: ");
                string inGuid = Console.ReadLine();
                if (string.IsNullOrEmpty(inGuid))
                {
                    Console.WriteLine(PartitionId.ToString());
                    inGuid = PartitionId.ToString();
                }
                PartitionId = Guid.Parse(inGuid); // new Guid("9ada8a08-0520-4b02-a5c8-5c6b80c39d61");

                Console.Write("ReplicaId: ");
                string inReplicaId = Console.ReadLine();
                if (string.IsNullOrEmpty(inReplicaId))
                {
                    Console.WriteLine(ReplicaId);
                    inReplicaId = ReplicaId;
                }
                ReplicaId = inReplicaId; // "131743028742031772";

                Console.Write("ServiceInstanceName: ");
                System.Windows.Forms.SendKeys.SendWait("fabric:/SIN/AffidoItemService");
                string inSIN = Console.ReadLine();
                if (string.IsNullOrEmpty(inSIN))
                {
                    Console.WriteLine(serviceInstanceName);
                    inSIN = serviceInstanceName;
                }
                serviceInstanceName = inSIN; // "fabric:/SIN/AffidoItemService";

                Console.Write("Checkpoint Type: ");
                System.Windows.Forms.SendKeys.SendWait("StateManager");
                string inCT = Console.ReadLine();
                if (string.IsNullOrEmpty(inCT))
                {
                    Console.WriteLine(CheckpointType);
                    inCT = CheckpointType;
                }
                CheckpointType = inCT; // "StateManager";

                sb.Append(PartitionId.ToString("N"));

                sb.Append("_");

                sb.Append(ReplicaId);

                sb.Append("_");

                

                sb.Append(CRC64.ToCrc64String(Encoding.Unicode.GetBytes(serviceInstanceName)));

                sb.Append("_");

                sb.Append(CRC64.ToCrc64String(Encoding.Unicode.GetBytes(CheckpointType.ToString())));

                Console.WriteLine("Checkpoint file name: " + sb.ToString());
                Console.WriteLine();
                Console.WriteLine("Continue: Y|N");
                Continue = Console.ReadLine().ToLower();
            } while (Continue.Equals("Y"));
        }
    }
}
