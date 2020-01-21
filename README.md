# INTEG Retro Screensaver for Windows XP/Vista/7/8
# Latest build - v1.2 21/05/2012

## PRE-REQUISITES

* *_.NET Framework 4 Client Profile_*
    * Should be auto-included on most Windows 7 systems.
    * If not, try this:
http://www.microsoft.com/en-us/download/details.aspx?id=24872

## INSTALL
1. Copy .scr file into C:\Windows\SysWOW64
2. Right-click .scr file and select INSTALL

## UNINSTALL
1. Delete INTEG .scr from C:\Windows\SysWOW64


## CHANGELOG

v1.2 21/05/2012 *************************************************************************************
 - Troll code
	- New Troll startX and startY is now randomised 0-60, 0-60
	- Start direction is also randomised for new trolls, while existing start dir is preserved across runtime
	- Random generator modified to use ONE instance of Random repeatedly to increase counts - has also resolved
		bug where trolls would always move in the same direction on a direction change call
 - Configuration dialog
	- Added ability to modify colours
	- Added ability to add/remove trolls
	- Fixed Resetting Trolls to default
	- Added preview button to Configure screen
	- Fixed Troll names not updating in listbox

 TODO's identified in this release:
  - Configure screen is too cluttered - clean it up!
  - BUG: When you hit Reset to Defaults, the configure screen does not refresh the troll list
  - Start randomisation needs to be fed min,max of the screen boundaries, not 0-60
  - Re-write troll code to support id, so we don't have hackish GetTrollByName implementations littered through the code
  - BUG: when troll is deleted, its registry keys remain (non-critical)
  - implement preview functionality from http://www.harding.edu/fmccown/screensaver/screensaver.html


v1.1 13/05/2012 *************************************************************************************
 - Added Configuration dialog and functionality
 - Noted that having dot's (.) in file name will remove info from screensaver name list, keep filename simple!
 - Freed Trolls from having to individually carry the screen boundaries, and shifted that responsibility to the Playground code
 - added DrawDebugNotes() to show boundaries on screen when in DEBUG mode

 TODO's identified in this release:
  - Need to move Troll's from array to List<Troll>
  - Put Font choice into Configuration
  - Seem to have introduced color bug (see INTEG, 3rd char?)
  - Configuration dialog: Troll Items changes but listbox display does not.  FIX ME!


v1.0 05/06/2011 *************************************************************************************
 - First release

 TODO's identified in this release:
  - We need to figure out how to save Troll data to registry so we can then provide customisation
  - _r(): check if we can get better results by seeding with time.ms
  - MoveOneStep(): Reintroduce eating-the-tail bug
  - Add Configuration mode