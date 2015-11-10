# PrintScreenAlternative
Since my Surface Pro 3 keyboard does not have a physical print screen button, I decided to make my own solution.

When the application is launched a dialog box will appear with a welcome message and the printscreen icon will be displayed in
the system task try. The application can perform the two following operations:

      Left Click: Print Screen (replicates keystroke of a physical Print Screen Button)
      Right Click: Print Screen & save screenshot as an image (w/dialog box).
      
Note: The application will close after taking a screenshot.

Keyboard Shortcut/Task Bar Setup
 1. Create a desktop shortcut to the program
      PrintScreenAlternative > bin > Debug > PrintScreenApplication (file type: Application)
 2. Right click on the new desktop shortcut icon and select Properties
 3. Type a shortcut that will be used to open the PrintScreenAlternative application and select Apply
   and/or
 4. Right click the shortcut to the appplication and click on "Pin to Taskbar"

Known Issues:
  1. The dialog box will appear each time the application is launched. Future releases will show the dialog box only appearing on the first launch.
  2. If loading the application for the first time after a shut down, if the right click function is selected without any instance of an image of a clipboard, an error message will appear. To fix this, when launching the application for the first time, use the left click function. After that an instance will be created and the right click function will fully operational.
