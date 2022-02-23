using System;

namespace Arbeitszeitenrechner.Services
{
    public class Calculations
    {
        public TimeSpan[] Pausen { get; set; }
        public TimeSpan Sollstunden { get; set; }
        public TimeSpan MittagsPausenZeit { get; set; }
        public TimeSpan Ueberstunden { get; set; }

        public TimeSpan Stunden(TimeSpan anfangszeit, TimeSpan endzeit)
        {
            var stunden = endzeit - anfangszeit - Pausen[0];
            if (endzeit > new TimeSpan(12, 30, 0))
            {
                stunden -= Pausen[1];
            }

            return stunden;
        }

        /*internal TimeSpan AmFreitagUmGehen(TimeSpan kommen, TimeSpan stundenHabenwollen)
        {
            var stunden = Sollstunden.TotalHours;
            var bisarbeiten = TimeSpan.Zero;
            var today = DateTime.Today.DayOfWeek;
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    today = DayOfWeek.Monday;
                    break;
                case DayOfWeek.Sunday:
                    today = DayOfWeek.Sunday;
                    break;


            }

            for (int i = (int)today; i < 6; i++)
            {
                bisarbeiten = stundenHabenwollen + Pausen[0] + kommen;
                if (bisarbeiten > MittagsPausenZeit)
                {
                    bisarbeiten += Pausen[1];
                }
            }
            return bisarbeiten;
        }*/

        public TimeSpan UeberstundenRechner(TimeSpan anfangszeit, TimeSpan endzeit)
        {
            var stundies = Stunden(anfangszeit, endzeit);
            return stundies - (Sollstunden);

        }

        public TimeSpan WillUeberstunden(TimeSpan anfangszeit, TimeSpan willStunden)
        {
            var endzeit = anfangszeit + Sollstunden + Pausen[0];
            if (endzeit > new TimeSpan(12, 30, 0))
            {
                endzeit += Pausen[1];
            }
            return endzeit;
        }

        internal TimeSpan GearbeitetAbzueglichPausen(TimeSpan anfangszeit)
        {
            return Stunden(anfangszeit, DateTime.Now.TimeOfDay);
        }

        internal TimeSpan BereitsPause()
        {
            if (DateTime.Now.TimeOfDay > MittagsPausenZeit)
            {
                return Pausen[0] + Pausen[1];
            }
            else
            {
                return Pausen[0];
            }
        }

        internal TimeSpan BisPause()
        {
            return MittagsPausenZeit - DateTime.Now.TimeOfDay;
        }

    }
}
