using Final_Project;

var tacobell = new Tacobell();
var burgerking = new BurgerKing();
var mcdonalds = new McDonalds();
var wendys = new Wendys();
var compare = new Comparemultiple();



bool isnumber;
do
{
    Console.WriteLine("Welcome to the fast food visualizer app");
    Console.WriteLine("Please choose food resturant and i will tell you which two locations are the farthest away from each other");
    Console.Write("1:For Tacobell \n 2:For BurgerKing \n 3:For McDonalds \n 4:For Wendys \n");

    var userchoice = Console.ReadLine();

    int result;
    isnumber = int.TryParse(userchoice, out result);

    if (result == 1)
    {

        tacobell.FindFarthestAppart();
    }
    else if (result == 2)
    {

        burgerking.FindFarthestAppart();

    }
    else if (result == 3)
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



} while (isnumber == false);

bool cont = true;


Console.WriteLine("Would you like to comapare two different locations and see how far they are apart/ Yes or No?");
var userinput = Console.ReadLine();

if (userinput.ToLower() == "yes")
{
    do
    {
        Console.WriteLine("What two fastfood restaurants would you like to comapre");
        var firstchoice = Console.ReadLine();
        var secondchoice = Console.ReadLine();
        if (firstchoice.ToLower() == "wendys" || firstchoice.ToLower() == "mcdonalds" && secondchoice.ToLower() == "mcdonalds" || secondchoice.ToLower() == "wendys")
        {
            compare.McdonaldsandWendys();
            break;
        }
        if (firstchoice.ToLower() == "mcdonalds" || firstchoice.ToLower() == "burgerking" && secondchoice.ToLower() == "mcdonalds" || secondchoice.ToLower() == "burgerking")
        {
            compare.McdonaldsandBugerKing();
            break;
        }
    } while (true);
}













