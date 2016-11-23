using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoAzureOfflineSync
{
    public class AzureClient
    {
        private IMobileServiceClient _client;
        private IMobileServiceTable<Contact> _table;
		private const string serviceUri= "";
        public AzureClient()
        {
			_client = new MobileServiceClient(serviceUri);

            _table = _client.GetTable<Contact>();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var empty = new Contact[0];
            try
            {
                return await _table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }

		public async void AddContact(Contact contact) 
		{
			await _table.InsertAsync(contact);

		}

    }
}
