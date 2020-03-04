using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Human : ProcessingUserData, ICloneable
    {
        public Human(ICommonUserData commonUserData) : base(commonUserData)
        {
           
        }
        static Human()
        {
            setSearchParametr += SearchParametr;
        }
        public string FirstNamePassenger { get; set; }
        public string SecondNamePassenger { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Sex { get; set; }
        public void CreatePeople(string people)
        {
            commonUserData.Print($"Adding new {people}");

            commonUserData.Print($"Enter: first name {people}");
            FirstNamePassenger = commonUserData.EnteredValueByUser();

            commonUserData.Print($"Enter: second name {people}");
            SecondNamePassenger = commonUserData.EnteredValueByUser();

            commonUserData.Print("Enter: nationality");
            Nationality = commonUserData.EnteredValueByUser();

            commonUserData.Print("Enter : date of birthday");
            EnteredValueByUser(out DateTime dateOfBirthday);
            DateOfBirthday = dateOfBirthday;

            commonUserData.Print("Enter: passport");
            Passport = commonUserData.EnteredValueByUser();

            commonUserData.Print("Enter: sex");
            Sex = commonUserData.EnteredValueByUser();

        }
        public void CreatePeople(string people, out Human human)
        {
            human = new Human(new ConsoleCommonUserData());
            human.CreatePeople(people);
        }
        public static int DeletePeople<T>(List<T> humen) where T : Human
        {
            commonUserData.Print("Choose pepople for delete:");
            PrintPeopleName(humen);
            EnteredValueByUser(out int input);
            return (input - 1);
        }
        public static void PrintPeopleName<T>(List<T> humen) where T : Human
        {
            for (int i = 0; i < humen.Count; i++)
            {
                commonUserData.Print($@"        {i + 1}.  People: {humen[i].FirstNamePassenger} {humen[i].SecondNamePassenger}");
            }
        }
        public static List<string > parametrs = new List<string> { "First name", "Second name", "Nationality", "Passport", "Birthday", "Sex" };
       
        public static Tuple<bool,int> SearchInformation<T>(List<T> humen, SetSearchParametr<T> setSearchParametr) where T : Human
        {
            commonUserData.Print("Choose parametr, which you want to use for search: ");
            for (int i = 0; i < parametrs.Count; i++)
            {
                commonUserData.Print($"       {i + 1}.  {parametrs[i]}");
            }
            EnteredValueByUser(out int searchParamNumber);

            Func<T, bool> compare;

            ParamHumanForSearch searchParam = (ParamHumanForSearch)searchParamNumber;
            switch (searchParam)
            {
                case ParamHumanForSearch.FirstNamePassenger:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        setSearchParametr?.Invoke(humen, compare = (human) => human.FirstNamePassenger == commonUserData.EnteredValueByUser());
                        break;
                    }
                case ParamHumanForSearch.SecondNamePassenger:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        setSearchParametr?.Invoke(humen, compare = (human) => human.SecondNamePassenger == commonUserData.EnteredValueByUser());
                        break;
                    }
                case ParamHumanForSearch.Nationality:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        setSearchParametr?.Invoke(humen, compare = (human) => human.Nationality == commonUserData.EnteredValueByUser());
                        break;
                    }
                case ParamHumanForSearch.Passport:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        setSearchParametr?.Invoke(humen, compare = (human) => human.Passport == commonUserData.EnteredValueByUser());
                        break;
                    }
                case ParamHumanForSearch.DateOfBirthday:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        EnteredValueByUser(out DateTime searchBirthday);
                        setSearchParametr?.Invoke(humen, compare = (human) => human.DateOfBirthday == searchBirthday);
                        break;
                    }
                case ParamHumanForSearch.Sex:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        setSearchParametr?.Invoke(humen, compare = (human) => human.Passport == commonUserData.EnteredValueByUser());
                        break;
                    }

                default:
                    //commonUserData.PrintUserUncorrectInput("Exit. Not found option");
                    //break;
                    return Tuple.Create(false, searchParamNumber);
            }
            return Tuple.Create(true, searchParamNumber);
        }
        public static void SearchParametr<T>(List<T> humen, Func<T, bool> searchParametr) where T : Human
        {
            foreach (var human in humen)
            {
                if (searchParametr(human))
                {
                    commonUserData.Print(human.FirstNamePassenger);
                }
            }
        }
        public delegate void SetSearchParametr<T>(List<T> humen, Func<T, bool> searchParametr);
        private static readonly SetSearchParametr<Human> setSearchParametr;

        public void UpdatePeopleInformation<T>(List<T> humen) where T : Human
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
