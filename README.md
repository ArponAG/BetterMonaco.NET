# BetterMonaco.NET
Binding for Microsoft's Monaco Editor Based off Monaco.NET.

Credits to:
- CEFSharp - Web Browser used to render Monaco Editor.
- op0x59 - Creating Monaco.NET.

# What's different between this and Monaco.NET ?
Monaco.NET wasn't working correctly due to it using WebBrowser.
Issue is, WebBrowser is using IE, and Monaco doesn't support IE stuff. op0x59 tried to fix that issue by changing the IE version to 11, but doesn't work for everyone.

BetterMonaco.NET uses CEFSharp, It's Chromium Embedded. (aka Google Chrome, sort of.)

# Adds and Cons?
Adds:
- This binding will be updated frequently (unlike Monaco.NET)
- Doesn't use WebBrowser but Chromium Embedded (CEFSharp); Should work on absolutly all devices without any compatibilities issues!

Cons:
- CEFSharp creates a horrible mess. (See: https://vgy.me/ZyGeJ6.png)
- Doesn't support AnyCPU (Yet, I'll find make support for it when I consider BM.NET done.)

# How can I use it?
Download BetterMonacoNET.dll in the project's releases, and add it to your project's references.
Once that done, you will need to download CEFSharp's NuGet package for WinForms. Otherwise it won't work.
Finally, a folder called "Monaco" comes with the DLL. Move that folder to your app's executable location.

You also need to set your project to x86, AnyCPU isn't supported since I built BM.NET using x86. (Well, it should be, but to get AnyCPU support, check CEFSharp wiki.)

Once CEFSharp added and BetterMonacoNET.dll added to references and Monaco folder moved, go to your Form1() function or whatever it is, and do the following (CSharp): 
```cs
public Form1()
{
  InitializeComponent();
  Monaco monaco1 = new Monaco(); //Creates the Monaco editor.
  monaco1.Dock = DockStyle.Fill; //The control will take the whole form.
  this.Controls.Add(monaco1);
  
  monaco1.Initialize(); //Loads Monaco.html. REMINDER: The Monaco folder must be in your project's .exe location. You can still specify the path like this: monaco1.Initialize("C:/Monaco/Monaco.html")
}
```

Done! Now you have access to Microsoft's Monaco Editor in C#!
Check API.md for all the available functions.
