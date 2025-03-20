﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiOP4
{
    public class Korisnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }

        public Korisnik(int id, string ime, string prezime, string kontakt)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Kontakt = kontakt;
        }

        public override string ToString()
        {
            return $"{ID};{Ime};{Prezime};{Kontakt}"; // Format za spremanje u datoteku
        }

        public static Korisnik FromString(string line)
        {
            var parts = line.Split(';');
            return new Korisnik(int.Parse(parts[0]), parts[1], parts[2], parts[3]);
        }
    }
}

