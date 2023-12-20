using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _932021.abrosimova.margarita.lab11.Models
{
 
    public class QuestionPageModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Act { get; set; }
        public int Answer { get; set; }
        public string Problem { get; set; }
        [Required(ErrorMessage = "Не введен ответ")]
        [Range(-100, 100)]
        public string yanswer { get; set; }

        public QuestionPageModel()
        {
            Random rnd = new Random();
            Act = rnd.Next(4);
            A = rnd.Next(11);
            B = Act == 3  ? rnd.Next(1, 11): rnd.Next(0, 11);
            switch (Act)
            {
                case 0: Answer = A * B; 
                    Problem = (A) + " * " + (B) + " =";
                    break;
                case 1: Answer = A + B;
                    Problem =  (A) + " + " + (B) + " =";
                    break;
                case 2: Answer = A - B;  
                    Problem = (A) + " - " + (B) + " =";
                    break;
                case 3: Answer = A / B; 
                    Problem =  (A) + " / " + (B) + " =";
                    break;
            }
        }
    }

    public class IdentityMap
    {
        private static readonly IdentityMap Instance = new IdentityMap();
        List<QuestionPageModel> actions = new List<QuestionPageModel>();
        private IdentityMap() { }
        public static int alls;
        public static int rights;
        public static void Up()
        {
            Instance.actions.Clear();
            alls = 0;
            rights = 0;
        }
        public static void AddAction(QuestionPageModel action)
        {
            Instance.actions.Add(action);
        }
        public static List<QuestionPageModel> Get()
        {
            return Instance.actions;
        }
    }
}