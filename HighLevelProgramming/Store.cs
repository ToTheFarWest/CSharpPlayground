using System;

namespace HighLevelProgramming
{
    public class Store
    {
        private int _zipCode;
        
        public string StoreName { get; set; }
        
        public int StoreId { get; set; }
        
        public int AveragePeopleInLineCount { get; set; }
        
        public int AverageItemPrice { get; set; }

        public int ZipCode
        {
            get => _zipCode;
            set
            {
                //Zip codes can only be 7 digits long
                const int zipCodeLength = 7;
                if (value.ToString().Length != zipCodeLength)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} can only be {zipCodeLength} digits long");
                _zipCode = value;
            }
        }
        
        public bool HasMembershipProgram { get; set; }

        public StoreMembership[] StoreMembers { get; set; }

        public bool HasMember(Client client)
        {
            foreach (var storeMember in StoreMembers)
            {
                if (storeMember.Client == client)
                    return true;
            }

            return false;
        }



    }
}