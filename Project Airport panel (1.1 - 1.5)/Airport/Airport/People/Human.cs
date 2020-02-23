using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Human: EnterUserData
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
    }
}
