using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Windows.Forms;

// TODO: Somewhere, in here, we're still keeping the last Troll when we delete it, but its not critical

namespace INTEGRetroScreenSaver
{
    public class UserPreferences
    {
        private int _nMoveInterval;
        public int nMoveInterval
        {
            get { return _nMoveInterval; }
            set { _nMoveInterval = value; }
        }

        private int _nSteps;
        public int nSteps
        {
            get { return _nSteps; }
            set { _nSteps = value; }
        }

        private int _nTrolls;
        public int nTrolls
        {
            get { return _nTrolls; }
            set { _nTrolls = value; }
        }

        private Troll[] _trolls = new Troll[2];
        public Troll[] trolls
        {
            get { return _trolls; }
            set { _trolls = value; }
        }

        public void ResizeTrolls(int newvalue)
        {
            Array.Resize<Troll>(ref _trolls, newvalue);
            _nTrolls++;
        }

        public void RemoveTroll(string HeWhoShallNotBeNamed)
        {
            Troll[] newtrolls = new Troll[_nTrolls - 1];
            int HeWhoShallNotBeNamedsNumber = -1;
            int j = 0;

            for (int i = 0; i < _nTrolls; i++)
            {
                if (_trolls[i].Name != HeWhoShallNotBeNamed)
                {
                    newtrolls[j] = _trolls[i];
                    j++;
                }
                else
                {
                    HeWhoShallNotBeNamedsNumber = i;
                }
            }

            if (HeWhoShallNotBeNamedsNumber == -1) return;

            RegistryKey UserPrefs = Registry.CurrentUser.OpenSubKey("SOFTWARE\\INTEGRetroScreenSaver", true);
            if (UserPrefs != null)
            {
                String TrollName = "Troll" + HeWhoShallNotBeNamedsNumber.ToString();

                ClearRegistrySettings();
                SetRegistrySettings();
            }

            _trolls = new Troll[_nTrolls - 1];
            _trolls = newtrolls;
            _nTrolls--;
        }

        public void ClearRegistrySettings()
        {
            Registry.CurrentUser.DeleteSubKey("SOFTWARE\\INTEGRetroScreenSaver", false);
        }

        public void GetRegistrySettings()
        {
            RegistryKey UserPrefs = Registry.CurrentUser.OpenSubKey("SOFTWARE\\INTEGRetroScreenSaver", true);
            String TrollName;

            if (UserPrefs != null)
            {
                _nMoveInterval = Int32.Parse((string)UserPrefs.GetValue("nMoveInterval"));
                _nSteps = Int32.Parse((string)UserPrefs.GetValue("nSteps"));
                _nTrolls = Int32.Parse((string)UserPrefs.GetValue("nTrolls"));

                _trolls = new Troll[_nTrolls];
                for (int i = 0; i < _nTrolls; i++)
                {
                    // name, X, Y, direction, no. of colours, color options
                    TrollName = "Troll" + i.ToString();
                    Color first, second, third;

                    first = Color.FromArgb(Int32.Parse((string)UserPrefs.GetValue(TrollName + "_color0")));
                    second = Color.FromArgb(Int32.Parse((string)UserPrefs.GetValue(TrollName + "_color1")));
                    third = Color.FromArgb(Int32.Parse((string)UserPrefs.GetValue(TrollName + "_color2")));

                    _trolls[i] = new Troll(
                        (string)UserPrefs.GetValue(TrollName + "_name"),
                        Int32.Parse((string)UserPrefs.GetValue(TrollName + "_startX")),
                        Int32.Parse((string)UserPrefs.GetValue(TrollName + "_startY")),
                        (Troll.MoveDir)(Int32.Parse((string)UserPrefs.GetValue(TrollName + "_startdir"))),
                        _nSteps,
                        first, second, third
                        );
                }

            } else {
                RegistryKey newKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                newKey.CreateSubKey("INTEGRetroScreenSaver");

                SetDefaults();
                SetRegistrySettings();
            }
        }

        public void SetRegistrySettings()
        {
            RegistryKey UserPrefs = Registry.CurrentUser.OpenSubKey("SOFTWARE\\INTEGRetroScreenSaver", true);
            String TrollName;

            if (UserPrefs == null)
            {
                RegistryKey newKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                newKey.CreateSubKey("INTEGRetroScreenSaver");
                UserPrefs = Registry.CurrentUser.OpenSubKey("SOFTWARE\\INTEGRetroScreenSaver", true);
            }

            UserPrefs.SetValue("nMoveInterval", _nMoveInterval.ToString());
            UserPrefs.SetValue("nSteps", _nSteps.ToString());
            UserPrefs.SetValue("nTrolls", _nTrolls.ToString());

            for (int i=0; i < _nTrolls; i++)
            {
                TrollName = "Troll" + i.ToString();

                UserPrefs.SetValue(TrollName + "_name", trolls[i].Name);
                UserPrefs.SetValue(TrollName + "_startX", trolls[i].startX.ToString());
                UserPrefs.SetValue(TrollName + "_startY", trolls[i].startY.ToString());
                UserPrefs.SetValue(TrollName + "_startdir", ((int)trolls[i].startDirection).ToString());
                UserPrefs.SetValue(TrollName + "_color0", trolls[i].first.ToArgb().ToString());
                UserPrefs.SetValue(TrollName + "_color1", trolls[i].second.ToArgb().ToString());
                UserPrefs.SetValue(TrollName + "_color2", trolls[i].third.ToArgb().ToString());
            }
        }

        public void SetDefaults()
        {
            // Internal settings
            _nMoveInterval = 225;
            _nSteps = 15;

            // Setup troll containers
            _nTrolls = 2;
            _trolls = new Troll[_nTrolls];

            // Troll creatures themselves
            _trolls[0] = new Troll(
                "INTEG",        // what makes up the troll?
                0, 0,         // X, Y (-1 = randomize)
                0,              // initial direction - 0 for randomised
                _nSteps,
                System.Drawing.Color.Gold,     // 1st colour
                System.Drawing.Color.Green,    // 2nd colour
                System.Drawing.Color.Gold);   

            _trolls[1] = new Troll(
                "SDT",
                0, 0,
                0,
                _nSteps,
                System.Drawing.Color.Red,
                System.Drawing.Color.White,
                System.Drawing.Color.Blue);    // add as many colours as you want
        }
    }
}
