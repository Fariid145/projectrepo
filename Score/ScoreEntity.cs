using System;
namespace ScoreRecord
{
    public class ScoreEntity
    {
        public string Name { get; set; }
        public int EnglishGrade  { get; set; }
        public int MathGrade  { get; set; }
        public int EconomicGrade { get; set; }

        public ScoreEntity(string name, int englishGrade, int mathGrade, int economicGrade)
        {
            Name = name;
            EnglishGrade  = englishGrade;
            MathGrade  = mathGrade;
            EconomicGrade = economicGrade;
        }

        public override string ToString()
        {
            return $"{Name}\t{EnglishGrade}\t{MathGrade}\t{EconomicGrade}";
        }

        internal static ScoreEntity StringToScoreEntity(string scoreString)
        {
            var props = scoreString.Split("\t");

            int englishGrade = int.Parse(props[1]);

            int mathGrade = int.Parse(props[2]);

            int economicGrade = int.Parse(props[3]);

            return new ScoreEntity(props[0], englishGrade, mathGrade, economicGrade);
        }
    }

}