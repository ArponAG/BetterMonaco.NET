using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;

namespace BetterMonacoNET
{

    /// <summary>
    /// Enum that defines available themes
    /// </summary>
    public enum MonacoTheme
    {
        Light = 0,
        Dark = 1,
        Black = 2,
    }
    

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

    public partial class Monaco: Panel
    {
        public ChromiumWebBrowser chromeBrowser;
        /// <summary>
        /// Starts Monaco Editor Binding
        /// </summary>
        /// <param name="MonacoEditorURL"></param>
        public void Initialize(string MonacoEditorURL = "nazism")
        {
            if (MonacoEditorURL == "nazism")
            {
                MonacoEditorURL = AppDomain.CurrentDomain.BaseDirectory + "\\Monaco\\Monaco.html";
            }
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser(MonacoEditorURL);
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        public Action StartupFunction;

        private bool ReadOnlyObj = false;
        /// <summary>
        /// Determines Whether Monaco is Readonly
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return ReadOnlyObj;
            }
            set
            {
                ReadOnlyObj = value;
            }
        }

        private bool MinimapEnabledObj = false;
        /// <summary>
        /// Determines Whether Minimap View for Monaco is Enabled
        /// </summary>
        public bool MinimapEnabled
        {
            get
            {
                return Boolean.Parse((dynamic)MinimapEnabledObj.ToString());
            }
            set
            {
                MinimapEnabledObj = Boolean.Parse((dynamic)value.ToString());
            }
        }

        /// <summary>
        /// Editor Text
        /// </summary>
        public override string Text
        {
            get
            {
                return ((dynamic)GetText()).ToString();
            }
            set
            {
                SetText(((dynamic)value).ToString());
            }
        }

        private dynamic RenderWhitespaceObj = (dynamic)"none";
        /// <summary>
        /// Determines Whether the Monaco Editor will render Whitespace
        /// </summary>
        public string RenderWhitespace
        {
            get
            {
                return RenderWhitespaceObj.ToString();
            }
            set
            {
                switch (value)
                {
                    case "none":
                        RenderWhitespaceObj = ((dynamic)"none").ToString();
                        break;
                    case "all":
                        RenderWhitespaceObj = ((dynamic)"all").ToString();
                        break;
                    case "boundary":
                        RenderWhitespaceObj = ((dynamic)"boundary").ToString();
                        break;
                    default:
                        RenderWhitespaceObj = ((dynamic)"none").ToString();
                        break;
                }
            }
        }

        /// <summary>
        /// Set's Monaco Editor's Theme to the Selected Choice.
        /// </summary>
        /// <param name="theme"></param>
        public void SetTheme(MonacoTheme theme)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                switch ((MonacoTheme)(dynamic)theme)
                {
                    case MonacoTheme.Dark:
                        chromeBrowser.ExecuteScriptAsync("SetTheme('Dark')");
                        break;
                    case MonacoTheme.Light:
                        chromeBrowser.ExecuteScriptAsync("SetTheme('Light')");
                        break;
                    case MonacoTheme.Black:
                        chromeBrowser.ExecuteScriptAsync("SetTheme('Black')");
                        break;
                }
            }
            else
            {
                throw new Exception((dynamic)"Cannot set Monaco theme while Document is null.");
            }
        }

        public void SetLanguage(string x)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                chromeBrowser.ExecuteScriptAsync("SetLanguage", new object[] { x });
            }
            else
            {
                throw new Exception((dynamic)"Cannot set Monaco theme while Document is null.");
            }
        }

        /// <summary>
        /// Set's the Text of Monaco to the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                chromeBrowser.ExecuteScriptAsync("SetText", new object[] { text });
            }
            else
            {
                throw new Exception((dynamic)"Cannot set Monaco's text while Document is null.");
            }
        }

        /// <summary>
        /// Get's the Text of Monaco and returns it.
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            string a = chromeBrowser.EvaluateScriptAsync("GetText").Result.ToString();
            if ((dynamic)this.chromeBrowser != null)
            {
                var result = chromeBrowser.GetMainFrame().EvaluateScriptAsync("GetText()").Result;
                return (string)result.Result;
            }
            else
                throw new Exception((dynamic)"Cannot get Monaco's text while Document is null.");
        }

        /// <summary>
        /// Appends the Text of Monaco with the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void AppendText(string text)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                SetText((dynamic)GetText() + text);
            }
            else
            {
                throw new Exception((dynamic)"Cannot append Monaco's text while Document is null.");
            }
        }

        public void GoToLine(int lineNumber)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                chromeBrowser.ExecuteScriptAsync("SetScroll", new object[] { lineNumber });
            }
            else
            {
                throw new Exception((dynamic)"Cannot go to Line in Monaco's Editor while Document is null.");
            }
        }

        /// <summary>
        /// Refreshes the Monaco editor.
        /// </summary>
        public void EditorRefresh()
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                chromeBrowser.ExecuteScriptAsync("Refresh");
            }
            else
            {
                throw new Exception((dynamic)"Cannot refresh Monaco's editor while the Document is null.");
            }
        }

        /// <summary>
        /// Updates Monaco Editor's Settings with it's Parameter Structure.
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateSettings(MonacoSettings settings)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                this.chromeBrowser.ExecuteScriptAsync("SwitchMinimap", new object[] { (dynamic)settings.MinimapEnabled });
                this.chromeBrowser.ExecuteScriptAsync("SwitchReadonly", new object[] { (dynamic)settings.ReadOnly });
                this.chromeBrowser.ExecuteScriptAsync("SwitchRenderWhitespace", new object[] { (dynamic)settings.RenderWhitespace });
                this.chromeBrowser.ExecuteScriptAsync("SwitchLinks", new object[] { (dynamic)settings.Links });
                this.chromeBrowser.ExecuteScriptAsync("SwitchLineHeight", new object[] { (dynamic)settings.LineHeight });
                this.chromeBrowser.ExecuteScriptAsync("SwitchFontSize", new object[] { (dynamic)settings.FontSize });
                this.chromeBrowser.ExecuteScriptAsync("SwitchFolding", new object[] { (dynamic)settings.Folding });
                this.chromeBrowser.ExecuteScriptAsync("SwitchAutoIndent", new object[] { (dynamic)settings.AutoIndent });
                this.chromeBrowser.ExecuteScriptAsync("SwitchFontFamily", new object[] { (dynamic)settings.FontFamily });
                this.chromeBrowser.ExecuteScriptAsync("SwitchFontLigatures", new object[] { (dynamic)settings.FontLigatures });
            }
            else
            {
                throw new Exception((dynamic)"Cannot change Monaco's settings while Document is null.");
            }
        }

        /// <summary>
        /// Add's Intellisense for the specified Type.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="insert"></param>
        public void AddIntellisense(string label, string type, string description, string insert)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                chromeBrowser.ExecuteScriptAsync("AddIntellisense", new object[] {
                    (dynamic)label,
                    (dynamic)type,
                    (dynamic)description,
                    (dynamic)insert
                });
            }
            else
            {
                throw new Exception((dynamic)"Cannot edit Monaco's Intellisense while Document is null.");
            }
        }

        /// <summary>
        /// Creates a Syntax Error Symbol (Squigly Red Line) on the Specific Paramaters in the Editor.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="endLine"></param>
        /// <param name="endColumn"></param>
        /// <param name="message"></param>
        public void ShowSyntaxError(int line, int column, int endLine, int endColumn, string message)
        {
            if ((dynamic)this.chromeBrowser != null)
            {
                this.chromeBrowser.ExecuteScriptAsync("ShowErr", new object[] { line, column, endLine, endColumn, message });
            }
            else
            {
                throw new Exception((dynamic)"Cannot show Syntax Error for Monaco while Document is null.");
            }
        }
    }
}
