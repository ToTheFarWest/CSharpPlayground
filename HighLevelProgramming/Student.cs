using System;

namespace HighLevelProgramming
{
    public class Student
    {
        private int _computerGrade,
            _mathGrade,
            _historyGrade,
            _bibleGrade;


        public string Name { get; set; }

        public string DadName { get; set; }

        public string BffName { get; set; }

        public int ComputerGrade
        {
            get => _computerGrade;
            set
            {
                if (value > 100 || value < 99)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be between 99 and 100"
                    );

                _computerGrade = value;
            }
        }

        public int MathGrade
        {
            get => _mathGrade;
            set
            {
                if (value < 40 || value > 55)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be between 40 and 55"
                    );
                _mathGrade = value;
            }
        }

        public int HistoryGrade
        {
            get => _historyGrade;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be between 1 and 100"
                    );
                _historyGrade = value;
            }
        }

        public int BibleGrade
        {
            get => _bibleGrade;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} must be between 1 and 100"
                    );
                _bibleGrade = value;
            }
        }
    }
}