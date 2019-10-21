using System.Linq;

namespace HighLevelProgramming
{
    public class VideoStore : Store
    {
        public int ActionMovieDiskCount { get; set; }
        public int HorrorMovieDiskCount { get; set; }
        public int ComedyMovieDiskCount { get; set; }

        public string BestSellingGenre { get; set; }

        public bool IsRecommendedToClient(Client client)
        {
            string favoriteGenre = client.GetFavoriteGenre();
            //Returns true if the store best selling genre is the client's favorite genre
            return (favoriteGenre == BestSellingGenre);
        }

        public int AveragePlaceInLine(Client client)
        {
            //Returns -1 if the store is not recommended for the client
            if (!IsRecommendedToClient(client))
                return -1;
            //Place in line defaults to people in line + 1
            int turn = AveragePeopleInLineCount + 1;
            //If there is a membership program and the client is a member, the client moves up 2 spaces in line
            if (HasMembershipProgram && HasMember(client))
            {
                turn -= 2;
                //If they are the first person in line
                turn = turn < 1 ? 1 : turn;
            }
            
            //If the client or one of his best friends has this store as their Favorite Store
            //the client moves up 1 space in line
            if (client.FavoriteVideoStore == this)
            {
                turn -= 1;
                //If they are the first person in line
                turn = turn < 1 ? 1 : turn;
            }
            else
            {
                if (client.BestFriends.Any(friend => friend.FavoriteVideoStore == this))
                {
                    turn -= 1;
                    //If they are the first person in line
                    turn = turn < 1 ? 1 : turn;
                }
            }

            return turn;
        }

        public override string ToString()
        {
            return StoreName;
        }
    }
}