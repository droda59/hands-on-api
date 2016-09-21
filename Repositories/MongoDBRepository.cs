using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

using HandsOnApi.Models;

namespace HandsOnApi.Repositories
{
    public class MongoDBRepository<TDocument> where TDocument : Document
    {
        private readonly IMongoCollection<TDocument> _collection;

        protected MongoDBRepository()
        {
            var settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("handson.documents.azure.com", 10250);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            var identity = new MongoInternalIdentity("HandsOn", "handson");
            var evidence = new PasswordEvidence("vrWnCS1vpV3vXt1kMdWrPS65Oxso7WCgEJxzfSuJbdt9aTySkkWaBaEbTmxJDuEnhSMSIgCpZyZ5HrXPSQjcuw==");

            settings.Credentials = new List<MongoCredential>()
            {
                new MongoCredential("SCRAM-SHA-1", identity, evidence)
            };

            var client = new MongoClient(settings);
            var database = client.GetDatabase("HandsOn");

            this._collection = database.GetCollection<TDocument>(typeof(TDocument).Name.ToLower());
        }

        public virtual async Task<IEnumerable<TDocument>> GetAsync()
        {
            return await this.Collection.Find(new BsonDocument()).ToListAsync();
        }

        public virtual async Task<TDocument> GetAsync(string id)
        {
            return await this.Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<bool> UpdateAsync(string id, TDocument data)
        {
            var result = await this.Collection.FindOneAndReplaceAsync(x => x.Id == id, data);

            return result != null;
        }

        public virtual async Task<bool> InsertAsync(TDocument data)
        {
            await this.Collection.InsertOneAsync(data);

            return true;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            var result = await this.Collection.DeleteOneAsync(x => x.Id == id);

            return result.IsAcknowledged;
        }
        
        protected IMongoCollection<TDocument> Collection
        {
            get { return this._collection; }
        }
    }
}
