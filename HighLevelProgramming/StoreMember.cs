using System;

namespace HighLevelProgramming
{
    public class StoreMembership
    {
        private Client _client;
        private Store _store;
        private DateTime _created;
        private DateTime? _expires;

        public Client Client => _client;

        public Store Store => _store;

        public DateTime Created => _created;
        
        public StoreMembership(Client client, Store store, DateTime created, DateTime? expires)
        {
            _client = client;
            _store = store;
            _created = created;
            _expires = expires;
        }
        
        public bool IsExpired()
        {
            if (_expires == null)
                return false;
            return _expires > DateTime.Now;
        }
        
    }
}