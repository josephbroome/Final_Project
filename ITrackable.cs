using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public  interface ITrackable
    {
        string Name { get; set; }
        string State { get; set; }

        string Address { get; set; }
        
        string Phonenumber { get; set; }    
        Point Location { get; set; }
    }
}
