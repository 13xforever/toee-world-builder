ToEE World Builder 3.0 (WiP)
============================

&copy; 2005-2013 Michael Kamensky, all rights reserved.

### NOTE
	This is a refactoring branch. A lot of strange things will happen here, probably undocumented, so be cautious.

It is strongly recommended to look at the [stable tree](../../tree/stable) for the latest release.

---

This program is free software; you can redistribute it and/or modify it under the terms of the [GNU General Public License](gpl.txt) as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but _without any warranty_; without even the implied warranty of _merchantability_ or _fitness for a particular purpose_. See the [GNU General Public License](gpl.txt) for more details.

You should have received a copy of the [GNU General Public License](gpl.txt) along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

---

Requirements
------------

In order to successfully compile ToEE World Builder .NET2, you need the following software:

* [Microsoft .NET Framework 4.0 Redistributable](http://www.microsoft.com/net/download) or newer is **needed** (pre-installed on Windows 8)
* [Microsoft Visual Studio 2010](http://www.microsoft.com/visualstudio/eng/downloads) or newer is **recommended** (includes .NET redistributable)

Note that Express Edition is free. Other IDEs supporting C# 4.0 _may_ be able to build the ToEEWB successfully, but this was never tested.

Note before you start modifying
-------------------------------

THE ORIGINAL CREDITS AND THE DEDICATION LINE IN THE ABOUT BOX OF THE TOEE WORLD BUILDER MUST BE RETAINED IN ALL CUSTOM BUILDS !!!

Package contents
----------------

The following folders are distributed with this package:

* [src](src) - includes the source code itself.

* [required-files](required-files) - contains files with updates that might be distributed separately from the full installation of ToEEWB.

* [supplements](supplements) - includes the supplementary information that may be useful during the development of ToEEWB. Currently it includes a fixed list of MOB format properties with their corresponding IDs.

Also, [gpl.txt](gpl.txt) is included which contains the full text of the General Public License (GPL) version 2, under the terms of which this package is distributed.

Compiling the code
------------------

If you have Visual Studio 2010 or newer, you can open `ToEE World Builder.sln` solution file and then choose to **Build solution** option to create an executable.

If you only have .NET 4.0 or newer, you can build solution from command line. Just run `build.cmd` batch file from `src` directory.

Support
-------

The open source distribution comes with no specific support. As usual, you are free to ask questions about the code on the forum in the [ToEEWB thread](http://www.co8.org/forum/showthread.php?t=2864).

Disclaimer
----------

Any third-party derivative work based on this open source package (such as this fork) is **not** supported by the original program authors. Use the derived builds of ToEEWB at your own risk.
