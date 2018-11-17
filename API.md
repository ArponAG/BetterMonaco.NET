# BetterMonaco.NET API!
There is the API list.

# Enums
```cs
public enum MonacoTheme
{
  Light = 0,
  Dark = 1,
  Black = 2,
}
```
---------
```cs
public enum WhitespaceEnum
{
  None = 0,
  Boundary = 1,
  All = 2,
}
```

# Structs
```cs
public struct MonacoSettings
{
  public bool ReadOnly;                 // Disables/Enables The Ability to Edit The Text.
  public bool AutoIndent;               // Enables auto Indentation & Adjustment
  public bool DragAndDrop;              // Enables Drag & Drop For Moving Selections of Text.
  public bool Folding;                  // Enables Code Folding.
  public bool FontLigatures;            // Enables Font Ligatures.
  public bool FormatOnPaste;            // Enables Formatting on Copy & Paste.
  public bool FormatOnType;             // Enables Formatting On Typing.
  public bool Links;                    // Enables Whether Links are clickable & detectible.
  public bool MinimapEnabled;           // Enables Whether Code Minimap is Enabled.
  public bool MatchBrackets;            // Enables Highlighting of Matching Brackets.
  public int LetterSpacing;            // Set's the Letter Spacing Between Characters.
  public int LineHeight;               // Set's the Line Height.
  public int FontSize;                 // Determine's the Font Size of the Text.
  public string FontFamily;               // Set's The Font Family for the Editor.
  public string RenderWhitespace;         // "none" | "boundary" | "all"
};
```

# Functions
```cs
public void Initialize(string MonacoEditorURL = "nazism") //"nazism" I just needed to define a variable in-case none is passed. Sorry if I offend anyone ^^'
```
Starts Monaco Editor.
- (MonacoEditorURL: path to Monaco.html.)
----------

```cs
public void SetTheme(MonacoTheme theme)
```
Sets Monaco Editor's theme.
- theme: MonacoTheme to be applied.
----------

```cs
public void SetLanguage(string x)
```
Sets Monaco Editor's language.
- x: Language to be set. Example: "cpp", "lua", "json"
----------

```cs
public void SetText(string text)
```
Sets Monaco Editor's text content.
- text: The text to be shown.
----------

```cs
public string GetText()
```
Returns Monaco Editor's text.
- None.
----------

```cs
public void AppendText(string text)
```
Appends the current Monaco Editor's text with the new one.
- text: Text to be added.
----------

```cs
public void GoToLine(int lineNumber)
```
Go to line.
- lineNumber: Line you wanna go.
----------

```cs
public void EditorRefresh()
```
Refreshes Monaco Editor.
- None.
----------

```cs
public void UpdateSettings(MonacoSettings settings)
```
Updates Monaco Editor's settings.
- settings: MonacoSettings to set.
----------

```cs
public void AddIntellisense(string label, string type, string description, string insert)
```
Adds Intellisense.
- label: Label that triggers the Intellisense.
- type: Type to be shown. (List: https://vgy.me/Uo7rMz.png)
- description: Description of the label.
- insert: Should be the same as label. This is the string used for auto complete. (aka when you type K, intellisense shows up and when you press TAB, K is replaced with Key. Get it?)
----------

```cs
public void ShowSyntaxError(int line, int column, int endLine, int endColumn, string message)
```
Shows Syntax Error
(I didn't get how it works yet, will be updated soon.)
