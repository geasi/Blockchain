using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain
{
    public class Block
    {
        public string Hash { 
            get => GetHash(this.LastHash, this.Timestamp, this.Data, this.Complexity, this.Nonce);
        }
        public string LastHash { get; set; }
        public long Timestamp { get; set; }
        public DataBlockBase Data { get; set; }
        public long Nonce { get; set; }
        public int Complexity { get; set; }

        public Block(string lastHash, DataBlockBase data, int complexity) {
            this.LastHash = lastHash;
            this.Data = data;
            this.Timestamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            this.Complexity = complexity;
        }

        public static string GetHash(string lastHash, long timestamp, DataBlockBase data, int complexity, long nonce)
        {
            return GetHash($"{lastHash}{timestamp}{data.ToString()}{complexity}{nonce}");
        }

        public static string GetHash(string input)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public override string ToString() {
            return $@"***Block***
Last hash: {this.LastHash}
Hash: {this.Hash}
Timestamp: {this.Timestamp}
Data: {this.Data.ToString()}
Complexity: {this.Complexity}
Nonce: {this.Nonce}
";
        }
    }
}
