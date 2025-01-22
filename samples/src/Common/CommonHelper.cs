using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VControl.Samples.Models;

namespace VControl.Samples.Common
{
    public class CommonHelper
    {

        private static Random _random = new Random();
        private static List<string> _firstNames = new List<string> { "John", "Emma", "Michael", "Sophia", "James", "Olivia", "David", "Isabella", "Daniel", "Charlotte" };
        private static List<string> _lastNames = new List<string> { "Smith", "Johnson", "Brown", "Davis", "Wilson", "Moore", "Taylor", "Anderson", "Harris", "Clark" };

        public static List<PickerM> GenerateRandomNamesAndEmails(int count)
        {
            var result = new List<PickerM>();

            for (int i = 0; i < count; i++)
            {
                var firstName = _firstNames[_random.Next(_firstNames.Count)];
                var lastName = _lastNames[_random.Next(_lastNames.Count)];

                var fullName = $"{firstName} {lastName}";
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@email.com";

                result.Add(new PickerM()
                {

                    Title = fullName,
                    Value = email
                });
            }

            return result;
        }
    }
}
