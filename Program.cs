using Final_Project;

var tacobell = new Tacobell();
var burgerking= new BurgerKing();
var mcdonalds = new McDonalds();
var wendys=new Wendys();    

bool isnumber;
do
{
    Console.WriteLine("Welcome to the fast food visualizer app");
    Console.WriteLine("Enter a fast food resturant and i will tell you which two locations are the farthest away from each other");
    Console.Write("Please choose \n 1:For Tacobell \n 2:For BurgerKing \n 3:For McDonalds \n 4:For Wendys \n");

    var userchoice = Console.ReadLine();

    int result;
    isnumber=int.TryParse(userchoice, out result);

    if (result == 1)
    {
        
        tacobell.FindFarthestAppart();
    }
    else if (result == 2)
    {
        
        burgerking.FindFarthestAppart();

    }
    else if (result==3)
    {
       
        mcdonalds.FindFarthestAppart();
    }
    else if (result == 4)
    {
        wendys.FindFarthestAppart();
    }
       
    else
    {
        Console.WriteLine("Not a valid number try again");
        Console.WriteLine();
        Console.WriteLine();
        isnumber = false;
    }
    


}while(isnumber==false);    







