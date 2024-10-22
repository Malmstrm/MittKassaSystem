using MittKassaSystem.MenuFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem
{
    public class App
    {
        public void Start()
        {

            Console.WriteLine("Welcome to KassaSystemet 1.0\n");
            Console.WriteLine("Loading system.");
            Console.WriteLine("Loading files.");

            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

        }
    }
}
