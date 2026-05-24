using ContactBook.Models;
using MongoDB.Driver;

namespace ContactBook.Services
{
    public class ContactServices
    {
        private readonly IMongoCollection<Contact> _contacts;

        public ContactServices(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _contacts = database.GetCollection<Contact>(config["MongoDB:CollectionName"]);
        }

        public List<Contact> GetAll() =>
        _contacts.Find(_ => true).ToList();

        public Contact GetByTd(string id) =>
        _contacts.Find(c => c.Id == id).FirstOrDefault();

        public Contact Create(Contact contact)
        {
            _contacts.InsertOne(contact);
            return contact;
        }

        public void Update(string id, Contact contact) =>
            _contacts.ReplaceOne(c => c.Id == id, contact);

        public void Delete(string id) =>
            _contacts.DeleteOne(c => c.Id == id);

    }
}