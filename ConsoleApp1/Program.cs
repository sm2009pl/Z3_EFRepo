using System;
using System.Linq;
namespace Z3_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using var baza = new Kontekst();
            baza.Database.EnsureCreated();
            var nowyStudent = new Student() { Imie = "Marcin", Nazwisko = " Nowak" };
            baza.Students.Add(nowyStudent);
            baza.SaveChanges();

            var studenci = baza.Students.Where(x => x.Imie == "Marcin");
            foreach (var item in studenci)
            {
                Console.WriteLine($"{item.Id} {item.Imie} {item.Nazwisko}");
            }

            var student = baza.Students.Where(x => x.Id == 4).First();
            student.Imie = "Piotr";
            baza.Students.Update(student);
            baza.SaveChanges();
            baza.Remove(nowyStudent);
            baza.SaveChanges();
        }
    }
}


/*
    "Creating a model for an existing database in entity framework core" <=== do google


    Scaffold-DbContext "connectionstring" Microsoft.EntityFrameworkCore.SqlSerwer -OutputDir "Models"
 
    z Microsoft.EntityFrameworkCore.Tools

    w PowerShell

    utworzy klasy na podstawie bazy danych


    Zadanie:
    Dla klienta o podanym ID wypisać zamówienia i produkty dla każdegoz tych zamówień.
*/
