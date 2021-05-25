using System;
namespace ScoreListDataBase
{
    public class Score
    {
        public string StudentName { get; set;}
        public int EnglishScore { get; set; }
        public int MathScore { get; set; }
        public int EconomicScore { get; set; }

        public Score(string studentName, int englishScore, int mathScore, int economicScore)
        {
            StudentName = studentName;
            EnglishScore = englishScore;
            MathScore = mathScore;
            EconomicScore = economicScore;
        }
    }
}