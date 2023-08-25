using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class DansePartnerPoints
    {
        public string Navn { get; set; }
        public int Point { get; set; }
        public void Rating()
        {
            Console.Write("Navnet på dansepartner: ");
            string navn = Console.ReadLine();

            Console.Write("Antal point for dansepartner: ");
            int point = int.Parse(Console.ReadLine());

            Navn = navn;
            Point = point;

            Console.WriteLine("Performance ratings given");
        }
        public static DansePartnerPoints operator +(DansePartnerPoints person1, DansePartnerPoints person2)
        {
            DansePartnerPoints Finalrating = new DansePartnerPoints();
            Finalrating.Navn = $"{person1.Navn} & {person2.Navn}";
            Finalrating.Point = person1.Point + person2.Point;
            return Finalrating;
       
        }
        
    }
}