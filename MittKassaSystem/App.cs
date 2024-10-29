using MittKassaSystem.MenuFolder;
using MittKassaSystem.ProductFolder;
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
            MainMenu mainMenu = new MainMenu();

            mainMenu.Show();

        }
    }
}
