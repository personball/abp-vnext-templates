using System;
using Mongo2Go;

namespace CName.PName.SName.MongoDB
{
    public class MongoDbFixture : IDisposable
    {
        public static readonly string ConnectionString;

        private static readonly MongoDbRunner MongoDbRunner;

        static MongoDbFixture()
        {
            MongoDbRunner = MongoDbRunner.Start();
            ConnectionString = MongoDbRunner.ConnectionString;
        }

        public void Dispose()
        {
            MongoDbRunner?.Dispose();
        }
    }
}
