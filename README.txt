NetCompressor 1.0.0
Visual Studio 2008 CSS and JS Compression Tool
2/23/2010

Licensing
----------

Copyright (c) 2010 Brant Burnett.  All Rights Reserved.
Written by Brant Burnett <http://www.btburnett.com/> <mailto:btburnett3@gmail.com>
NetCompressor is distributed under the terms of the GNU General Public License (GPL)

NetCompressor is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

NetCompressor is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU General Public License
along with NetCompressor.  If not, see <http://www.gnu.org/licenses/>.

Google Closure is included in this tool, and is distributed under the Apache License 2.0.
For more information, please refer to ClosureLicense.txt.

YUI Compressor is included in this tool, and is distributed under the BSD License.
For more information, please refer to YUILicense.txt.

Source Control
---------------

The root branch for NetCompressor is hosted on GitHub at <http://github.com/btburnett3/NetCompressor/>.

Overview
---------

NetCompressor is a simple tool for Visual Studio 2008 which performs compression on your javascript
and CSS files at design-time.  A secondary, compressed copy is stored in the project with .min added
before the extension.  For example, style.css becomes style.min.css.

To use, simply install the tool and set the "Custom Tool" property of your CSS or javascript file to
"NetCompressorCSS" or "NetCompressorJS" respectively.  You can use the Show All Files button in your
solution explorer to see the files that are added beneath the originals.

NetCompressor uses the YUI Compressor <http://developer.yahoo.com/yui/compressor/> for CSS files,
and the Google Closure compiler <http://code.google.com/closure/> in simple optimizations mode
for javascript files.

Prerequisites
--------------

1. Visual Studio 2008
2. Java Runtime Environment <http://java.com>

Known Issues
-------------

If you are using the Visual Studio publishing feature, you must be sure to Show All Files in
your solution explorer prior to performing the publish.  If you don't, Visual Studio will not
publish the minified versions of your files.  If anyone knows a way to get around this
issue in Visual Studio, please let me know.

Bug Reporting
--------------

Please report bugs on GitHub at <http://github.com/btburnett3/NetCompressor/issues>.
		
Change Log
-----------

1.0.0
	Initial release