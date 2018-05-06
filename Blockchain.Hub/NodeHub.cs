using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace Blockchain.Hub
{
    public static class NodeHub
    {
        private static Chain _blockchain;

        public static Chain Blockchain
        {
            get
            {
                if (_blockchain == null) _blockchain = new Chain();
                return _blockchain;
            }
        }
        private static List<HubConnection> _nodes = new List<HubConnection>();

        public static void SetChain(Chain blockchain)
        {
            _blockchain = blockchain;
        }

        public static void ConnectToNode(string address)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(address + "/chain")
                .Build();

            connection.On<string>("Blockchain", (chain) =>
            {
                _blockchain = JsonConvert.DeserializeObject<Chain>(chain);
            });

            connection.On<Block>("Block", (block) =>
            {
                _blockchain.AddBlock(block);
            });

            connection.StartAsync().Wait();

            _nodes.Add(connection);
        }

        public static void AddBlock(Block block)
        {
            _blockchain.AddBlock(block);
            foreach (var node in _nodes)
            {
                node.SendAsync("BlockReceived", block);
            }
        }

        public static Block MineBlock(string lastHash, string data)
        {
            var block = NodeHub.Blockchain.MineBlock(NodeHub.Blockchain.LastHash, data);
            AddBlock(block);

            return block;
        }

        // public static void AddBlock(string data)
        // {

        // }

        // public static void AddBlock(Block block)
        // {

        // }

        public static string SerializeBlockchain()
        {
            return JsonConvert.SerializeObject(Blockchain);
        }
    }
}