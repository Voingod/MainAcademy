using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Human: InputUserValue<Human>
    {
        public Human(IPrinter <Human>workWithUserData) : base(workWithUserData)
        {

        }
        public string FirstNamePassenger { get; set; }
        public string SecondNamePassenger { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Sex { get; set; }
        public Human CreatePeople()
        {
            workWithUserData.Print("Adding new passanger");
            Human human = new Human(new ConsoleWorkingOnUserData<Human>());

            workWithUserData.Print("Enter : first name passenger");
            human.FirstNamePassenger = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter : second name passenger");
            human.SecondNamePassenger = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter : nationality");
            human.Nationality = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter : date of birthday");
            EnteredValueByUser(out DateTime dateOfBirthday);
            human.DateOfBirthday = dateOfBirthday;

            workWithUserData.Print("Enter : passport");
            human.Passport = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter : sex");
            human.Sex = workWithUserData.EnteredValueByUser();

            return human;
        }
    }
}
