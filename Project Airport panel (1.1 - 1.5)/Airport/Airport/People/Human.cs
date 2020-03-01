using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Human: ProcessingUserData,ICloneable
    {
        public Human(ICommonUserData commonUserData) : base(commonUserData)
        {

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
            PrintPeople(humen);
            EnteredValueByUser(out int input);
            return (input - 1);
        }
        public static  void PrintPeople<T>(List<T> humen) where T:Human
        {
            for (int i = 0; i < humen.Count; i++)
            {
                commonUserData.Print($@"        {i + 1}.  Flight: {humen[i].FirstNamePassenger} {humen[i].SecondNamePassenger}");
            }
        }

        public static void SearchInformation<T>(List<T> humen) where T: Human
        {

        }
        public static void UpdatePeopleInformation<T>(List<T> humen) where T : Human
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
