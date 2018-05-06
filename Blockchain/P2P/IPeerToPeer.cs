namespace Blockchain.P2P {
    public interface IPeerToPeer {
        void AddPeer(string address);
        void RemovePeer(string address);
        void SendBlock(Block block);
    }
}