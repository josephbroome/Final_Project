using Final_Project;

var tacobell = new Tacobell();
var burgerking = new BurgerKing();
var mcdonalds = new McDonalds();
var wendys = new Wendys();
var compare = new Comparemultiple();



bool isnumber;
do
{
    Console.WriteLine("Welcome to the fast food visualizer app.");
    Console.WriteLine();
    Console.WriteLine("Please choose a fast food resturant and I will tell you which two locations are the farthest away from each other.");
    Console.WriteLine();
    Console.Write("1:For Tacobell \n2:For BurgerKing \n3:For McDonalds \n4:For Wendys \n");

    var userchoice = Console.ReadLine();

    int result;
    isnumber = int.TryParse(userchoice, out result);

    if (result == 1)
    {
        Console.WriteLine();
        Console.WriteLine("***********************************************");

        tacobell.FindFarthestAppart();
        
        Console.WriteLine();
        Console.WriteLine("***********************************************");
    }
    else if (result == 2)
    {
        Console.WriteLine();
        Console.WriteLine("***********************************************");

        burgerking.FindFarthestAppart();

        Console.WriteLine();
        Console.WriteLine("***********************************************");

    }
    else if (result == 3)
    {
        Console.WriteLine();
        Console.WriteLine("***********************************************");

        mcdonalds.FindFarthestAppart();

        Console.WriteLine();
        Console.WriteLine("***********************************************");
    
    }
    else if (result == 4)
    {
        Console.WriteLine();
        Console.WriteLine("***********************************************");

        wendys.FindFarthestAppart();

        Console.WriteLine();
        Console.WriteLine("***********************************************");
    
    }



    else
    {
        Console.WriteLine("Not a valid number try again");
        Console.WriteLine();
        Console.WriteLine();
        isnumber = false;
    }



} while (isnumber == false);

bool cont = true;


Console.WriteLine("Would you like to comapare two different locations and see how far they are apart/ Yes or No?");
var userinput = Console.ReadLine();

if (userinput.ToLower() == "yes")
{
    do
    {
        Console.WriteLine("What two fastfood restaurants would you like to comapre?");
        var firstchoice = Console.ReadLine();
        var secondchoice = Console.ReadLine();
        if (firstchoice.ToLower() == "wendys" || firstchoice.ToLower() == "mcdonalds" && secondchoice.ToLower() == "mcdonalds" || secondchoice.ToLower() == "wendys")
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            compare.McdonaldsandWendys();
            break;
        }
        if (firstchoice.ToLower() == "mcdonalds" || firstchoice.ToLower() == "burgerking" && secondchoice.ToLower() == "mcdonalds" || secondchoice.ToLower() == "burgerking")
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************");
            compare.McdonaldsandBugerKing();
            break;
        }
        if (firstchoice.ToLower() == "mcdonalds" || firstchoice.ToLower() == "tacobell" && secondchoice.ToLower() == "mcdonalds" || secondchoice.ToLower() == "tacobell") ;
        {
            Console.WriteLine();
            Console.WriteLine("***********************************************");

            compare.McdonaldsandTacoBell();
            break;

        }
    } while (false);
}













