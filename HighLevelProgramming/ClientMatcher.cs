using System;
using System.Collections.Generic;
using System.Linq;

namespace HighLevelProgramming
{
    public class ClientMatcher
    {
        public Client[] Clients { get; set; }

        public int[] ClientZipCodes { get; set; }
        public VideoStore[] VideoStores { get; set; }


        public VideoStore StoreForClient(int clientId)
        {
            //Throws an exception if no client with clientId exists
            Client client = Clients.SingleOrDefault(c => c.Id == clientId);
            if (client == null)
                throw new KeyNotFoundException($"No client found with ID ${clientId}");

            //Parses through video stores, returning the first one that matches the client
            VideoStore store = VideoStores.FirstOrDefault(v => v.IsRecommendedToClient(client));
            if (store == null)
                throw new KeyNotFoundException($"No valid store found for client ${client}");
            return store;
        }

        public VideoStore ClosestRecommendedStore(int clientId)
        {
            //Throws an exception if no client with clientId exists
            int clientIndex = Array.FindIndex(Clients, c => c.Id == clientId);
            if (clientIndex == -1)
                throw new KeyNotFoundException($"No client found with ID ${clientId}");
            Client client = Clients[clientIndex];
            int clientZipCode = ClientZipCodes[clientIndex];

            //Parses through video stores, returning an array of all compatible stores
            VideoStore[] compatibleStores = VideoStores.Where(v => v.IsRecommendedToClient(client)).ToArray();

            //Sorts the array based on distance from client
            Array.Sort(compatibleStores, (s1, s2) =>
            {
                int v1 = Math.Abs(s1.ZipCode - clientZipCode);
                int v2 = Math.Abs(s2.ZipCode - clientZipCode);
                return v1.CompareTo(v2);
            });

            //Returns the first item in that array, if it exists
            VideoStore store = compatibleStores[0];
            if (store == null)
                throw new ArgumentException($"No store found for client ${client}");
            return store;
        }

        public VideoStore RecommendedStoreWithShortestWait(int clientId)
        {
            //Throws an exception if no client with clientId exists
            Client client = Clients.SingleOrDefault(c => c.Id == clientId);
            if (client == null)
                throw new KeyNotFoundException($"No client found with ID ${clientId}");

            //Get array of compatible stores with client
            VideoStore[] compatibleStores = VideoStores.Where(s => s.IsRecommendedToClient(client)).ToArray();

            //Sort array based on estimated wait time
            Array.Sort(compatibleStores,
                (s1, s2) => s1.AveragePlaceInLine(client).CompareTo(s2.AveragePlaceInLine(client)));

            //Return first item in array, if it exists
            VideoStore store = compatibleStores[0];
            if (store == null)
                throw new ArgumentException($"No compatible store found for client ${client}");
            return store;
        }

        public VideoStore RecommendedStoreWithLowestPrice(int clientId)
        {
            //Throws an exception if no client with clientId exists
            Client client = Clients.SingleOrDefault(c => c.Id == clientId);
            if (client == null)
                throw new KeyNotFoundException($"No client found with ID ${clientId}");

            //Get array of compatible stores with client
            VideoStore[] compatibleStores = VideoStores.Where(s => s.IsRecommendedToClient(client)).ToArray();

            //Sort array based on store average price
            Array.Sort(compatibleStores, (s1, s2) => s1.AverageItemPrice.CompareTo(s2.AverageItemPrice));

            //Return first store in this array, if it exists
            VideoStore store = compatibleStores[0];
            if (store == null)
                throw new ArgumentException($"No compatible store found for client {client}");
            return store;
        }

        public void PrintFastestAndCheapestStoresForAllClients()
        {
            //Loop over all clients
            foreach (var client in Clients)
            {
                //Print their names
                Console.WriteLine("Name: " + client);
                //Print their favorite genre
                Console.WriteLine("Favorite genre: " + client.GetFavoriteGenre());
                //Print the store with shortest wait time
                Console.WriteLine("Recommended store based on wait time: " + RecommendedStoreWithShortestWait(client.Id));
                //Print the store with lowest price
                Console.WriteLine("Recommended store based on price: " + RecommendedStoreWithShortestWait(client.Id));
                //Print divider between customers
                Console.WriteLine(new String('=', 20));
            }
        }

        public void PrintExpiredMembersForAllStores()
        {
            //Loop over all stores
            foreach (var store in VideoStores)
            {
                //Print their names
                Console.WriteLine($"Name: {store.StoreName}");
                //Loop over their Members
                foreach (var storeMember in store.StoreMembers)
                {
                    //Print client name if membership is expired
                    if (storeMember.IsExpired())
                        Console.WriteLine(storeMember.Client);
                }

                //Print divider between stores
                Console.WriteLine(new String('=', 20));
            }

        }
    }
}