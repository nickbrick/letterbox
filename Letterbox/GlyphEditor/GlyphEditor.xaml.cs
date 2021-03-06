﻿using System;
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

namespace Letterbox
{
    /// <summary>
    /// Interaction logic for GlyphEditor.xaml
    /// </summary>
    public partial class GlyphEditor : Page
    {
        public Glyph Workpiece { get; set; }
        public Glyph Left;
        public Glyph Right;
        public Typeface Typeface { get; set; }
        public HashSet<Guideline> Guidelines;
        public GlyphEditor()
        {
            InitializeComponent();
            Loaded += GlyphEditor_Loaded;
            letterStrip_Main.SelectionChanged += LetterStrip_Main_SelectionChanged;
            Typeface = ((MainWindow)System.Windows.Application.Current.MainWindow).Typeface;
        }

        private void LetterStrip_Main_SelectionChanged(object sender, LetterStripEventArgs e)
        {
            Open(Typeface.FindGlyph(e.Character));
        }
        private void GlyphEditor_Loaded(object sender, RoutedEventArgs e)
        {
            curveEditor.Initialize();
            Open(Typeface.FindGlyph("b"));
        }

        public void Open(Glyph glyph)
        {
            Workpiece = glyph;
            curveEditor.LoadShape(Workpiece.Shape);
            //Guidelines = glyph.GetParameters().Select(param => new Guideline(param)).ToHashSet();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //curveEditor.Shape.Parts.ForEach(part => part.ControlPoints.ForEach(point => Console.WriteLine(point.Position)));
            Console.WriteLine(curveEditor.ActivePart.ClassName);
            curveEditor.ActivePart.ControlPoints.ForEach(point => Console.WriteLine(point.Position));

        }
    }
}
