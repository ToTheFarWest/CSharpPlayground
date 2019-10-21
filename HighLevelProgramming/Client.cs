using System;

namespace HighLevelProgramming
{
    public class Client
    {
        private int _actionMovieRating,
            _horrorMovieRating,
            _comedyMovieRating;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public int Id { get; set; }
        
        public VideoStore FavoriteVideoStore { get; set; }
        
        public Client[] BestFriends { get; set; }

        public StoreMembership[] StoreMemberships { get; set; }

        public int ActionMovieRating
        {
            get => _actionMovieRating;
            set
            {
                //Value can be between 1 & 5
                const int minRating = 1;
                const int maxRating = 5;
                if (value > maxRating || value < minRating)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} can be only be between {minRating} and {maxRating}");

                _actionMovieRating = value;
            }
        }
        public int HorrorMovieRating
        {
            get => _horrorMovieRating;
            set
            {
                //Value can be between 1 & 5
                const int minRating = 1;
                const int maxRating = 5;
                if (value > maxRating || value < minRating)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} can be only be between {minRating} and {maxRating}");

                _horrorMovieRating = value;
            }
        }
        public int ComedyMovieRating
        {
            get => _comedyMovieRating;
            set
            {
                //Value can be between 1 & 5
                const int minRating = 1;
                const int maxRating = 5;
                if (value > maxRating || value < minRating)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} can be only be between {minRating} and {maxRating}");

                _comedyMovieRating = value;
            }
        }

        public string GetFavoriteGenre()
        {
            //Evaluates which genre the client prefers
            string favoriteGenre;
            if (ActionMovieRating > HorrorMovieRating)
            {
                favoriteGenre = ActionMovieRating > ComedyMovieRating ? "action" : "comedy";
            }
            else
            {
                favoriteGenre = HorrorMovieRating > ComedyMovieRating ? "horror" : "comedy";
            }

            return favoriteGenre;
        }

        public override string ToString()
        {
            return GetFullName();
        }
    }
}