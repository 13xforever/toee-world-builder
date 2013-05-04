ToEE World Builder version 2.0.5a Open-Source Edition
=====================================================

Copyright &copy; 2005-2013 Michael Kamensky, all rights reserved.

---

This program is free software; you can redistribute it and/or modify
it under the terms of the [GNU General Public License](gpl.txt) as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but _without any warranty_; without even the implied warranty of
_merchantability_ or _fitness for a particular purpose_. See the
[GNU General Public License](gpl.txt) for more details.

You should have received a copy of the [GNU General Public License](gpl.txt)
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

---

!!! PLEASE READ THIS INFORMATION FIRST !!!
------------------------------------------

This package includes the source code and all required files needed to
build a redistributable package of the ToEE World Builder .NET2.

Requirements
------------

In order to successfully compile ToEE World Builder .NET2, you need the
following software:

* [Microsoft .NET Framework v2.0](http://www.microsoft.com/net/download) or newer
* [Microsoft Visual C# 2005](http://www.microsoft.com/visualstudio/eng/downloads) or any newer release (Express version is free)

Note that other IDEs supporting C# 2.0 _may_ be able to build the ToEEWB.NET2
successfully, but this was never tested.

Note before you start modifying
-------------------------------

THE ORIGINAL CREDITS AND THE DEDICATION LINE IN THE ABOUT BOX OF THE TOEE WORLD
BUILDER MUST BE RETAINED IN ALL CUSTOM BUILDS !!!

Package contents
----------------

The following folders are distributed with this package:

* [src](src) - includes the source code itself. You need to load `ToEE World Builder.sln`
      into Visual C# in order to load the project. Also, the latest version of
      [whatsnew.txt](src/whatsnew.txt) is located in this folder.

* [required-files](required-files) - contains files that **must** be distributed with the ToEE World
                 Builder .NET2 executable, otherwise ToEEWB may behave incorrectly
                 or may cease to work at all.

* [supplements](supplements) - includes the supplementary information that may be useful during
              the development of ToEEWB. Currently it includes a fixed list of
              MOB format properties with their corresponding IDs.

Also, [gpl.txt](gpl.txt) is included which contains the full text of the General Public
License (GPL) version 2, under the terms of which this package is distributed.

Compiling the code
------------------

After loading `ToEE World Builder.sln` solution file into the
Visual C# IDE you may choose the **Build solution** option to create an executable.
Afterwards, you will need to copy the files from the `required-files` folder into
the folder where your executable is in order to ensure the correct work of the
compiled ToEE World Builder.

Support
-------

The open source distribution comes with no specific support. As usual, you are
free to ask questions about the code on the forum in the corresponding thread.

Disclaimer
----------

Any third-party derivative work based on this open source package is **not** 
supported by the original program authors. Use the derived builds of ToEEWB
at your own risk.
