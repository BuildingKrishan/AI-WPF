using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AIFabricTest;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;
using Microsoft.Windows.SemanticSearch;

namespace AI_WPF
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class TextView : Page
    {
        public TextView()
        {
            InitializeComponent();

            // textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            // textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
            // write code to break the text through "." delimeter and store in an array
            string[] sentences = textEditor.Text.Split('.');
           

            Utils.CreateTextEmbedding(textEditor.Text);
            SearchPanel.Install(textEditor);
        }

        public void PerformFirstSearch()
        {
            string[] sentences = textEditor.Text.Split('.');
            EmbeddingVector[] embeddingVectors = new EmbeddingVector[sentences.Length];

            int[] indexes = new int[sentences.Length + 1];
            indexes[0] = 0;
            for (int i = 0; i < sentences.Length; i++)
            {
                indexes[i + 1] = sentences[i].Length;
                embeddingVectors[i] = Utils.CreateTextEmbedding(sentences[i]);
            }


            
        }

    }
}
