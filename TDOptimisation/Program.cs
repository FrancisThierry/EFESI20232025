using TDScaffoldOneToMany.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using var db = new OneToManyContext();


//utilisation de asNotracking

var carsWithNotracking = db.Voitures.AsNoTracking();



//Requête avec Eager Loading :

var pieces = db.Pieces;
//var cars = db.Voitures.Include(b => b.Pieces)
//                        .ToList();

var cars = db.Voitures.ToList();



foreach (Voiture car in cars)
{
    Console.WriteLine(car.Modele);
    Console.WriteLine("********");
    foreach (Piece piece in car.Pieces)
    {
        Console.WriteLine(piece.Name);
        
    }
    
}


