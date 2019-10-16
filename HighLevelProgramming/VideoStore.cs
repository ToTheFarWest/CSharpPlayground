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
            //Evaluates which genre the client prefers
            string favoriteGenre;
            if (client.ActionMovieRating > client.HorrorMovieRating)
            {
                favoriteGenre = client.ActionMovieRating > client.ComedyMovieRating ? "action" : "comedy";
            }
            else
            {
                favoriteGenre = client.HorrorMovieRating > client.ComedyMovieRating ? "horror" : "comedy";
            }

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
            if (HasMembershipProgram && Members.Contains(client))
            {
                turn = turn - 2;
                //If they are the first person in line
                turn = turn < 1 ? 1 : turn;
            }

            return turn;
        }
    }
}