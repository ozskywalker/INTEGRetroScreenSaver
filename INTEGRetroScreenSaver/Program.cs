using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace INTEGRetroScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// /p for screensaver selection dialog box
        /// /c config box
        /// /s full-screen
        /// 
        /// This helped.  A lot.  http://www.harding.edu/fmccown/screensaver/screensaver.html
        /// 
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Rudimentary cmdline argument handler
                // Handle cases where arguments are separated by colon. 
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c")           // Configuration mode
                {
                    Form configForm = new Configure();
                    configForm.ShowDialog();
                }
                /*else if (firstArgument == "/p")      // Preview mode
                {
                    ShowScreenSaver();
                    Application.Run();
                }*/
                else if (firstArgument == "/s")      // Full-screen mode
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else    // Undefined argument 
                {
                    //MessageBox.Show("Sorry, but the command line argument \"" + firstArgument + "\" is not valid.", "INTEGRetroScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                // No args, so treat like Configuration mode (/c)
                Form configForm = new Configure();
                configForm.ShowDialog();
            }
        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screensaver = new ScreenSaverForm(screen);
                screensaver.Show();
            }
        }
    }
}
