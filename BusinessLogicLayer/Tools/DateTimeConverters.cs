using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Tools
{
    public static class DateTimeConverters
    {
        // Calcule la date d'échéance d'une cotisation à partir de la date de souscription
        public static DateTime GetCotisationEndDate(this DateTime startDate, string duration)
        {
            switch (duration)
            {
                case "année":
                    return startDate.AddYears(1);
                case "trimestre":
                    return startDate.AddMonths(3);
                default:
                    return startDate.AddDays(1);
            }
        }

        // Vérifie si un membre est adulte ou mineur (renvoie true si adulte, false si mineur)
        public static bool CheckIfAdult(this DateTime birthDate)
        {
            DateTime today = DateTime.Now;

            if (birthDate > today.AddYears(-18))
                return false;

            return true;
        }

        // Calcule l'âge à partir de la date de naissance (correction si année bisextile)
        public static int GetAge(this DateTime birthdate)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
